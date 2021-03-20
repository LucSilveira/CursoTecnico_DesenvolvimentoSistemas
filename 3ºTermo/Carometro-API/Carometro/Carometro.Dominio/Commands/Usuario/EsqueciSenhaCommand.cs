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
    public class EsqueciSenhaCommand : Notifiable, ICommand
    {
        public EsqueciSenhaCommand(string email)
        {
            Email = email;
        }

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
