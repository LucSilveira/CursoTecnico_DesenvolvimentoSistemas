using Carometro.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.Admin
{
    public class LogarCommand : Notifiable, ICommand
    {

        public LogarCommand()
        {

        }

        public LogarCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "Informe um Email válido")
                .HasMinLen(Senha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres")
                .HasMaxLen(Senha, 20, "Senha", "A senha deve ter no mínimo 20 caractéres")
                );
        }
    }
}
