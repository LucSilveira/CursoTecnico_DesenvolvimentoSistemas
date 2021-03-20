using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Queries
{
    /// <summary>
    /// Classe responsável por padronizar as respostas das nossas queries
    /// seguindo um padrão para identificar as ações desejadas, suas respostas e seus retornos
    /// </summary>
    public class GenericQueryResult : IQueryResult
    {
        /// <summary>
        /// Construtor responsável por padronizar as mensagens dos retornos das queries
        /// </summary>
        /// <param name="sucesso">Caso a query seja valida(realizada) ou falsa(não realizada)</param>
        /// <param name="mensagem">Mensagem de confirmação da ação e seus detalhes</param>
        /// <param name="data">Objeto de retorno da chamada</param>
        public GenericQueryResult(bool sucesso, string mensagem, object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
        public Object Data { get; private set; }
    }
}
