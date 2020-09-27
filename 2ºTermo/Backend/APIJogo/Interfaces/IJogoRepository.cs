using APIJogo.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJogo.Interfaces
{
    interface IJogoRepository
    {
        List<Jogo> ListarJogos();
        Jogo BuscarJogoId(Guid _idJogo);
        Jogo CadastrarJogo(Jogo _jogo);
        Jogo AlterarJogo(Jogo _jogo);
        void ExcluirJogo(Guid _idJogo);
    }
}
