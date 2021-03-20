using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuarios
{
    /// <summary>
    /// Classe responsável pelo comando de requisição de uma nova senha
    /// </summary>
    public class EsqueciSenhaCommand : Notifiable, ICommand
    {
        /// <summary>
        /// Construtor do comando de requisição de uma nova senha para o usuário
        /// </summary>
        /// <param name="email">Email de contato do usuário</param>
        public EsqueciSenhaCommand(string email)
        {
            Email = email;
        }

        /// <summary>
        /// Método de validação dos parametros para alteração do objeto usuário
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "Informe um email válido")
            );
        }

        public string Email { get; set; }
    }
}
