using System;
using System.Collections.Generic;

namespace EduxProject.Domains
{
    public partial class Categorias
    {
        public Categorias()
        {
            Objetivos = new HashSet<Objetivos>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Objetivos> Objetivos { get; set; }
    }
}
