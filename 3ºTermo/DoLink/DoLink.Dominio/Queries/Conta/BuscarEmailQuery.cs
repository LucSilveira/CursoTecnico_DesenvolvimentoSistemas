using DoLink.Comum.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Conta
{
    public class BuscarEmailQuery : Notifiable, IQuery
    {
        public BuscarEmailQuery(string email)
        {
            Email = email;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "Email inválido")
            );
        }

        public string Email { get; set; }
    }

    public class BuscarEmailResult
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
