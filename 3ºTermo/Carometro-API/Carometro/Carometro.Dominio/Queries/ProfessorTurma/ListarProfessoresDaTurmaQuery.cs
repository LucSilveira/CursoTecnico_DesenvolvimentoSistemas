using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Professor;
using Carometro.Dominio.Queries.Turma;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Queries.ProfessorTurma
{
    public class ListarProfessoresDaTurmaQuery : Notifiable, IQuery
    {
        public ListarProfessoresDaTurmaQuery(Guid idTurma)
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

    public class ListarProfessoresDaTurmaResult
    {
        public BuscarTurmaResult Turma { get; set; }
        public IEnumerable<ListarProfessorResult> Professores { get; set; }
    }
}
