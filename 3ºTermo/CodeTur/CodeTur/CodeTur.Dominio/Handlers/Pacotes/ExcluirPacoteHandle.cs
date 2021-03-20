using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Commands.Pacotes;
using CodeTur.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class ExcluirPacoteHandle : IHandlerCommand<ExcluirPacoteCommand>
    {
        // Injetando o nosso repositório de pacote
        private readonly IPacoteRepository _repository;

        // Definindo que a classe 'ExcluirPacoteHandle' necessita do 'IPacoteRepository' para existir
        public ExcluirPacoteHandle(IPacoteRepository _pacoteRepository)
        {
            _repository = _pacoteRepository;
        }

        /// <summary>
        /// Método para validar os processos para excluir um pacote
        /// </summary>
        /// <param name="_command">Comando de deleção do pacote</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public ICommandResult Handle(ExcluirPacoteCommand _command)
        {
            //1º - Validando se o command recebido é válido
            _command.Validar();

                //Caso seja inválido, recebemos quando são os valores incorretos identificados por ele
                if (_command.Invalid)
                {
                    return new GenericCommandResult(false, "Informe um id correto", _command.Notifications);
                }

            //2º - Verificando se o id do pacote já não pertence a nossa base de dados
            var _pacoteExistente = _repository.BuscarPacotePorId(_command.IdPacote);

                //Caso o id não exista, informe ao usuário que o pacote informado não existe
                if (_pacoteExistente == null)
                {
                    return new GenericCommandResult(false, "Pacote não encontrado", _command.Notifications);
                }

            //3º - Excluindo o pacote do banco de dados
            _repository.ExcluirPacote(_pacoteExistente);

            //Caso não haja erros, retornamos sucesso
            return new GenericCommandResult(true, "Pacote excluido com sucesso", _pacoteExistente);
        }
    }
}
