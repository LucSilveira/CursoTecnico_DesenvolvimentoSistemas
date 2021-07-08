using DoLink.Comum.Queries;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Matchs
{
    public class ListarMatchQuery : Notifiable, IQuery
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }

    public class ListarMatchResult
    {
        public string Id { get; set; }
        public string IdVaga { get; set; }
        public string IdProfissional { get; set; }
    }
}
