using DoLink.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Empresa
{
    public class ExcluirEmpresaCommand : Notifiable, ICommand
    {
        public ExcluirEmpresaCommand(string id)
        {
            Id = id;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
              .Requires()
              .IsNullOrEmpty(Id, "Id", "Id nao deve ser nulo")
           );
        }

        public string Id { get; set; }
    }
}
