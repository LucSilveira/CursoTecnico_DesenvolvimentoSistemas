using EduxProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxProject.Interfaces
{
    public interface ICurtidaRepository
    {
        Task<List<Curtidas>> ListarCurtidas();
        Task<Curtidas> BuscarCurtidaPorId(int _idCurtida);
        Task<Curtidas> CadastrarCurtida(Curtidas _curtida);
        Task<Curtidas> ExcluirCurtida(Curtidas _curtida);
    }
}
