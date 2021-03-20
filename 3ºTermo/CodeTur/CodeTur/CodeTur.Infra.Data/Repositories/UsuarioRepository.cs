using CodeTur.Dominio.Domains;
using CodeTur.Dominio.Repositories;
using CodeTur.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //Definindo a chamada do context do banco de dados
        private readonly CodeTurContext _context;

        //Definindo que os métodos da classe, vão exigir nosso contexto
        public UsuarioRepository(CodeTurContext _codeTurContext)
        {
            _context = _codeTurContext;
        }

        /// <summary>
        /// Método para listar os usuários armazenados no banco de dados
        /// </summary>
        /// <returns>Lista com todos os usuários do sistema</returns>
        public IEnumerable<Usuario> ListarUsuarios()
        {
            return _context.Usuarios.AsNoTracking().Include(usr => usr.Comentarios)
                                        .OrderBy(usr => usr.DataCriacao).ToList();
        }

        /// <summary>
        /// Método para buscar um usuário cadastrado através do seu email
        /// </summary>
        /// <param name="_email">Email pertencente ao usuário</param>
        /// <returns>Dados a cerca do usuário procurado</returns>
        public Usuario BuscarUsuarioPorEmail(string _email)
        {
            return _context.Usuarios.FirstOrDefault(usr => usr.Email.ToLower() == _email.ToLower());
        }

        /// <summary>
        /// Método para buscar um usuário cadastrado através do seu id
        /// </summary>
        /// <param name="_idUsuario">Código de identificação do usuário</param>
        /// <returns>Dados a cerca do usuário procurado</returns>
        public Usuario BuscarUsuarioPorId(Guid _idUsuario)
        {
            return _context.Usuarios.FirstOrDefault(usr => usr.Id == _idUsuario);
        }

        /// <summary>
        /// Método para adicionar um usuário ao nosso sistema
        /// </summary>
        /// <param name="_usuario">Dados do usuário a serem cadastrados</param>
        public void AdicionarUsuario(Usuario _usuario)
        {
            _context.Usuarios.Add(_usuario);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para alterar os dados de um usuário cadastrado
        /// </summary>
        /// <param name="_usuario">Dados a serem alterados do usuário</param>
        public void AlterarUsuario(Usuario _usuario)
        {
            _context.Entry(_usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para excluir os dados pertencentes a um usuário
        /// </summary>
        /// <param name="_usuario">Dados do usuário excluido</param>
        public void ExcluirUsuario(Usuario _usuario)
        {
            if(_usuario.Comentarios != null)
            {
                _context.Comentarios.RemoveRange(_context.Comentarios.Where(cmt => cmt.IdUsuario == _usuario.Id));
            }

            _context.Remove(_usuario);
            _context.SaveChanges();
        }
    }
}
