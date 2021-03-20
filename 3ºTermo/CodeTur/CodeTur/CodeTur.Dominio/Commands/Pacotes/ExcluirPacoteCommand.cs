using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Pacotes
{
    public class ExcluirPacoteCommand : Notifiable, ICommand
    {
        /// <summary>
        /// Construtor do comando para excluir um pacote
        /// </summary>
        /// <param name="_idPacote">Código do pacote a ser excluido</param>
        public ExcluirPacoteCommand(Guid _idPacote)
        {
            IdPacote = _idPacote;
        }

        /// <summary>
        /// Método para validar os dados do pacote a ser excluido
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(IdPacote, Guid.Empty, "IdPacote", "Id do pacote inválido")
            );
        }

        public Guid IdPacote { get; set; }
    }
}
