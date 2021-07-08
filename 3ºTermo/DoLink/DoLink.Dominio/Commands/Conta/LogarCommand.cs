using DoLink.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Conta
{
    public class LogarCommand : Notifiable, ICommand
    {
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "O email deve ser um email válido!")
                .HasMinLen(Senha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres!")
            );
        }

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
