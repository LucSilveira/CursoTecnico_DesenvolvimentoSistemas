using CodeTur.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Handlers.Contracts
{
    /// <summary>
    /// Classe responsável por criar um contrato para manilular nossas queries
    /// </summary>
    public interface IHandlerQuery<T> where T : IQuery
    { //Definindo um objeto anonimo que seja do padrão IQuery- para acessar os método da query

        /// <summary>
        /// Método para receber uma query e retornar um resultado para a operação
        /// </summary>
        /// <param name="_query">Query informado</param>
        /// <returns>Dados acerca do resultado da query</returns>
        IQueryResult Handle(T _query);
    }
}
