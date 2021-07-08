using DoLink.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoLink.Dominio.Repositories
{
    public interface IMatchRepository
    {
        int VerificarNivelPreferencia(Profissional profissional, Vaga vaga);
        Task<List<Match>> ListaDeMatchsProfissional(string _idProfissional);
        Task<List<Match>> ListaDeMatchsVaga(string _idVaga);
        Task<Match> BuscarMatchEspecifico(string _idMatch);
        Task<Match> BuscarMatchPorVaga(string _idVaga);
        Task<Match> BuscarMatchPorProfissional(string _idProfissional);
        Task<Match> BuscarMatch(string _idProfissional, string _idVaga);
        Task<Match> CadastrarMatch(Match _match);
        Task<Match> ExcluirMatch(Match _match);
    }
}
