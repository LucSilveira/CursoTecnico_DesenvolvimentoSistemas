using Carometro.Comum.Enum;
using Carometro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Repositorios
{
    public interface ITurmaRepositorio
    {
        IEnumerable<Turma> ListarTurmas();
        IEnumerable<Turma> ListarTurmasPorSemestre(EnSemestre semestre);
        Turma BuscarTurmaPorTitulo(string titulo);
        Turma BuscarTurmaPorId(Guid idTurma);
        Turma AdicionarTurma(Turma turma);
        Turma AlterarTurma(Turma turma);
        void ExcluirTurma(Turma turma);
    }
}
