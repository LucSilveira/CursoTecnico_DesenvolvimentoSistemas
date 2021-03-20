using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Turma;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Carometro.Dominio.Queries.Aluno.ListarAlunoQuery;

namespace Carometro.Dominio.Queries.AlunoTurma
{
    public class ListarAlunosDaTurmaQuery : Notifiable, IQuery
    {
        public ListarAlunosDaTurmaQuery(Guid idTurma)
        {
            IdTurma = idTurma;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdTurma, Guid.Empty, "Id Turma", "Informe o ID da turma vinculada")
            );
        }

        public Guid IdTurma { get; set; }
    }

    public class ListarAlunosDaTurmaResult
    {
        public BuscarTurmaResult Turma { get; set; }
        public IEnumerable<ListarQueryResult> Alunos { get; set; }
    }
}
