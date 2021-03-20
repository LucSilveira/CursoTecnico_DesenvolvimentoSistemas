using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Pacotes
{
    /// <summary>
    /// Classe reponsável pelo comando de alterar do pacote
    /// </summary>
    public class AlterarImagemPacoteCommand : Notifiable, ICommand
    {
        public AlterarImagemPacoteCommand()
        {

        }

        /// <summary>
        /// Construtor do comando de alteração da imagem do objeto pacote
        /// </summary>
        /// <param name="idPacote">Código de identificação do próprio pacote</param>
        /// <param name="imagem">Imagem a ser adicionada ao pacote</param>
        public AlterarImagemPacoteCommand(Guid idPacote, string imagem)
        {
            IdPacote = idPacote;
            Imagem = imagem;
            DataAlteracao = DateTime.Now;
        }

        /// <summary>
        /// Método de velidação dos parametros para alteração do objeto pacote
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdPacote, Guid.Empty, "IdPacote", "Id do pacote inválido")
                .IsNotNullOrEmpty(Imagem, "Imagem", "Informe uma imagem ao pacote")
            );
        }

        public Guid IdPacote { get; set; }
        public IFormFile Arquivo { get; set; }
        public string Imagem { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
