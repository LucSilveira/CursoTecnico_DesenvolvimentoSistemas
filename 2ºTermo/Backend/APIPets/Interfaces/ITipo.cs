using APIPets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Interfaces
{
    interface ITipo
    {
        List<Tipo>  ListaTipos();
        Tipo ListarTipo(int _idTipo);
        Tipo CadastrarTipo(Tipo _tipo);
        Tipo AlterarTipo(Tipo _tipo, int _idTipo);
        void ExcluirTipo(int _idTipo);
    }
}
