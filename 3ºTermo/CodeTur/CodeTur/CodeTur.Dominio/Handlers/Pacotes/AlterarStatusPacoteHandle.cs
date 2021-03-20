using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Commands.Pacotes;
using CodeTur.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class AlterarStatusPacoteHandle : IHandlerCommand<AlterarStatusPacoteCommand>
    {
        // Injetando o nosso repositório de pacote
        private readonly IPacoteRepository _repository;

        // Definindo que a classe 'AlterarStatusPacoteHandle' necessita do 'IPacoteRepository' para existir
        public AlterarStatusPacoteHandle(IPacoteRepository _pacoteRepository)
        {
            _repository = _pacoteRepository;
        }

        /// <summary>
        /// Método para validar os processos para alterar um pacote
        /// </summary>
        /// <param name="_command">Comando de alteração do pacote</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public ICommandResult Handle(AlterarStatusPacoteCommand _command)
        {
            //1º - Validando se o command recebido é válido
            _command.Validar();

                //Caso seja inválido, recebemos quando são os valores incorretos identificados por ele
                if (_command.Invalid)
                {
                    return new GenericCommandResult(false, "Informe os dados corretamente", _command.Notifications);
                }

            //2º - Verificando se o pacote existe no sistema
            var _pacoteExistente = _repository.BuscarPacotePorId(_command.IdPacote);

                if (_pacoteExistente == null)
                {
                    return new GenericCommandResult(false, "Pacote não encontrado, verifique o código do pacote", _command.Notifications);
                }

            if (_command.Status == _pacoteExistente.Ativo)
            {
                return new GenericCommandResult(true, "Este status já está definido.", _command.Notifications);
            }

            _pacoteExistente.AlterarStatus(_command.Status);

            if (_pacoteExistente.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", _pacoteExistente.Notifications);

            //Salvar alteração no banco
            _repository.AlterarPacote(_pacoteExistente);

            return new GenericCommandResult(true, "Status de pacote alterado", _pacoteExistente);
        }
    }
}
