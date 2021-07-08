using DoLink.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Conta
{
    public class AlterarSenhaCommand : Notifiable, ICommand
    {
        public void Validar()
        {
            AddNotifications(new Contract()
              .Requires()
              .IsEmail(Email, "Email", "O email deve ser um email válido!")
              .HasMinLen(NovaSenha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres!")
              .HasMinLen(Confirmacao, 6, "Confirmação de senha", "A senha deve ter no mínimo 6 caractéres!")
           );
        }

        public string Email { get; set; }
        public string NovaSenha { get; set; }
        public string Confirmacao { get; set; }
    }
}
