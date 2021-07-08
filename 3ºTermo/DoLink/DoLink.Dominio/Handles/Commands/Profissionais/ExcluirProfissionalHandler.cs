using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Profissionais
{
    public class ExcluirProfissionalHandler : Notifiable, IHandler<ExcluirProfissionalCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IProfissionalRepository _repository;

        //Instânciando os métodos contidos no repositório
        public readonly IMatchRepository _matchRepository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public ExcluirProfissionalHandler(IProfissionalRepository repository, IMatchRepository match)
        {
            _repository = repository;
            _matchRepository = match;
        }

        /// <summary>
        /// Método para excluir um profissional existente no banco de dados
        /// </summary>
        /// <param name="command">dados a serem processados para localizar o profissional desejado</param>
        /// <returns>Dados a cerca do profissional excluido</returns>
        public ICommandResult Handler(ExcluirProfissionalCommand command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validar();

            //Caso os dados esteja com erro, retornamos uma notificação
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Procurando o profissional informado no banco de dados
            var profissionalExistente = _repository.BuscarProfissionalEspecifico(command.Id).Result;

            //Caso a mesmo não exista, retornamos o erro    
            if (profissionalExistente == null)
            {
                return new GenericCommandResult(false, "Conta não encontrada", command.Notifications);
            }

            //Procurando os matchs realizados pelo profissional
            var matchs = _matchRepository.ListaDeMatchsProfissional(profissionalExistente.Id).Result;

            //Percorrendo os matchs confirmados pelo profissional
            foreach(Match match in matchs)
            {
                //Deletando os matchs confirmados pelo profissional
                _matchRepository.ExcluirMatch(match);
            }

            // Passando para o banco de dados o objeto que será excluido
            _repository.ExcluirProfissional(profissionalExistente);

            //Retornamos com sucesso os dados do profissional deletado
            return new GenericCommandResult(true, "Profissional deletado com sucesso", profissionalExistente);
        }
    }
}
