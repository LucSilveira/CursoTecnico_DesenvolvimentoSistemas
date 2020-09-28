using System;
using System.Collections.Generic;

namespace EduxProject.Domains
{
    public partial class AlunosTurmas
    {
        public AlunosTurmas()
        {
            ObjetivosAlunos = new HashSet<ObjetivosAlunos>();
        }

        public int Id { get; set; }
        public string Matricula { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTurma { get; set; }

        public virtual Turmas IdTurmaNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<ObjetivosAlunos> ObjetivosAlunos { get; set; }
    }
}
