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
    public class EsqueciSenhaHandle : Notifiable, IHandlerCommand<EsqueciSenhaCommand>
    {
        // Injetando o nosso repositório de usuário
        private readonly IUsuarioRepository _repository;

        // Definindo que a classe 'EsqueciSenhaHandle' necessita do 'IUsuarioRepository' para existir
        public EsqueciSenhaHandle(IUsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }

        /// <summary>
        /// Método para validar os processos para resetar a senha do usuário
        /// </summary>
        /// <param name="_command">Comando de resetar a senha do usuário</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public ICommandResult Handle(EsqueciSenhaCommand _command)
        {
            //1º - Validando se o command recebido é válido
            _command.Validar();

                //Caso seja inválido, recebemos quando são os valores incorretos identificados por ele
                if (_command.Invalid)
                {
                    return new GenericCommandResult(false, "Informe os dados corretamente", _command.Notifications);
                }

            //2º - Verificando se o email de usuário pertence a nossa base de dados
            var _usuarioExistente = _repository.BuscarUsuarioPorEmail(_command.Email);

                //Caso o email não exista, informe ao usuário que o email informado já está em uso
                if (_usuarioExistente == null)
                {
                    return new GenericCommandResult(false, "E-mail não cadastrado, informe um e-mail válido", _command.Notifications);
                }

            //3º - Gerando uma nova senha para o usuário
            var _novaSenha = RandomPassword.GeradorDeSenha();

            //4º - Enviando a nova senha gerada para o email
            _ = SendEmailGrid.EnviarEmail(_usuarioExistente.Email, _usuarioExistente.Nome, "Confirmação de nova senha", "Senha alterada com sucesso!", $"Conforme a solicitação da alteração de senha, nos da plataforma CodeTur disponibizamos uma nova senha para você, faça o login na plataforma inserindo os novos dados e sinta-se a vontade para altera-lá quando precisar, muito obrigado!<br><br>Sua nova senha é: ", _novaSenha);

            //5º - Encriptografando a nova senha
            var _novaSenhaEncriptografada = HashDeSenha.EncriptografarSenha(_novaSenha);

            //6º - Salvar a nova senha no banco de dados
            _usuarioExistente.AlterarSenha(_novaSenhaEncriptografada);

            //7º - Salvando novos dados na base de dados
            _repository.AlterarUsuario(_usuarioExistente);

            //Caso não haja erros, alteramos a senha do usuario
            return new GenericCommandResult(true, "Nova senha gerada com sucesso", _novaSenha);
        }
    }
}
