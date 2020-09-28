using EduxProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxProject.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuarios>> ListarUsuarios();
        Task<Usuarios> BuscarUsuarioPorId(int _idUsuario);
        Task<Usuarios> CadastrarUsuario(Usuarios _usuario);
        Task<Usuarios> AlterarUsuario(Usuarios _usuario);
        Task<Usuarios> ExcluirUsuario(Usuarios _usuario);
    }
}
