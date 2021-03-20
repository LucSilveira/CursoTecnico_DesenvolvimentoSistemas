using CodeTur.Comum.Commands;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuarios
{
    /// <summary>
    /// Classe responsável pelo comando de adição de um telefone ao objeto usuário
    /// </summary>
    public class AdicionarTelefoneCommand : Notifiable, ICommand
    {
        /// <summary>
        /// Construtor do comando de adição de um telefone ao usuário
        /// </summary>
        /// <param name="idUsuario">Código de identificação do próprio usuário</param>
        /// <param name="telefone">Telefone a ser cadastrado</param>
        public AdicionarTelefoneCommand(Guid idUsuario, string telefone)
        {
            IdUsuario = idUsuario;
            Telefone = telefone;
        }

        /// <summary>
        /// Método de validação dos parametros para alteração do objeto usuário
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Id do usuário inválido")
                .IsNewFormatCellPhone(Telefone, "Telefone", "Informe um telefone válido")
            );
        }

        public Guid IdUsuario { get; set; }
        public string Telefone { get; set; }
    }
}
