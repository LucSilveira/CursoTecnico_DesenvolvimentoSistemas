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
    /// Classe para definir os comandos de criação dos nossos comentários
    /// </summary>
    public class CriarComentarioCommand : Notifiable, ICommand
    {
        /// <summary>
        /// Construtor de comando para criação do objeto comentário
        /// </summary>
        /// <param name="texto">Texto do comentário</param>
        /// <param name="sentimento">Sentimento identificado no comentário</param>
        /// <param name="status">Status de aprovação do comentároio</param>
        /// <param name="idUsuario">Código de identificação do usuário</param>
        /// <param name="idPacote">Código de identificação do pacote</param>
        public CriarComentarioCommand(string texto, string sentimento, EnStatusComentario status, Guid idUsuario, Guid idPacote)
        {
            Texto = texto;
            Sentimento = sentimento;
            Status = status;
            IdUsuario = idUsuario;
            IdPacote = idPacote;
        }

        /// <summary>
        /// Método de validação dos parametros do objeto comentário
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Texto, "Texto", "Informe o texto do comentário")
                .HasMinLen(Texto, 20, "Texto", "O texto deve ter no mínimo 20 caracteres")
                .IsNotNullOrEmpty(Sentimento, "Sentimento", "Informe o sentimento do comentário")
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Informe o ID do usuário do comentário")
                .AreNotEquals(IdPacote, Guid.Empty, "IdPacote", "Informe o ID do pacote do comentário")
            );
        }

        public string Texto { get; set; }
        public string Sentimento { get; set; }
        public EnStatusComentario Status { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdPacote { get; set; }
    }
}
