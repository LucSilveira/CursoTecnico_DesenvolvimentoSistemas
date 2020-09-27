using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIJogo.Domains
{
    public class JogosJogadores : BaseDomain
    {
        [ForeignKey("IdJogador")]
        public Jogador Jogador { get; set; }
        public Guid IdJogador { get; set; }


        [ForeignKey("IdJogo")]
        public Jogo Jogo { get; set; }
        public Guid IdJogo { get; set; }
    }
}
