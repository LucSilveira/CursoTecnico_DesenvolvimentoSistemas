using DoLink.Comum.Enum;
using DoLink.Comum.Queries;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Vagas
{
    public class ListarVagaQuery : Notifiable, IQuery
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
    public class ListarVagaResult
    {
        public string Id { get; set; }
        public string Empresa { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public string FaixaSalarial { get; set; }
        public string Beneficios { get; set; }
        public string Local { get; set; }
        public DateTime DataVencimento { get; set; }

    }
}
