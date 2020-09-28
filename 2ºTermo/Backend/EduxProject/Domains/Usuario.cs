using System;
using System.Collections.Generic;

namespace EduxProject.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            AlunoTurma = new HashSet<AlunoTurma>();
            Curtida = new HashSet<Curtida>();
            Dica = new HashSet<Dica>();
            ProfessorTurma = new HashSet<ProfessorTurma>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataUltimoAcesso { get; set; }
        public int? IdPerfil { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual ICollection<AlunoTurma> AlunoTurma { get; set; }
        public virtual ICollection<Curtida> Curtida { get; set; }
        public virtual ICollection<Dica> Dica { get; set; }
        public virtual ICollection<ProfessorTurma> ProfessorTurma { get; set; }
    }
}
