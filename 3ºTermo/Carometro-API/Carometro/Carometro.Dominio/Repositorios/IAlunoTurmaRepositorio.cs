using Carometro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Repositorios
{
    public interface IAlunoTurmaRepositorio
    {
        IEnumerable<AlunoTurma> ListarAlunosTurmas();
        IEnumerable<AlunoTurma> ListarAlunosDaTurma(Guid idTurma);
        IEnumerable<AlunoTurma> ListarTurmasDoAluno(Guid idAluno);
        AlunoTurma BuscarAlunoTurmaPorId(Guid idAlunoTurma);
        void AdicionarAlunoATurma(AlunoTurma _alunoTurma);
        void AlterarAlunoTurma(AlunoTurma _alunoTurma);
        void ExcluirAlunoTurma(AlunoTurma _alunoTurma);
    }
}
