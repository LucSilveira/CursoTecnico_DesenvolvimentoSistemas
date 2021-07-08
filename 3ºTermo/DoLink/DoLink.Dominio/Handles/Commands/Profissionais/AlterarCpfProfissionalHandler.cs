using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Profissionais;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Profissionais
{
    public class AlterarCpfProfissionalHandler : Notifiable, IHandler<AlterarCpfProfissionalCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IProfissionalRepository _repository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public AlterarCpfProfissionalHandler(IProfissionalRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handler(AlterarCpfProfissionalCommand command)
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

            //Criando o objeto com os dados informados
            profissionalExistente.AlterarCPFProfissional(command.CPF);

            //Salvando no banco de dados as novas informações
            _repository.AlterarProfissional(profissionalExistente);

            //Retornando com sucesso o profissional alterado
            return new GenericCommandResult(true, "Profissional alterado com sucesso", profissionalExistente);
        }
    }
}
