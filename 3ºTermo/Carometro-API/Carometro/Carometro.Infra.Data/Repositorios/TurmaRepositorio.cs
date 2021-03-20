using Carometro.Comum.Enum;
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
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private readonly CarometroContext _context;

        public TurmaRepositorio(CarometroContext context)
        {
             _context = context;
        }

        public Turma AdicionarTurma(Turma turma)
        {
            _context.Turmas.Add(turma);
            _context.SaveChanges();

            return turma;
        }

        public Turma AlterarTurma(Turma turma)
        {
            _context.Entry(turma).State = EntityState.Modified;
            _context.SaveChanges();

            return turma;
        }

        public Turma BuscarTurmaPorId(Guid idTurma)
        {
            return _context.Turmas.AsNoTracking().Include(hrr => hrr.Horarios).FirstOrDefault(tm => tm.Id == idTurma);
        }

        public Turma BuscarTurmaPorTitulo(string titulo)
        {
            return _context.Turmas.FirstOrDefault(tm => tm.Titulo == titulo);
        }

        public void ExcluirTurma(Turma turma)
        {
            if(turma.ProfessorTurma != null)
            {
                _context.ProfessoresTurmas.RemoveRange(_context.ProfessoresTurmas.Where(pft => pft.IdTurma == turma.Id));
            }

            _context.Horarios.RemoveRange(_context.Horarios.Where(hrr => hrr.IdTurma == turma.Id));

            _context.Remove(turma);
            _context.SaveChanges();
        }

        public IEnumerable<Turma> ListarTurmas()
        {
            return _context.Turmas.AsNoTracking().Include(hrr => hrr.Horarios).ToList();
        }

        public IEnumerable<Turma> ListarTurmasPorSemestre(EnSemestre semestre)
        {
            return _context.Turmas.AsNoTracking().Where(tm => tm.Semestre == semestre).ToList();
        }
    }
}
