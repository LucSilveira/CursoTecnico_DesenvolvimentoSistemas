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
    public class BuscarAlunoTurmaQuery : Notifiable, IQuery
    {
        public BuscarAlunoTurmaQuery(Guid id)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id do aluno turma", "Informe o ID do aluno turma vinculado")
            );
        }

        public Guid Id { get; set; }
    }

    public class BuscarAlunoTurmaResult
    {
        public Guid Id { get; set; }
        public BuscarAlunoResult Aluno { get; set; }
        public BuscarTurmaResult Turma { get; set; }
        public string Anotacao { get; set; }
    }
}
