using DoLink.Comum.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Skills
{
    public class BuscarSkillPorIdQuery : Notifiable, IQuery
    {
        public BuscarSkillPorIdQuery(string id)
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

    public class BuscarSkillPorIdResult
    {
        public string Id { get; set; }
        public string Nome { get; set; }
    }
}
