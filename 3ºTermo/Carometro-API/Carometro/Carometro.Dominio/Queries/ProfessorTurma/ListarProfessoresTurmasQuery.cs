using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Professor;
using Carometro.Dominio.Queries.Turma;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Queries.ProfessorTurma
{
    public class ListarProfessoresTurmasQuery : Notifiable, IQuery
    {
        public void Validate()
        {
        }
    }

    public class ListarProfessoresTurmasResult
    {
        public Guid Id { get; set; }
        public BuscarProfessorResult Professor { get; set; }
        public BuscarTurmaResult Turma { get; set; }
    }
}