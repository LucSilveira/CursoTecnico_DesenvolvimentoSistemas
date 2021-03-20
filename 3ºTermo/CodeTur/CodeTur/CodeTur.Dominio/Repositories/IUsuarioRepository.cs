using CodeTur.Dominio.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Repositories
{
    /// <summary>
    /// Interface de usuário com os métodos contidos para os usuários
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Listar todos os usuários
        /// </summary>
        /// <returns>Lista de usuários do sistema</returns>
        IEnumerable<Usuario> ListarUsuarios();

        /// <summary>
        /// Buscar um usuário pelo email
        /// </summary>
        /// <param name="_email">Email de identificação do usuário</param>
        /// <returns>Dados a cerca do usuário procurado</returns>
        Usuario BuscarUsuarioPorEmail(string _email);

        /// <summary>
        /// Buscar um usuário pelo código de identificação
        /// </summary>
        /// <param name="_idUsuario">Código de idenficação do usuário</param>
        /// <returns>Dados a cerca do usuário procurado</returns>
        Usuario BuscarUsuarioPorId(Guid _idUsuario);

        /// <summary>
        /// Cadastrar um novo usuário
        /// </summary>
        /// <param name="_usuario">Dados do usuário informados</param>
        void AdicionarUsuario(Usuario _usuario);

        /// <summary>
        /// Alterar os dados de um usuário
        /// </summary>
        /// <param name="_usuario">Usuário com os dados alterados</param>
        void AlterarUsuario(Usuario _usuario);

        /// <summary>
        /// Excluir um usuário
        /// </summary>
        /// <param name="_usuario">Dados do usuário a serem deletadoss</param>
        void ExcluirUsuario(Usuario _usuario);
    }
}
