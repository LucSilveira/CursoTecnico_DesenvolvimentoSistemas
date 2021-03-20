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
using System.Threading.Tasks;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    /// <summary>
    /// Classe handle de criação de usuário para gerenciar o command de criar usuário
    /// </summary>
    public class CriarUsuarioHandle : Notifiable, IHandlerCommand<CriarUsuarioCommand>
    {
        // Injetando o nosso repositório de usuário
        private readonly IUsuarioRepository _repository;

        // Definindo que a classe 'CriarUsuarioHandle' necessita do 'IUsuarioRepository' para existir
        public CriarUsuarioHandle(IUsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }


        /// <summary>
        /// Método para validar os processos para criar um usuário
        /// </summary>
        /// <param name="_command">Comando de criação do usuário</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public ICommandResult Handle(CriarUsuarioCommand _command)
        {
            //1º - Validando se o command recebido é válido
            _command.Validar();

                //Caso seja inválido, recebemos quando são os valores incorretos identificados por ele
                if (_command.Invalid)
                {
                    return new GenericCommandResult(false, "Informe os dados corretamente", _command.Notifications);
                }

            //2º - Verificando se o email de usuário já não pertence a nossa base de dados
            var _emailUsuarioExistente = _repository.BuscarUsuarioPorEmail(_command.Email);

                //Caso o email exista, informe ao usuário que o email informado já está em uso
                if(_emailUsuarioExistente != null)
                {
                    return new GenericCommandResult(false, "E-mail já cadastrado, informe um novo e-mail", _command.Notifications);
                }

            //3º - Criptografando a senha informada pelo usuário
            _command.Senha = HashDeSenha.EncriptografarSenha(_command.Senha);

            //4º - Criando uma nova instância de usuário com os dados capturados
            var _usuario = new Usuario(_command.Nome, _command.Email, _command.Senha, _command.TipoPerfil);

                //Verificando se o usuário informou um número de telefone
                if (!string.IsNullOrEmpty(_command.Telefone))
                {
                    //Caso sim, atrelar o telefone ao usuário
                    _usuario.AdicionarTelefone(_command.Telefone);
                }

            //5º - Validando os dados do usuário
            if (_usuario.Invalid)
            {
                return new GenericCommandResult(false, "Dados do usuário inválidos", _usuario.Notifications);
            }

            //6º - Enviar um email de notificação para o usuário
            _ = SendEmailGrid.EnviarEmail(_usuario.Email, _usuario.Nome, "Confirmação de cadastro", "Seu cadastro foi realizado", "Olá, é um grande prazer receber você na nossa plataforma CodeTur, esperamos que você possa aproveitar nossos serviços, muito obrigado pelo interesse!", null);

            //7º - Salvando no banco de dados
            _repository.AdicionarUsuario(_usuario);

            return new GenericCommandResult(true, "Usuário criado com sucesso", _usuario);
        }
    }
}
