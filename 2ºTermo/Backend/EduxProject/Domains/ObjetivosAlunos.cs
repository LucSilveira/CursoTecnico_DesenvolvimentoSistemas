using System;
using System.Collections.Generic;

namespace EduxProject.Domains
{
    public partial class ObjetivosAlunos
    {
        public int Id { get; set; }
        public decimal? Nota { get; set; }
        public DateTime? DataAlcancado { get; set; }
        public int? IdAlunoTurma { get; set; }
        public int? IdObjetivo { get; set; }

        public virtual AlunosTurmas IdAlunoTurmaNavigation { get; set; }
        public virtual Objetivos IdObjetivoNavigation { get; set; }
    }
}
