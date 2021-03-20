using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Commands
{
    /// <summary>
    /// Classe responsável por padronizar as respostas dos nossos comandos
    /// seguindo um padrão para identificar as ações desejadas, suas respostas e seus retornos
    /// </summary>
    public class GenericCommandResult : ICommandResult
    {
        /// <summary>
        /// Construtor responsável por padronizar as mensagens dos retornos dos comandos
        /// </summary>
        /// <param name="sucesso">Caso o comando seja valido(realizado) ou falso(não realizado)</param>
        /// <param name="mensagem">Mensagem de confirmação da ação e seus detalhes</param>
        /// <param name="data">Objeto de retorno da chamada</param>
        public GenericCommandResult(bool sucesso, string mensagem, object data)
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
