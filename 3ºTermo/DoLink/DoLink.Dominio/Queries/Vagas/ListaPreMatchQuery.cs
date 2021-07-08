using DoLink.Comum.Queries;
using DoLink.Dominio.Queries.Profissionais;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Vagas
{
    public class ListaPreMatchQuery : Notifiable, IQuery
    {
        public ListaPreMatchQuery(string idProfissional)
        {
            IdProfissional = idProfissional;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdProfissional, Guid.Empty, "Id do profissional", "ID do profissional inválida")
            );
        }

        public string IdProfissional { get; set; }
    }

    public class ListPreMatchResult
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public float FaixaSalarial { get; set; }
        public BuscarProfissionalResult DadosProfissional { get; set; }
        public DoLink.Dominio.Entidades.Skill[] skill{ get; set; }
    }
}
