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
    public class AlterarAlunoTurmaCommand : Notifiable, ICommand
    {
        public AlterarAlunoTurmaCommand(Guid id, Guid idAluno, Guid idTurma, string anotacaoProfessor)
        {
            Id = id;
            IdAluno = idAluno;
            IdTurma = idTurma;
            AnotacaoProfessor = anotacaoProfessor;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdAluno, Guid.Empty, "Id Aluno", "Informe o ID do aluno vinculado")
                .AreNotEquals(IdTurma, Guid.Empty, "Id Turma", "Informe o ID da turma vinculada")
            );
        }

        public Guid Id { get; set; }
        public Guid IdAluno { get; set; }
        public Guid IdTurma { get; set; }
        public string AnotacaoProfessor { get; set; }
    }
}
