using Carometro.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.Usuario
{
    public class AlterarSenhaCommand : Notifiable, ICommand
    {
        public AlterarSenhaCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

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
