using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJogo.Domains
{
    public class Jogador : BaseDomain
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }

        public List<JogosJogadores> JogosJogadores { get; set; }

        public Jogador()
        {
            JogosJogadores = new List<JogosJogadores>();
        }
    }
}
