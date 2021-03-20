using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Commands.Pacotes;
using CodeTur.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class AlterarPacoteHandle : IHandlerCommand<AlterarPacoteCommand>
    {
        // Injetando o nosso repositório de pacote
        private readonly IPacoteRepository _repository;

        // Definindo que a classe 'AlterarPacoteHandle' necessita do 'IPacoteRepository' para existir
        public AlterarPacoteHandle(IPacoteRepository _pacoteRepository)
        {
            _repository = _pacoteRepository;
        }

        /// <summary>
        /// Método para validar os processos para alterar um pacote
        /// </summary>
        /// <param name="_command">Comando de alteração do pacote</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public ICommandResult Handle(AlterarPacoteCommand _command)
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

                if(_pacoteExistente == null)
                {
                    return new GenericCommandResult(false, "Pacote não encontrado, verifique o código do pacote", _command.Notifications);
                }

            //3º - Verificando se o novo titulo não está repetido com os armazenados na base de dados
            if (_command.Titulo != _pacoteExistente.Titulo)
            {
                //Buscando o email no banco de dados
                var _novoTituloExistente = _repository.BuscarPacotePorTitulo(_command.Titulo);

                //Verificando se há usuários utilizando o novo email informado
                if (_novoTituloExistente != null)
                {
                    return new GenericCommandResult(false, "Este título já está vinculado a uma pacote, informe outro titulo", _command.Notifications);
                }
            }

            //4º - Atribuir ao objeto pacote a alteração dos dados do mesmo
            _pacoteExistente.AlterarPacote(_command.Titulo, _command.Descricao);

            //5º - Verificando se as alterações não contém erros para salvarmos
            if (_pacoteExistente.Invalid)
            {
                return new GenericCommandResult(false, "Dados do pacote inválido", _command.Notifications);
            }

            //6º - Salvamos as alterações no banco de dados
            _repository.AlterarPacote(_pacoteExistente);

            //Caso não haja erros, restornamos sucesso e o novo objeto
            return new GenericCommandResult(true, "Pacote alterado", _pacoteExistente);
        }
    }
}
