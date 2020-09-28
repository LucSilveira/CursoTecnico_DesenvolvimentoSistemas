using EduxProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxProject.Interfaces
{
    public interface ITurmaRepository
    {
        Task<List<Turmas>> ListarTurmas();
        Task<Turmas> BuscarTurmaPorId(int _idTurma);
        Task<Turmas> CadastrarTurma(Turmas _turma);
        Task<Turmas> AlterarTurma(Turmas _turma);
        Task<Turmas> ExcluirTurma(Turmas _turma);
    }
}
