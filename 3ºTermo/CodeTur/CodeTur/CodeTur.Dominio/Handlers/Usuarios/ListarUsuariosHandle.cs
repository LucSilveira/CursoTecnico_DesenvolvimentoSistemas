using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Queries;
using CodeTur.Dominio.Queries.Usuarios;
using CodeTur.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class ListarUsuariosHandle : IHandlerQuery<ListarUsuariosQuery>
    {
        // Injetando o nosso repositório de usuario
        private readonly IUsuarioRepository _repository;

        // Definindo que a classe 'ListarUsuarioHandle' necessita do 'IUsuarioRepository' para existir
        public ListarUsuariosHandle(IUsuarioRepository pacoteRepository)
        {
            _repository = pacoteRepository;
        }

        /// <summary>
        /// Método para validar os processos para listar os usuários
        /// </summary>
        /// <param name="_query">Query de listagem dos usuários</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public IQueryResult Handle(ListarUsuariosQuery _query)
        {

            //1º - Buscando a lista com os usuarios criados no banco de dados
            var _usuarios = _repository.ListarUsuarios();

            //2º - Filtrando os dados dos objetos contidos na lista de usuarios
            var _usuariosResult = _usuarios.Select(usr =>
            {
                return new ListarUsuarioResult()
                {
                    Id = usr.Id,
                    Nome = usr.Nome,
                    Email = usr.Email,
                    Telefone = usr.Telefone,
                    DataCriacao = usr.DataCriacao,
                    QuantidadeComentarios = usr.Comentarios.Count
                };
            });

            //Retornando a resposta de sucesso e a nossa lista
            return new GenericQueryResult(true, "Usuarios", _usuariosResult);
        }
    }
}
