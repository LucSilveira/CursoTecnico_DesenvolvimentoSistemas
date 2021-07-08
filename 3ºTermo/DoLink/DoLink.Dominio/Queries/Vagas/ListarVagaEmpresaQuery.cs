using DoLink.Comum.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Vagas
{
    public class ListarVagaEmpresaQuery : Notifiable, IQuery
    {
        public ListarVagaEmpresaQuery(string id)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id da skill", "Id da skill inválida")
            );
        }

        public string Id { get; set; }
    }

    public class ListarVagaEmpresaResult
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
