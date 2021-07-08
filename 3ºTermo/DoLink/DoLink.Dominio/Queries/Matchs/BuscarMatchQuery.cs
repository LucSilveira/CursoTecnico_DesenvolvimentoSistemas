using DoLink.Comum.Queries;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Queries.Empresas;
using DoLink.Dominio.Queries.Profissionais;
using DoLink.Dominio.Queries.Vagas;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Matchs
{
    public class BuscarMatchQuery : Notifiable, IQuery
    {
        public BuscarMatchQuery(string id)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id do usuário", "Id do usuário inválido")
            );
        }

        public string Id { get; set; }
    }

    public class BuscarMatchResult
    {
        public string Id { get; set; }
        public BuscarVagaResult DadosVaga { get; set; }
        public BuscarEmpersaResult DadosEmpresa { get; set; }
        public BuscarProfissionalResult DadosProfissional { get; set; }
        public int NivelAcesso { get; set; }
    }
}
