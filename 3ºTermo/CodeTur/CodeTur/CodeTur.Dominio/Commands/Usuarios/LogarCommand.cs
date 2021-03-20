using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuarios
{
    /// <summary>
    /// Classe reponsável pelo comando de autenticação do usuário
    /// </summary>
    public class LogarCommand : Notifiable, ICommand
    {
        /// <summary>
        /// Construtor do comande de autenticação do objeto usuário
        /// </summary>
        /// <param name="email">Email de contato do usuário e de identificação do mesmo</param>
        /// <param name="senha">Senha de autorização</param>
        public LogarCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        /// <summary>
        /// Método de validação dos parametros para autenticar o objeto usuário
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "Informe um email válido")
                .HasMinLen(Senha, 6, "Senha", "A senha deve possuir no mínimo 6 caracteres")
                .HasMaxLen(Senha, 80, "Senha", "A senha deve possuir no máximo 80 caracteres")
            );
        }

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
