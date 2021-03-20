using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Utils;
using CodeTur.Dominio.Commands.Usuarios;
using CodeTur.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class AlterarSenhaHandle : Notifiable, IHandlerCommand<AlterarSenhaCommand>
    {
        // Injetando o nosso repositório de usuário
        private readonly IUsuarioRepository _repository;

        // Definindo que a classe 'AlterarSenhaHandle' necessita do 'IUsuarioRepository' para existir
        public AlterarSenhaHandle(IUsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }

        /// <summary>
        /// Método para validar os processos para alterar a senha de um usuário
        /// </summary>
        /// <param name="_command">Comando de alteração do usuário</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public ICommandResult Handle(AlterarSenhaCommand _command)
        {
            //1º - Validando se o command recebido é válido
            _command.Validar();

                //Caso seja inválido, recebemos quando são os valores incorretos identificados por ele
                if (_command.Invalid)
                {
                    return new GenericCommandResult(false, "Informe os dados corretamente", _command.Notifications);
                }

            //2º - Verificando se o email de usuário pertence a nossa base de dados
            var _emailUsuarioExistente = _repository.BuscarUsuarioPorEmail(_command.Email);

                //Caso o email não exista, informe ao usuário que o usuário informado não existe
                if (_emailUsuarioExistente == null)
                {
                    return new GenericCommandResult(false, "Conta de email não encontrada, informe um e-mail cadastrado", _command.Notifications);
                }

            //3º - Enviando um email de confirmação da nova senha
            _ = SendEmailGrid.EnviarEmail(_emailUsuarioExistente.Email, _emailUsuarioExistente.Nome, "Confirmação de alteração de senha", "Senha alterada com sucesso!", "Conforme a solicitação da alteração de senha, confirmamos que sua senha foi alterada com sucesso, faça o login na plataforma inserindo os novos dados, muito obrigado!", null);

            //4º - Encriptografando a nova senha
            _command.Senha = HashDeSenha.EncriptografarSenha(_command.Senha);

            //5º - Passando para o objeto alterar os seus dados
            _emailUsuarioExistente.AlterarSenha(_command.Senha);

            //6º - Salvando os dados na base de dados
            _repository.AlterarUsuario(_emailUsuarioExistente);

            //Caso não haja erros, alteramos as informações
            return new GenericCommandResult(true, "Senha alterada com sucesso", _emailUsuarioExistente);
        }
    }
}
