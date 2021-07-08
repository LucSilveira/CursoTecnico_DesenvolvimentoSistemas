using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Queries;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Profissionais
{
    public class ListarProfissionalQuery : Notifiable, IQuery
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }

    public class ListarProfissionaisResult
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
    }
}
