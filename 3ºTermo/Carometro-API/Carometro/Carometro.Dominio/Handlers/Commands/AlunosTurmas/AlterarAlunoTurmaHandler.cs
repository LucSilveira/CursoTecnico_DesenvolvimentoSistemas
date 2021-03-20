using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.AlunoTurma;
using Carometro.Dominio.Commands.ProfessorTurma;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.AlunosTurmas
{
    public class AlterarAlunoTurmaHandler : IHandler<AlterarAlunoTurmaCommand>
    {
        private readonly IAlunoTurmaRepositorio _repositorio;

        private readonly IAlunoRepositorio _repositorioAluno;

        private readonly ITurmaRepositorio _repositorioTurma;

        public AlterarAlunoTurmaHandler(IAlunoTurmaRepositorio repositorio, IAlunoRepositorio repositorioAluno, ITurmaRepositorio repositorioTurma)
        {
            _repositorio = repositorio;
            _repositorioAluno = repositorioAluno;
            _repositorioTurma = repositorioTurma;
        }

        public ICommandResult Handler(AlterarAlunoTurmaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            var AlunoTurma = _repositorio.BuscarAlunoTurmaPorId(command.Id);

            if (AlunoTurma == null)
                return new GenericCommandResult(true, "Turma do Aluno não encontrada", null);

            var Aluno = _repositorioAluno.BuscarPorId(command.IdAluno);

            if (Aluno == null)
                return new GenericCommandResult(false, "Aluno não encontrado", null);

            var turma = _repositorioTurma.BuscarTurmaPorId(command.IdTurma);

            if (turma == null)
                return new GenericCommandResult(false, "Turma não encontrada", null);

            AlunoTurma.AlterarAlunoTurma(command.IdTurma, command.IdAluno, command.AnotacaoProfessor);

            if (AlunoTurma.Valid)
                _repositorio.AlterarAlunoTurma(AlunoTurma);

            return new GenericCommandResult(true, "Turma do Aluno", AlunoTurma);
        }
    }
}
