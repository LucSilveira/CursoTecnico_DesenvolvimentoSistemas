using EduxProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxProject.Interfaces
{
    public interface IInstituicaoRepository
    {
        Task<List<Instituicoes>> ListarInstituicoes();
        Task<Instituicoes> BuscarInstituicaoPorId(int _idInstituicao);
        Task<Instituicoes> CadastrarInstituicao(Instituicoes _instituicao);
        Task<Instituicoes> AlterarInstituicao(Instituicoes _instituicao);
        Task<Instituicoes> ExcluirInstituicao(Instituicoes _instituicao);
    }
}
