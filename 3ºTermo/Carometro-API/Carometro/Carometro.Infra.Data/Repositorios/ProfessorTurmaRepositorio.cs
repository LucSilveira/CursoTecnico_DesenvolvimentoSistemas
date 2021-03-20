using Carometro.Dominio.Entidades;
using Carometro.Dominio.Repositorios;
using Carometro.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Infra.Data.Repositorios
{
    public class ProfessorTurmaRepositorio : IProfessorTurmaRepositorio
    {
        private readonly CarometroContext _context;

        public ProfessorTurmaRepositorio(CarometroContext context)
        {
            _context = context;
        }

        public void AdicionarProfessorATurma(ProfessorTurma _professorTurma)
        {
            _context.ProfessoresTurmas.Add(_professorTurma);
            _context.SaveChanges();
        }

        public void AlterarProfessorTurma(ProfessorTurma _professorTurma)
        {
            _context.Entry(_professorTurma).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public ProfessorTurma BuscarProfessorTurmaPorId(Guid idProfessorTurma)
        {
            return _context.ProfessoresTurmas.FirstOrDefault(x => x.Id == idProfessorTurma);
        }

        public void ExcluirProfessorTurma(ProfessorTurma _professorTurma)
        {
            _context.ProfessoresTurmas.Remove(_professorTurma);
            _context.SaveChanges();
        }

        public IEnumerable<ProfessorTurma> ListarProfessoresDaTurma(Guid idTurma)
        {
            return _context.ProfessoresTurmas.AsNoTracking().Where(pft => pft.IdTurma == idTurma).ToList();
        }

        public IEnumerable<ProfessorTurma> ListarProfessoresTurmas()
        {
            return _context.ProfessoresTurmas.AsNoTracking().ToList();
        }

        public IEnumerable<ProfessorTurma> ListarTurmasDoProfessor(Guid idProfessor)
        {
            return _context.ProfessoresTurmas.AsNoTracking().Where(pft => pft.IdProfessor == idProfessor).ToList();
        }
    }
}
