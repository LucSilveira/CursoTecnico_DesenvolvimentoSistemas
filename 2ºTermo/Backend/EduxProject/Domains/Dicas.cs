using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EduxProject.Domains
{
    public partial class Dicas
    {
        public Dicas()
        {
            Curtidas = new HashSet<Curtidas>();
        }

        public int Id { get; set; }
        public string Texto { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile ArquivoDica { get; set; }
        public string Imagem { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Curtidas> Curtidas { get; set; }
    }
}
