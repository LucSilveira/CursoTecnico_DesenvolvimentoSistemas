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
    public class ListarPacotesHandle : IHandlerQuery<ListarPacotesQuery>
    {
        // Injetando o nosso repositório de pacote
        private readonly IPacoteRepository _repository;

        // Definindo que a classe 'ListarPacoteHandle' necessita do 'IPacoteRepository' para existir
        public ListarPacotesHandle(IPacoteRepository pacoteRepository)
        {
            _repository = pacoteRepository;
        }

        /// <summary>
        /// Método para validar os processos para listar os pacote
        /// </summary>
        /// <param name="_query">Query de listagem dos pacotes</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public IQueryResult Handle(ListarPacotesQuery _query)
        {
            //1º - Buscando os pacotes na nossa base de dados
            var _pacotes = _repository.ListarPacotes(_query.Ativo);

            //2º - Enviando a resposta da query para a nossa ListarPacotesResult para filtrar os dados da nossa lista
            var _pacotesResult = _pacotes.Select(pct =>
            {
               return new ListarPacotesResult()
               {
                   Id = pct.Id,
                   Titulo = pct.Titulo,
                   Descricao = pct.Descricao,
                   Imagem = pct.Imagem,
                   Ativo = pct.Ativo,
                   DataCriacao = pct.DataCriacao,
                   QuantidadeComentarios = pct.Comentarios.Count
               };
            });

            //Retornando o objeto de pacote filtrado
            return new GenericQueryResult(true, "Pacotes", _pacotesResult);
        }
    }
}
