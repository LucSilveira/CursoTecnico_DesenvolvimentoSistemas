using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Utils;
using CodeTur.Dominio.Commands.Usuarios;
using CodeTur.Dominio.Domains;
using CodeTur.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class LogarHandle : Notifiable, IHandlerCommand<LogarCommand>
    {
        // Injetando o nosso repositório de usuário
        private readonly IUsuarioRepository _repository;

        // Definindo que a classe 'CriarUsuarioHandle' necessita do 'IUsuarioRepository' para existir
        public LogarHandle(IUsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }

         
        /// <summary>
        /// Método para validar os processos para altenticar o usuário
        /// </summary>
        /// <param name="_command">Comando de autenticação do usuário</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public ICommandResult Handle(LogarCommand _command)
        {
            //1º - Validando se o command recebido é válido
            _command.Validar();

                //Caso seja inválido, recebemos quando são os valores incorretos identificados por ele
                if (_command.Invalid)
                {
                    return new GenericCommandResult(false, "Informe os dados corretamente", _command.Notifications);
                }

            //2º - Verificando se o email de usuário pertence a nossa base de dados
            Usuario _usuarioExistente = _repository.BuscarUsuarioPorEmail(_command.Email);

                //Caso o email não exista no banco de dados, informamos a invalidação da autentificação
                if (_usuarioExistente == null)
                {
                    return new GenericCommandResult(false, "Usuário não encontrado", _command.Notifications);
                }

            //3º - Validando os dados do usuário com os informados
            if(!HashDeSenha.ValidarSenha(_command.Senha, _usuarioExistente.Senha))
            {
                return new GenericCommandResult(false, "Senha inválida", _command.Notifications);
            }

            //Caso nenhum problema seja encontrado, gerado resultado de sucesso
            return new GenericCommandResult(true, "Usuário logado com sucesso", _usuarioExistente);
        }
    }
}
