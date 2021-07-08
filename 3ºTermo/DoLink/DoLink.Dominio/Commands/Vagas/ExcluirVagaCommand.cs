using DoLink.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Vaga
{
    public class ExcluirVagaCommand : Notifiable, ICommand
    {
        public ExcluirVagaCommand(string id)
        {
            Id = id;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
              .Requires()
              .IsNotNullOrEmpty(Id, "Id", "Id nao deve ser nulo")
           );
        }
        public string Id { get; set; }
    }
}
