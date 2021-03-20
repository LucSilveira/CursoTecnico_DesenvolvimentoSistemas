using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Queries
{
    //Interface responsável por ser a classe 'pai' das nossas queries
    //passando o método de validar as queries que os herdarem
    public interface IQuery
    {
        /// <summary>
        /// Método generico para validação dos parametros caso sejam necessários para realizar nossas queries
        /// </summary>
        void Validar();
    }
}
