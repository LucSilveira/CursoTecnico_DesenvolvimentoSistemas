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
    public class ListarTurmasDoProfessorQuery : Notifiable, IQuery
    {
        public ListarTurmasDoProfessorQuery(Guid idProfessor)
        {
            IdProfessor = idProfessor;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdProfessor, Guid.Empty, "Id Professor", "Informe o ID do Professor vinculado")
            );
        }

        public Guid IdProfessor { get; set; }
    }

    public class ListaTurmasDoProfessorResult
    {
        public BuscarProfessorResult Professor { get; set; }
        public IEnumerable<ListarTurmaResult> Turmas { get; set; }
    }
}
