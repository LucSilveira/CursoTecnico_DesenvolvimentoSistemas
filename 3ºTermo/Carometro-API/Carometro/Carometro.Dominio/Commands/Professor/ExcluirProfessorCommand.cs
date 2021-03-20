using Carometro.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.Professor
{
    public class ExcluirProfessorCommand : Notifiable, ICommand
    {
        public ExcluirProfessorCommand(Guid id)
        {
            Id = id;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(Id, Guid.Empty, "IdUsuario", "Id do usuário inválido")
            );
        }

        public Guid Id { get; set; }
    }
}
