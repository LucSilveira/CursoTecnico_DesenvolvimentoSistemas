using CodeTur.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Handlers.Contracts
{
    /// <summary>
    /// Classe responsável por criar um contrato para manilular nossos commands
    /// </summary>
    public interface IHandlerCommand<T> where T : ICommand
    { //Definindo um objeto anonimo que seja do padrão ICommand - para acessar os método do command
        
        /// <summary>
        /// Método para receber um command e retornar um resultado para a operação
        /// </summary>
        /// <param name="_command">Command informado</param>
        /// <returns>Dados acerca do resultado do comando</returns>
        ICommandResult Handle(T _command);
    }
}
