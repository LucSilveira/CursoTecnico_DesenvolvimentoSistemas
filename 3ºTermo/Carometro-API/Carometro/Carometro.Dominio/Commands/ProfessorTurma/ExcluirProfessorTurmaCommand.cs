using Carometro.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.ProfessorTurma
{
    public class ExcluirProfessorTurmaCommand : Notifiable, ICommand
    {
        public ExcluirProfessorTurmaCommand(Guid id)
        {
            Id = id;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id do professor turma", "Informe o ID do professor turma vinculado")
            );
        }

        public Guid Id { get; set; }
    }
}
