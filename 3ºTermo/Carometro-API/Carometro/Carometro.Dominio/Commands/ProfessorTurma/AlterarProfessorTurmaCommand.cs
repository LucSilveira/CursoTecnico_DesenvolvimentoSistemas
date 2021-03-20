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
    public class AlterarProfessorTurmaCommand : Notifiable, ICommand
    {
        public AlterarProfessorTurmaCommand(Guid id, Guid idTurma, Guid idProfessor)
        {
            Id = id;
            IdTurma = idTurma;
            IdProfessor = idProfessor;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdProfessor, Guid.Empty, "Id Professor", "Informe o ID do professor vinculado")
                .AreNotEquals(IdTurma, Guid.Empty, "Id Turma", "Informe o ID da turma vinculada")
            );
        }

        public Guid Id { get; set; }
        public Guid IdTurma { get; set; }
        public Guid IdProfessor { get; set; }
    }
}
