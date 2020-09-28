using System;
using System.Collections.Generic;

namespace EduxProject.Domains
{
    public partial class Cursos
    {
        public Cursos()
        {
            Turmas = new HashSet<Turmas>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public int? IdInstituicao { get; set; }

        public virtual Instituicoes IdInstituicaoNavigation { get; set; }
        public virtual ICollection<Turmas> Turmas { get; set; }
    }
}
