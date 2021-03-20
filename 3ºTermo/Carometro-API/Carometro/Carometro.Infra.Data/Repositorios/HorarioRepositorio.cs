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
    public class HorarioRepositorio : IHorarioRepositorio
    {
        private readonly CarometroContext _context;

        public HorarioRepositorio(CarometroContext context)
        {
            _context = context;
        }

        public Horario AdicionarHorario(Horario horario)
        {
            _context.Horarios.Add(horario);
            _context.SaveChanges();

            return horario;
        }

        public Horario AlterarHorario(Horario horario)
        {
            _context.Entry(horario).State = EntityState.Modified;
            _context.SaveChanges();

            return horario;
        }

        public Horario BuscarHorariPorId(Guid idHorario)
        {
            return _context.Horarios.FirstOrDefault(hrr => hrr.Id == idHorario);
        }

        public IEnumerable<Horario> BuscarHorarioPorIdTurma(Guid idTurma)
        {
            return _context.Horarios.AsNoTracking().Where(hrr => hrr.IdTurma == idTurma).ToList();
        }
    }
}
