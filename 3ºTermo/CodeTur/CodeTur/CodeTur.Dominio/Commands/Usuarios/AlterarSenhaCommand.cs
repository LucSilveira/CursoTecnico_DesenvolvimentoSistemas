using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuarios
{
    /// <summary>
    /// Classe responsável pelo comando de alteração da senha do usuário
    /// </summary>
    public class AlterarSenhaCommand : Notifiable, ICommand
    {
        /// <summary>
        /// Construtor do comando de alteração da senha do objeto usuário
        /// </summary>
        /// <param name="idUsuario">Código de identificação do próprio usuário</param>
        /// <param name="senha">Senha a ser alterada</param>
        public AlterarSenhaCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        /// <summary>
        /// Método de validação dos parametros para alteração do objeto usuário
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
