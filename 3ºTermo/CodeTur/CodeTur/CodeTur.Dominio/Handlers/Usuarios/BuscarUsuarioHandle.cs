using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Queries;
using CodeTur.Dominio.Domains;
using CodeTur.Dominio.Queries.Usuarios;
using CodeTur.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class BuscarUsuarioHandle : IHandlerQuery<BuscarUsuarioQuery>
    {
        // Injetando o nosso repositório de usuario
        private readonly IUsuarioRepository _repository;

        // Definindo que a classe 'BuscarUsuarioHandle' necessita do 'IUsuarioRepository' para existir
        public BuscarUsuarioHandle(IUsuarioRepository pacoteRepository)
        {
            _repository = pacoteRepository;
        }

        /// <summary>
        /// Método para validar os processos para buscar os usuários
        /// </summary>
        /// <param name="_query">Query de busca de usuário</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public IQueryResult Handle(BuscarUsuarioQuery _query)
        {
            //1º - Validando se a query recebida é válida
            _query.Validar();

            //2º - Verificando se o parametro de busca não é por e-mail
            if(_query.ParametroBuscaEmail != null)
            {
                    //Caso a query seja inválida, retornamos a mensagem de erro
                    if (_query.Invalid)
                    {
                        return new GenericQueryResult(false, "Dados inválidos", _query.Notifications);
                    }

                //3º - Verificando se o email de usuário não existe no banco de dados
                var _usuarioProcurado = _repository.BuscarUsuarioPorEmail(_query.ParametroBuscaEmail);

                    //Caso o usuário não exista, retornamos a mensagem de erro
                    if (_usuarioProcurado == null)
                    {
                        return new GenericQueryResult(false, "Usuário não encontrado, verifique que os dados informados", _query.ParametroBuscaEmail);
                    }

                //4º - Enviando a resposta da query para o nosso BuscarUsuarioQuery para filtrar os dados do nosso usuário
                var _usuarioResultEmail = new BuscarUsuarioResult()
                {
                    Id = _usuarioProcurado.Id,
                    Nome = _usuarioProcurado.Nome,
                    Email = _usuarioProcurado.Email,
                    Telefone = _usuarioProcurado.Telefone,
                    DataCriacao = _usuarioProcurado.DataCriacao,
                    QuantidadeComentarios = _usuarioProcurado.Comentarios != null ? _usuarioProcurado.Comentarios.Count() : 0,
                    Comentarios = _usuarioProcurado.Comentarios != null ? _usuarioProcurado.Comentarios.ToList() : null
                };

                //Retornando o objeto de usuário filtrado
                return new GenericQueryResult(true, "Dados do usuário", _usuarioResultEmail);
            }

            //3º - Buscando na nossa base de dados o objeto usuário por meio do Id
            var _usuario = _repository.BuscarUsuarioPorId(_query.ParametroBuscaId);

                //Caso o usuário não exista, retornamos a mensagem de erro
                if (_usuario == null)
                {
                    return new GenericQueryResult(false, "Usuário não encontrado, verifique que os dados informados", _query.ParametroBuscaId);
                }

            //4º - Enviando a resposta da query para o nosso BuscarPacoteQuery para filtrar os dados do nosso usuário
            var _usuarioResult = new BuscarUsuarioResult()
            {
                Id = _usuario.Id,
                Nome = _usuario.Nome,
                Email = _usuario.Email,
                Telefone = _usuario.Telefone,
                DataCriacao = _usuario.DataCriacao,
                QuantidadeComentarios = _usuario.Comentarios != null ? _usuario.Comentarios.Count() : 0,
                Comentarios = _usuario.Comentarios != null ? _usuario.Comentarios.ToList() : null
            };

            //Retornando o objeto de usuário filtrado
            return new GenericQueryResult(true, "Dados do usuário", _usuarioResult);
        }
    }
}
