using CodeTur.Comum.Commands;
using CodeTur.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Comentarios
{
    /// <summary>
    /// Classe responsável pelo comando de alteração dos comentários
    /// </summary>
    public class AlterarComentarioCommand : Notifiable, ICommand
    {
        /// <summary>
        /// Construtor do comando de alteração do objeto comentário
        /// </summary>
        /// <param name="idComentario">Código de identificação do próprio comentário</param>
        /// <param name="idPacote">Código de ifentificação do pacote</param>
        /// <param name="texto">Texto alterado</param>
        /// <param name="sentimento">Novo sentimento identificado</param>
        /// <param name="status">Status de autorização do comentário alterado</param>
        public AlterarComentarioCommand(Guid idComentario, Guid idPacote,string texto, string sentimento, EnStatusComentario status)
        {
            IdComentario = idComentario;
            IdPacote = idPacote;
            Texto = texto;
            Sentimento = sentimento;
            Status = status;
        }

        /// <summary>
        /// Método de validação dos parametros para alteração do objeto comentário
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdComentario, Guid.Empty, "IdComentario", "O Id do comentário é inválido")
                .IsNotNullOrEmpty(Texto, "Texto", "Informe o texto do comentário")
                .HasMinLen(Texto, 20, "Texto", "O texto deve ter no mínimo 20 caracteres")
                .IsNotNullOrEmpty(Sentimento, "Sentimento", "Informe o sentimento do comentário")
                .AreNotEquals(IdPacote, Guid.Empty, "IdPacote", "Informe o ID do pacote do comentário")
            );
        }

        public Guid IdComentario { get; set; }
        public Guid IdPacote { get; set; }
        public string Texto { get; set; }
        public string Sentimento { get; set; }
        public EnStatusComentario Status { get; set; }
    }
}
