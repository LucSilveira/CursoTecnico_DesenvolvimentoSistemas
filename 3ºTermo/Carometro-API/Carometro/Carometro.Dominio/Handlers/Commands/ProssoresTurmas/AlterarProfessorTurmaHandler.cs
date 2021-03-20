using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.ProfessorTurma;
using Carometro.Dominio.Repositorios;
using Carometro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.ProssoresTurmas
{
    public class AlterarProfessorTurmaHandler : IHandler<AlterarProfessorTurmaCommand>
    {
        private readonly IProfessorTurmaRepositorio _repositorio;

        private readonly IProfessorRepositorio _repositorioProfessor;

        private readonly ITurmaRepositorio _repositorioTurma;

        public AlterarProfessorTurmaHandler(IProfessorTurmaRepositorio repositorio, IProfessorRepositorio repositorioProfessor, ITurmaRepositorio repositorioTurma)
        {
            _repositorio = repositorio;
            _repositorioProfessor = repositorioProfessor;
            _repositorioTurma = repositorioTurma;
        }

        public ICommandResult Handler(AlterarProfessorTurmaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            var professorTurma = _repositorio.BuscarProfessorTurmaPorId(command.Id);

            if (professorTurma == null)
                return new GenericCommandResult(true, "Turma do professor não encontrada", null);

            var professor = _repositorioProfessor.BuscarProfessorPorId(command.IdProfessor);

            if (professor == null)
                return new GenericCommandResult(false, "Professor não encontrado", null);

            var turma = _repositorioTurma.BuscarTurmaPorId(command.IdTurma);

            if (turma == null)
                return new GenericCommandResult(false, "Turma não encontrada", null);

            professorTurma.AlterarrofessorTurma(command.IdTurma, command.IdProfessor);

            if (professorTurma.Valid)
                _repositorio.AdicionarProfessorATurma(professorTurma);

            _repositorio.AlterarProfessorTurma(professorTurma);

            return new GenericCommandResult(true, "Turma do professor", professorTurma);
        }
    }
}
