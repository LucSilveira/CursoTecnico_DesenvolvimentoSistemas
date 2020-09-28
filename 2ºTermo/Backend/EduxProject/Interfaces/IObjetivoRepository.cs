using EduxProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxProject.Interfaces
{
    public interface IObjetivoRepository
    {
        Task<List<Objetivos>> ListarObjetivos();
        Task<Objetivos> BuscarObjetivoPorId(int _idObjetivo);
        Task<Objetivos> CadastrarObjetivo(Objetivos _objetivo);
        Task<Objetivos> AlterarObjetivo(Objetivos _objetivo);
        Task<Objetivos> ExcluirIbjetivo(Objetivos _objetivo);
    }
}
