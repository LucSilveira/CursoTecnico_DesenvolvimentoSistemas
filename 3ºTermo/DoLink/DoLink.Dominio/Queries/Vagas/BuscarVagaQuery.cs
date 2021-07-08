using DoLink.Comum.Enum;
using DoLink.Comum.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Vagas
{
    public class BuscarVagaQuery : Notifiable, IQuery
    {
        public BuscarVagaQuery(string titulo)
        {
            Titulo = titulo;
        }

        public string Titulo { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Titulo, "Titulo", "O Titulo não deve ser nulo")
            );
        }
    }

    public class BuscarVagaResult
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
