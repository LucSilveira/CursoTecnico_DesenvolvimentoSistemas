using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Queries;
using CodeTur.Dominio.Queries.Pacotes;
using CodeTur.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class BuscarPacoteHandle : IHandlerQuery<BuscarPacoteQuery>
    {
        // Injetando o nosso repositório de pacote
        private readonly IPacoteRepository _repository;

        // Definindo que a classe 'BuscarPacoteHandle' necessita do 'IPacoteRepository' para existir
        public BuscarPacoteHandle(IPacoteRepository pacoteRepository)
        {
            _repository = pacoteRepository;
        }

        /// <summary>
        /// Método para validar os processos para buscar os pacotes
        /// </summary>
        /// <param name="_query">Query de busca de pacotes</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public IQueryResult Handle(BuscarPacoteQuery _query)
        {
            //1º - Validando se a query recebida é válida
            _query.Validar();

            //2º - Verificando se o parametro de busca não é por titulo
            if(_query.ParametroBuscaTitulo != null)
            {
                    //Caso a query seja inválida, retornamos a mensagem de erro
                    if (_query.Invalid)
                    {
                        return new GenericQueryResult(false, "Dados inválidos", _query.Notifications);
                    }

                //3º - Verificando se o email de usuário não existe no banco de dados
                var _pacoteProcurado = _repository.BuscarPacotePorTitulo(_query.ParametroBuscaTitulo);

                    //Caso o usuário não exista, retornamos a mensagem de erro
                    if (_pacoteProcurado == null)
                    {
                        return new GenericQueryResult(false, "Pacote não encontrado, verifique que os dados informados", _query.ParametroBuscaTitulo);
                    }

                //4º - Enviando a resposta da query para o nosso BuscarPacoteQuery para filtrar os dados do nosso pacote
                var _pacoteResultTitulo = new BuscarPacoteResult()
                {
                    Id = _pacoteProcurado.Id,
                    Titulo = _pacoteProcurado.Titulo,
                    Descricao = _pacoteProcurado.Descricao,
                    Imagem = _pacoteProcurado.Imagem,
                    DataCriacao = _pacoteProcurado.DataCriacao,
                    QuantidadeComentarios = _pacoteProcurado.Comentarios != null ? _pacoteProcurado.Comentarios.Count() : 0,
                    Comentarios = _pacoteProcurado.Comentarios != null ? _pacoteProcurado.Comentarios.ToList() : null
                };

                //Retornando o objeto pacote filtrado
                return new GenericQueryResult(true, "Dados do pacote", _pacoteResultTitulo);
            }

            //3º - Buscando na nossa base de dados o objeto usuário por meio do Id
            var _pacote = _repository.BuscarPacotePorId(_query.ParametroBuscaId);

                //Caso o usuário não exista, retornamos a mensagem de erro
                if (_pacote == null)
                {
                    return new GenericQueryResult(false, "Pacote não encontrado, verifique que os dados informados", _query.ParametroBuscaId);
                }

            //4º - Enviando a resposta da query para o nosso BuscarPacoteQuery para filtrar os dados do nosso pacote
            var _pacoteResult = new BuscarPacoteResult()
            {
                Id = _pacote.Id,
                Titulo = _pacote.Titulo,
                Descricao = _pacote.Descricao,
                Imagem = _pacote.Imagem,
                DataCriacao = _pacote.DataCriacao,
                QuantidadeComentarios = _pacote.Comentarios != null ? _pacote.Comentarios.Count() : 0,
                Comentarios = _pacote.Comentarios != null ? _pacote.Comentarios.ToList() : null
            };

            //Retornando o objeto pacote filtrado
            return new GenericQueryResult(true, "Dados do pacote", _pacoteResult);
        }
    }
}
