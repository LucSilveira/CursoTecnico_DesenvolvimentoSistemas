using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Pacotes
{
    /// <summary>
    /// Classe reponsável pelo comando de alteração do objeto pacote
    /// </summary>
    public class AlterarStatusPacoteCommand : Notifiable, ICommand
    {
        /// <summary>
        /// Construtor do comando de alteração do status do objeto pacote
        /// </summary>
        /// <param name="idPacote">Código de identificação do próprio pacote</param>
        /// <param name="status">Status de ativação do pacote</param>
        public AlterarStatusPacoteCommand(Guid idPacote, bool status)
        {
            IdPacote = idPacote;
            Status = status;
        }

        /// <summary>
        /// Método de validação para alteração do status do objeto pacote
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdPacote, Guid.Empty, "IdPacote", "Id do pacote inválido")
            );
        }

        public Guid IdPacote { get; set; }
        public bool Status { get; set; }
    }
}
