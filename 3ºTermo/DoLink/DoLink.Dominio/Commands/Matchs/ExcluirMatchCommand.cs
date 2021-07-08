using DoLink.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Matchs
{
    public class ExcluirMatchCommand : Notifiable, ICommand
    {
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id do match", "Id do match não específicado")
            );
        }

        public string Id { get; set; }
    }
}
