using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Commands
{
    //Interface responsável por ser a classe 'pai' dos nossos comandos
    //passando o método de validar os comandos que os herdarem
    public interface ICommand
    {
        /// <summary>
        /// Método generico para validação dos parametros dos objetos, pegando
        /// os contratos mencionados nos dominios de cada objeto presente no sistema
        /// </summary>
        void Validar();
    }
}
