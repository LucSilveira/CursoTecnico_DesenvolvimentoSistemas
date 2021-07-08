using DoLink.Comum.Enum;
using DoLink.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoLink.Dominio.Repositories
{
    public interface IVagaRepository
    {
        Task<List<Vaga>> ListarVaga();
        Task<List<Vaga>> ListarVagaEmpresa(string _idEmpresa);
        Task<List<Vaga>> ListarVagaPorStatus(EnStatusVaga status);
        Task<List<Vaga>> Prematch(Profissional _profissional);
        Task<List<Vaga>> BuscarPorTitulo(string titulo);
        Task<Vaga> BuscarDadosVaga(string _idVaga);
        Task<Vaga> CadastrarVaga(Vaga _vaga);
        Task<Vaga> AlterarVagaRepositorie(string id, Vaga _vaga);
        Task<Vaga> ExcluirVaga(Vaga vaga);
    }
}
