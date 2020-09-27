using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJogo.Domains
{
    public class Jogo : BaseDomain
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }

        public List<JogosJogadores> JogosJogadores { get; set; }

        public Jogo()
        {
            JogosJogadores = new List<JogosJogadores>();
        }
    }
}
