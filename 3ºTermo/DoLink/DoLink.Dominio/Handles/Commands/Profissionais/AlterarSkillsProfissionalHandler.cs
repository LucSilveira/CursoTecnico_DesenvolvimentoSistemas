
using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Profissionais;
using DoLink.Dominio.Repositories;
using DoLink.Dominio.Utils;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Profissionais
{
    public class AlterarSkillsProfissionalHandler : Notifiable, IHandler<AlterarSkillsProfissionalCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IProfissionalRepository _repository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public AlterarSkillsProfissionalHandler(IProfissionalRepository repository)
        {
            _repository = repository;
        }


        public ICommandResult Handler(AlterarSkillsProfissionalCommand command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validar();

            //Caso os dados esteja com erro, retornamos uma notificação
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);
            }

            //Procurando o profissional informado no banco de dados
            var profissionalExistente = _repository.BuscarProfissionalEspecifico(command.Id).Result;

            //Caso a mesmo não exista, retornamos o erro    
            if (profissionalExistente == null)
            {
                return new GenericCommandResult(false, "Conta não encontrada", command.Notifications);
            }

            //Passando o array para a ordenação
            command.SkillsProfissional = OrdenarSkills.OrdenarArray(command.SkillsProfissional);

            //Passando o token de skills para o profissional
            var hash = HasheandoSkills.Hasheando(command.SkillsProfissional);

            //Criando o objeto com os dados informados
            profissionalExistente.AlterarSkills(command.SkillsProfissional, hash);

            //Salvando no banco de dados as novas informações
            _repository.AlterarProfissional(profissionalExistente);

            //Retornando com sucesso o profissional alterado
            return new GenericCommandResult(true, "Profissional alterado com sucesso", profissionalExistente);
        }
    }
}
