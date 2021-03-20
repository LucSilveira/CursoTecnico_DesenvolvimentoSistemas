using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Aluno;
using Carometro.Dominio.Queries.Turma;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Queries.AlunoTurma
{
    public class ListarTurmasDoAlunoQuery : Notifiable, IQuery
    {
        public ListarTurmasDoAlunoQuery(Guid idAluno)
        {
            IdAluno = idAluno;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdAluno, Guid.Empty, "Id aluno", "Informe o ID do aluno vinculado")
            );
        }

        public Guid IdAluno { get; set; }
    }

    public class ListaTurmasDoAlunoResult
    {
        public BuscarAlunoResult  Aluno { get; set; }
        public IEnumerable<ListarTurmaResult> Turmas { get; set; }
    }
}
