using DoLink.Comum.Commands;
using DoLink.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Vagas
{
    public class AlterarStatusVagaCommand : Notifiable, ICommand
    {
        public AlterarStatusVagaCommand(EnStatusVaga status)
        {
            Status = status;
        }

        public EnStatusVaga Status { get; set; }
        public string Id { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotNull(Status, "Status", "O status não deve ser nulo")
               );
        }
    }
}
