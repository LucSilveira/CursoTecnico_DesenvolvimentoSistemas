using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Aluno;
using Carometro.Dominio.Queries.Turma;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Queries.AlunoTurma
{
    public class ListarAlunosTurmasQuery : Notifiable, IQuery
    {
        public void Validate()
        {
        }
    }

    public class ListarAlunosTurmasResult
    {
        public Guid Id { get; set; }
        public BuscarAlunoResult Aluno { get; set; }
        public BuscarTurmaResult Turma { get; set; }
        public string AnotacaoProfessor { get; set; }
    }
}
