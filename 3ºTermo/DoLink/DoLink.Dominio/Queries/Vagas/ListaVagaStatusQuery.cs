using DoLink.Comum.Queries;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Vagas
{
    public class ListaVagaStatusQuery : Notifiable, IQuery
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }

    public class ListaVagaStatusResult
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string FaixaSalarial { get; set; }
        public string Beneficios { get; set; }
        public string Local { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
