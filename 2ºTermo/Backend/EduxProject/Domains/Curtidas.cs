using System;
using System.Collections.Generic;

namespace EduxProject.Domains
{
    public partial class Curtidas
    {
        public int Id { get; set; }
        public int? IdDica { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Dicas IdDicaNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
