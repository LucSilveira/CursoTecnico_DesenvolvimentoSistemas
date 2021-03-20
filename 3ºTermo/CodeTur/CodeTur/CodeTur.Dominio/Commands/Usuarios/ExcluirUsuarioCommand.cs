using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuarios
{
    public class ExcluirUsuarioCommand : Notifiable, ICommand
    {
        /// <summary>
        /// Construtor responsável pela recepção do id do usuário para o excluir
        /// </summary>
        /// <param name="_idUsuario">Código de identificação do usuário</param>
        public ExcluirUsuarioCommand(Guid _idUsuario)
        {
            IdUsuario = _idUsuario;
        }

        /// <summary>
        /// Método para validar os parametros do id
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Id do usuário inválido")
            );
        }

        public Guid IdUsuario { get; set; }
    }
}
