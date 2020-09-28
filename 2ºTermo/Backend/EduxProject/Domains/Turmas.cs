using System;
using System.Collections.Generic;

namespace EduxProject.Domains
{
    public partial class Turmas
    {
        public Turmas()
        {
            AlunosTurmas = new HashSet<AlunosTurmas>();
            ProfessoresTurmas = new HashSet<ProfessoresTurmas>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int? IdCurso { get; set; }

        public virtual Cursos IdCursoNavigation { get; set; }
        public virtual ICollection<AlunosTurmas> AlunosTurmas { get; set; }
        public virtual ICollection<ProfessoresTurmas> ProfessoresTurmas { get; set; }
    }
}
