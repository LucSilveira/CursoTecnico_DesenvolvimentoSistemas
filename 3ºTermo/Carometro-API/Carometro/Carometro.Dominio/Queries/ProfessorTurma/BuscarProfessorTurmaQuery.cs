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
    public class BuscarProfessorTurmaQuery : Notifiable, IQuery
    {
        public BuscarProfessorTurmaQuery(Guid id)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id do Professor turma", "Informe o ID do Professor turma vinculado")
            );
        }

        public Guid Id { get; set; }
    }

    public class BuscarProfessorTurmaResult
    {
        public Guid Id { get; set; }
        public BuscarProfessorResult Professor { get; set; }
        public BuscarTurmaResult Turma { get; set; }
        public string Anotacao { get; set; }
    }
}