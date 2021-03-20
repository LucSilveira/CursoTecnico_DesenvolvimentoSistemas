using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.ProfessorTurma;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.ProssoresTurmas
{
    public class ExcluirProfessorTurmaHandler : IHandler<ExcluirProfessorTurmaCommand>
    {
        private readonly IProfessorTurmaRepositorio _repositorio;

        private readonly IProfessorRepositorio _repositorioProfessor;

        private readonly ITurmaRepositorio _repositorioTurma;

        public ExcluirProfessorTurmaHandler(IProfessorTurmaRepositorio repositorio, IProfessorRepositorio repositorioProfessor, ITurmaRepositorio repositorioTurma)
        {
            _repositorio = repositorio;
            _repositorioProfessor = repositorioProfessor;
            _repositorioTurma = repositorioTurma;
        }

        public ICommandResult Handler(ExcluirProfessorTurmaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            var professorTurma = _repositorio.BuscarProfessorTurmaPorId(command.Id);

            if (professorTurma == null)
                return new GenericCommandResult(true, "Turma do Professor não encontrada", null);

            _repositorio.ExcluirProfessorTurma(professorTurma);

            return new GenericCommandResult(true, "Turma do Professor excluida com sucesso", professorTurma);
        }
    }
}
