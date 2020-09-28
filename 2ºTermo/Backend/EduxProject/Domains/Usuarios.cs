using System;
using System.Collections.Generic;

namespace EduxProject.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            AlunosTurmas = new HashSet<AlunosTurmas>();
            Curtidas = new HashSet<Curtidas>();
            Dicas = new HashSet<Dicas>();
            ProfessoresTurmas = new HashSet<ProfessoresTurmas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataUltimoAcesso { get; set; }
        public int? IdPerfil { get; set; }

        public virtual Perfils IdPerfilNavigation { get; set; }
        public virtual ICollection<AlunosTurmas> AlunosTurmas { get; set; }
        public virtual ICollection<Curtidas> Curtidas { get; set; }
        public virtual ICollection<Dicas> Dicas { get; set; }
        public virtual ICollection<ProfessoresTurmas> ProfessoresTurmas { get; set; }
    }
}
