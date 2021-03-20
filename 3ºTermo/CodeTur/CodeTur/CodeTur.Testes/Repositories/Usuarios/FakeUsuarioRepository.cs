using CodeTur.Comum.Enum;
using CodeTur.Dominio.Domains;
using CodeTur.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Testes.Repositories.Usuarios
{
    /// <summary>
    /// Criando um repositorio false de usuário para testar nossos métodos do handle
    /// </summary>
    public class FakeUsuarioRepository : IUsuarioRepository
    {

        List<Usuario> _listUsuarios = new List<Usuario>()
            {
                new Usuario("Fernando Guerra", "email@email.com", "+551162553590", EnTipoPerfil.Comum),
                new Usuario("Priscila Medeiro", "email2@email.com", "+551162553590", EnTipoPerfil.Comum)
            };

        public void AdicionarUsuario(Usuario _usuario)
        {
            _listUsuarios.Add(_usuario);
        }

        public void AlterarSenha(Usuario _usuario)
        {

        }

        public void AlterarUsuario(Usuario _usuario)
        {
            
        }

        public Usuario BuscarUsuarioPorEmail(string _email)
        {
            return _listUsuarios.FirstOrDefault(usr => usr.Email == _email);
        }

        public Usuario BuscarUsuarioPorId(Guid _idUsuario)
        {
            return _listUsuarios.FirstOrDefault(usr => usr.Id == _idUsuario);
        }

        public IEnumerable<Usuario> ListarUsuarios()
        {
            return _listUsuarios;
        }
    }
}
