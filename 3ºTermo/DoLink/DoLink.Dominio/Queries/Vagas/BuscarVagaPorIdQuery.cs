using DoLink.Comum.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Vagas
{
    public class BuscarVagaPorIdQuery : Notifiable, IQuery
    {
        public BuscarVagaPorIdQuery(string id)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id da vaga", "Id da vaga inválida")
            );
        }

        public string Id { get; set; }
    }

    public class BuscarVagaIdResult
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public string FaixaSalarial { get; set; }
        public string Beneficios { get; set; }
        public string Local { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
