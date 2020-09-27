using APIJogo.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJogo.Interfaces
{
    interface IJogadorRepository
    {
        List<Jogador> ListarJogadores();
        Jogador BuscarJogadorId(Guid _idJogador);
        Jogador CadastrarJogador(Jogador _jogador);
        void ExcluirJogador(Guid _idJogador);
    }
}
