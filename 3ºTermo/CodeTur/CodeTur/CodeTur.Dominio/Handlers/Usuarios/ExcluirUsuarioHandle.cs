using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Commands.Usuarios;
using CodeTur.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class ExcluirUsuarioHandle : IHandlerCommand<ExcluirUsuarioCommand>
    {
        // Injetando o nosso repositório de usuário
        private readonly IUsuarioRepository _repository;

        // Definindo que a classe 'ExcluirUsuarioHandle' necessita do 'IUsuarioRepository' para existir
        public ExcluirUsuarioHandle(IUsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }

        /// <summary>
        /// Método para validar os processos para excluir um usuário
        /// </summary>
        /// <param name="_command">Comando de alteração do usuário</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public ICommandResult Handle(ExcluirUsuarioCommand _command)
        {
            // 1º - Validando se o command recebido é válido
            _command.Validar();

                //Caso seja inválido, recebemos quando são os valores incorretos identificados por ele
                if (_command.Invalid)
                {
                    return new GenericCommandResult(false, "Informe um id correto", _command.Notifications);
                }

            //2º - Verificando se o id do usuário já não pertence a nossa base de dados
            var _usuarioExistente = _repository.BuscarUsuarioPorId(_command.IdUsuario);

                //Caso o id não exista, informe que o usuário informado não existe
                if (_usuarioExistente == null)
                {
                    return new GenericCommandResult(false, "Usuário não encontrado", _command.Notifications);
                }

            //3º - Excluindo o usuário do banco de dados
            _repository.ExcluirUsuario(_usuarioExistente);

            //Caso não haja erros, retornamos sucesso
            return new GenericCommandResult(true, "Usuário excluido com sucesso", _usuarioExistente);
        }
    }
}
