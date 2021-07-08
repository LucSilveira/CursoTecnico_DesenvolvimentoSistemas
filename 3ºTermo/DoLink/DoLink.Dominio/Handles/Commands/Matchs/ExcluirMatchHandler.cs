using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Matchs;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Matchs
{
    public class ExcluirMatchHandler : Notifiable, IHandler<ExcluirMatchCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IMatchRepository _repository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public ExcluirMatchHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handler(ExcluirMatchCommand command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validar();

            //Caso os dados estejam inválidos retornamos o erro
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);
            }

            //Buscando no banco de dados se o match informado já não existe
            var matchExistente = _repository.BuscarMatchEspecifico(command.Id).Result;

            //Caso o mesmo já não exista informamos o erro
            if (matchExistente == null)
            {
                return new GenericCommandResult(false, "Match não encontrado!", command.Notifications);
            }

            // Passando para o banco de dados o objeto que será excluido
            _repository.ExcluirMatch(matchExistente);

            //Retornamos com sucesso os dados do match deletado
            return new GenericCommandResult(true, "Match cancelado com sucesso", matchExistente);
        }
    }
}
