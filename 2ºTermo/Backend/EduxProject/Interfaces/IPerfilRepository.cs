using EduxProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxProject.Interfaces
{
    public interface IPerfilRepository
    {
        Task<List<Perfils>> ListarPerfils();
        Task<Perfils> BuscarPerfilPorId(int _idPerfil);
        Task<Perfils> CadastrarPerfil(Perfils _perfil);
        Task<Perfils> AlterarPerfil(Perfils _perfil);
        Task<Perfils> ExcluirPerfil(Perfils _perfil);
    }
}
