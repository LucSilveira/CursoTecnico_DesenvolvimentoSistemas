using Carometro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Repositorios
{
    public interface IProfessorTurmaRepositorio
    {
        IEnumerable<ProfessorTurma> ListarProfessoresTurmas();
        IEnumerable<ProfessorTurma> ListarProfessoresDaTurma(Guid idTurma);
        IEnumerable<ProfessorTurma> ListarTurmasDoProfessor(Guid idProfessor);
        ProfessorTurma BuscarProfessorTurmaPorId(Guid idProfessorTurma);
        void AdicionarProfessorATurma(ProfessorTurma _professorTurma);
        void AlterarProfessorTurma(ProfessorTurma _professorTurma);
        void ExcluirProfessorTurma(ProfessorTurma _professorTurma);
    }
}
