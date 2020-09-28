using System;
using System.Collections.Generic;

namespace EduxProject.Domains
{
    public partial class Objetivos
    {
        public Objetivos()
        {
            ObjetivosAlunos = new HashSet<ObjetivosAlunos>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categorias IdCategoriaNavigation { get; set; }
        public virtual ICollection<ObjetivosAlunos> ObjetivosAlunos { get; set; }
    }
}
