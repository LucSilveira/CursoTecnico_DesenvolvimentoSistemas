using Carometro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Repositorios
{
    public interface IHorarioRepositorio
    {
        Horario AdicionarHorario(Horario horario);
        Horario AlterarHorario(Horario horario);
        Horario BuscarHorariPorId(Guid idHorario);
        IEnumerable<Horario> BuscarHorarioPorIdTurma(Guid idTurma);
    }
}
