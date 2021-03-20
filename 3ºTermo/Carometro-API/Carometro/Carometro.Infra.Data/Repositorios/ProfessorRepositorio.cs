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
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly CarometroContext _context;

        public ProfessorRepositorio(CarometroContext contexto)
        {
            _context = contexto;
        }

        public void AdicionarProfessor(Professor _professor)
        {
            _context.Professores.Add(_professor);
            _context.SaveChanges();
        }

        public void AlterarProfessor(Professor _professor)
        {
            _context.Entry(_professor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Professor BuscarProfessorPorEmail(string _email)
        {
            return _context.Professores.FirstOrDefault(prf => prf.Email.ToLower() == _email.ToLower());
        }

        public Professor BuscarProfessorPorId(Guid _idProfessor)
        {
            return _context.Professores.FirstOrDefault(prf => prf.Id == _idProfessor);
        }

        public void ExcluirProfessor(Professor _professor)
        {
            if(_professor.ProfessorTurma != null)
            {
                _context.ProfessoresTurmas.RemoveRange(_context.ProfessoresTurmas.Where(pft => pft.IdProfessor == _professor.Id));
            }

            _context.Remove(_professor);
            _context.SaveChanges();
        }

        public IEnumerable<Professor> ListarProfessores()
        {
            return _context.Professores.AsNoTracking().OrderBy( prf => prf.DataCriacao ).ToList();
        }
    }
}
