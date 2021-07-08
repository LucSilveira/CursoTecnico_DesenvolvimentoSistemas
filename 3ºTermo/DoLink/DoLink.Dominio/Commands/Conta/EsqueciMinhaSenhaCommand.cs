using DoLink.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Conta
{
    public class EsqueciMinhaSenhaCommand : Notifiable, ICommand
    {
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "O email deve ser um email válido!")
            );
        }

        public string Email { get; set; }
    }
}
