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
    /// Classe reponsável pelo comando de alterar o objeto comentário
    /// </summary>
    public class AlterarStatusComentarioCommand : Notifiable, ICommand
    {
        /// <summary>
        /// Construtor do comando de alteração do objeto comentário
        /// </summary>
        /// <param name="idComentario">Código de identificação do próprio comentário</param>
        /// <param name="status">Status de autorização do comentário</param>
        public AlterarStatusComentarioCommand(Guid idComentario, EnStatusComentario status)
        {
            IdComentario = idComentario;
            Status = status;
        }

        /// <summary>
        /// Método de validação dos parametros para alterar o objeto comentário
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdComentario, Guid.Empty, "IdComentario", "Id do comentário inválido")
            );
        }

        public Guid IdComentario { get; set; }
        public EnStatusComentario Status { get; set; }
    }
}
