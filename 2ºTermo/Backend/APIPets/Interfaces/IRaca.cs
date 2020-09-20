using APIPets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Interfaces
{
    interface IRaca
    {
        List<Raca> ListarRacas();
        Raca BuscarRaca(int _idRaca);
        Raca CadastrarRaca(Raca _raca);
        Raca AlterarRaca(Raca _raca, int _idRaca);
        void ExcluirRaca(int _idRaca);
    }
}
