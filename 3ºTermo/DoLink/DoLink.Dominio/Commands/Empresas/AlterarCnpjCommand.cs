using DoLink.Comum.Commands;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Empresas
{
    public class AlterarCnpjCommand : Notifiable, ICommand
    {
        public AlterarCnpjCommand(string id, string cNPJ)
        {
            Id = id;
            CNPJ = cNPJ;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id", "O Id deve ser válido")
                .IsCnpj(CNPJ, "CNPJ", "O CNPJ deve ser válido!")
            );
        }

        public string Id { get; set; }
        public string CNPJ { get; set; }
    }
}
