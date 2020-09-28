using System;
using System.Collections.Generic;

namespace EduxProject.Domains
{
    public partial class Perfils
    {
        public Perfils()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Permissao { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
