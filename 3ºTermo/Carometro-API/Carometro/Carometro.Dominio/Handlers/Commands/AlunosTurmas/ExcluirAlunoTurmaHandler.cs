using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.AlunoTurma;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.AlunosTurmas
{
    public class ExcluirAlunoTurmaHandler : IHandler<ExcluirAlunoTurmaCommand>
    {
        private readonly IAlunoTurmaRepositorio _repositorio;

        private readonly IAlunoRepositorio _repositorioAluno;

        private readonly ITurmaRepositorio _repositorioTurma;

        public ExcluirAlunoTurmaHandler(IAlunoTurmaRepositorio repositorio, IAlunoRepositorio repositorioAluno, ITurmaRepositorio repositorioTurma)
        {
            _repositorio = repositorio;
            _repositorioAluno = repositorioAluno;
            _repositorioTurma = repositorioTurma;
        }

        public ICommandResult Handler(ExcluirAlunoTurmaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            var AlunoTurma = _repositorio.BuscarAlunoTurmaPorId(command.Id);

            if (AlunoTurma == null)
                return new GenericCommandResult(true, "Turma do Aluno não encontrada", null);

            _repositorio.ExcluirAlunoTurma(AlunoTurma);

            return new GenericCommandResult(true, "Turma do aluno excluida com sucesso", AlunoTurma);
        }
    }
}
