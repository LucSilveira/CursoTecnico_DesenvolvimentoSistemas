using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Utils;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Profissionais;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using DoLink.Dominio.Utils;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Profissionais
{
    public class AlterarProfissionalMobileHandler : Notifiable, IHandler<AlterarProfissionalMobileCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IProfissionalRepository _repository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public AlterarProfissionalMobileHandler(IProfissionalRepository repository)
        {
            _repository = repository;
        }

        StringComparer ordenar = StringComparer.InvariantCultureIgnoreCase;
        /// <summary>
        /// Método para alterar os dados de um profissional cadastrado
        /// </summary>
        /// <param name="command">Todos os dados que serão alterados dentro do profissional</param>
        /// <returns>Profissional com os dados alterados</returns>
        public ICommandResult Handler(AlterarProfissionalMobileCommand command)
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
                return new GenericCommandResult(false, "Conta não encontrada não encontrada", command.Notifications);
            }

            //Passando o array de skills para o método de ordenação
            command.SkillsProfissional = OrdenarSkills.OrdenarArray(command.SkillsProfissional);

            //Passando o token de skills para o profissional
            var hash = HasheandoSkills.Hasheando(command.SkillsProfissional);

            //Criando o objeto com os dados informados
            profissionalExistente.AlterarProfissionalGeral(command.CPF, command.CEP, command.SobreMim, command.Linkedin, command.Repositorio, command.FaixaSalarial, command.Curriculo , command.SkillsProfissional, hash);

            var resultado = new ContentModerator().Moderar(profissionalExistente.SobreMim.ToString().ToLower());
            

            if (resultado != null)
            {
                var palavras = resultado.Select(
                    r =>
                    {
                        return new
                        {
                            palavra = r.Term
                        };
                    }
                    ).ToArray();
                return new GenericCommandResult(false, "palavras inadequadas", palavras);
            }

            //Salvando no banco de dados as novas informações
            _repository.AlterarProfissional(profissionalExistente);

            //Retornando com sucesso o profissional alterado
            return new GenericCommandResult(true, "Profissional alterado com sucesso", profissionalExistente);
        }
    }
}
