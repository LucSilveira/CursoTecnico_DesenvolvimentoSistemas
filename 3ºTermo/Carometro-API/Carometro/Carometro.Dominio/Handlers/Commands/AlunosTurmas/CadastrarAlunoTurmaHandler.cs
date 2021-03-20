using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.AlunoTurma;
using Carometro.Dominio.Entidades;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.AlunosTurmas
{
    public class CadastrarAlunoTurmaHandler : IHandler<CadastrarAlunoTurmaCommand>
    {
        private readonly IAlunoTurmaRepositorio _repositorio;

        private readonly IAlunoRepositorio _repositorioAluno;

        private readonly ITurmaRepositorio _repositorioTurma;

        public CadastrarAlunoTurmaHandler(IAlunoTurmaRepositorio repositorio, IAlunoRepositorio repositorioAluno, ITurmaRepositorio repositorioTurma)
        {
            _repositorio = repositorio;
            _repositorioAluno = repositorioAluno;
            _repositorioTurma = repositorioTurma;
        }

        public ICommandResult Handler(CadastrarAlunoTurmaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            var aluno = _repositorioAluno.BuscarPorId(command.IdAluno);

            if (aluno == null)
                return new GenericCommandResult(false, "Aluno não encontrado", null);

            var turma = _repositorioTurma.BuscarTurmaPorId(command.IdTurma);

            if (turma == null)
                return new GenericCommandResult(false, "Turma não encontrada", null);

            var alunoTurma = new AlunoTurma(command.IdAluno, command.IdTurma, command.AnotacaoProfessor);

            if (alunoTurma.Valid)
                _repositorio.AdicionarAlunoATurma(alunoTurma);

            return new GenericCommandResult(true, "Aluno inserido na turma com sucesso", alunoTurma);
        }
    }
}
