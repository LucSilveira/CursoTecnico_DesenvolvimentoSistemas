using EduxProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxProject.Interfaces
{
    public interface IDicaRepository
    {
        Task<List<Dicas>> ListarDicas();
        Task<Dicas> BuscarDicaPorId(int _idDica);
        Task<Dicas> CadastrarDica(Dicas _dica);
        Task<Dicas> AlterarDica(Dicas _dica);
        Task<Dicas> ExcluirDica(Dicas _dica);
    }
}
