using DoLink.Comum.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Skills
{
    public class BuscarSkillQuery : Notifiable, IQuery
    {
        //Constructor para o parametro de busca 'nome'
        public BuscarSkillQuery(string nome)
        {
            Nome = nome;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome, "Nome", "Informe o nome da habilidade")
            );
        }

        public string Nome { get; set; }
    }

    //Mascara para filtrar os dados exibidos
    public class BuscarSkillResult
    {
        public string Id { get; set; }
        public string Nome { get; set; }
    }
}
