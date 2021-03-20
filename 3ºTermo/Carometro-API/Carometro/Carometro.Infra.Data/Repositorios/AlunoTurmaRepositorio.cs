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
    public class AlunoTurmaRepositorio : IAlunoTurmaRepositorio
    {
        private readonly CarometroContext _context;

        public AlunoTurmaRepositorio(CarometroContext context)
        {
            _context = context;
        }

        public void AdicionarAlunoATurma(AlunoTurma _alunoTurma)
        {
            _context.AlunosTurmas.Add(_alunoTurma);
            _context.SaveChanges();
        }

        public void AlterarAlunoTurma(AlunoTurma _alunoTurma)
        {
            _context.Entry(_alunoTurma).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public AlunoTurma BuscarAlunoTurmaPorId(Guid idAlunoTurma)
        {
            return _context.AlunosTurmas.FirstOrDefault(x => x.Id == idAlunoTurma);
        }

        public void ExcluirAlunoTurma(AlunoTurma _alunoTurma)
        {
            _context.AlunosTurmas.Remove(_alunoTurma);
            _context.SaveChanges();
        }

        public IEnumerable<AlunoTurma> ListarAlunosDaTurma(Guid idTurma)
        {
            return _context.AlunosTurmas.AsNoTracking().Where(pft => pft.IdTurma == idTurma).ToList();
        }

        public IEnumerable<AlunoTurma> ListarAlunosTurmas()
        {
            return _context.AlunosTurmas.AsNoTracking().ToList();
        }

        public IEnumerable<AlunoTurma> ListarTurmasDoAluno(Guid idAluno)
        {
            return _context.AlunosTurmas.AsNoTracking().Where(pft => pft.IdAluno == idAluno).ToList();
        }
    }
}
