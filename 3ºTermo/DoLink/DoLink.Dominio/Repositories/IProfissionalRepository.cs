using DoLink.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoLink.Dominio.Repositories
{
    public interface IProfissionalRepository
    {
        Task<List<Profissional>> ListarProfissional();
        Task<Profissional> BuscarProfissional(string _cpfProfissional);
        Task<Profissional> BuscarEmailProfissional(string _emailProfissional);
        Task<Profissional> BuscarProfissionalEspecifico(string _idProfissional);
        Task<Profissional> CadastrarProfissional(Profissional _profissional);
        Task<Profissional> AlterarProfissional(Profissional _profissional);
        Task<Profissional> ExcluirProfissional(Profissional _profissional);
    }
}
