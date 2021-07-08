using DoLink.Comum.Queries;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Skills
{
    public class ListarSkillQuery : Notifiable, IQuery
    {
        public void Validate()
        {}
    }

    //Mascara para filtrar apenas os dados necessários
    public class ListarSkillsResult
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string hash { get; set; }
    }
}
