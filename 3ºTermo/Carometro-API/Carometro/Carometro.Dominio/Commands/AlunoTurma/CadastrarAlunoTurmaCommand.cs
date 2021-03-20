using Carometro.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.AlunoTurma
{
    public class CadastrarAlunoTurmaCommand : Notifiable, ICommand
    {
        public CadastrarAlunoTurmaCommand(Guid idAluno, Guid idTurma, string anotacaoProfessor)
        {
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

        public Guid IdAluno { get; set; }
        public Guid IdTurma { get; set; }
        public string AnotacaoProfessor { get; set; }
    }
}
