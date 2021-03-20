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
    public class CadastrarProfessorTurmaHandler : IHandler<CadastrarProfessorTurmaCommand>
    {
        private readonly IProfessorTurmaRepositorio _repositorio;

        private readonly IProfessorRepositorio _repositorioProfessor;

        private readonly ITurmaRepositorio _repositorioTurma;

        public CadastrarProfessorTurmaHandler(IProfessorTurmaRepositorio repositorio, IProfessorRepositorio repositorioProfessor, ITurmaRepositorio repositorioTurma)
        {
            _repositorio = repositorio;
            _repositorioProfessor = repositorioProfessor;
            _repositorioTurma = repositorioTurma;
        }

        public ICommandResult Handler(CadastrarProfessorTurmaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            var Professor = _repositorioProfessor.BuscarProfessorPorId(command.IdProfessor);

            if (Professor == null)
                return new GenericCommandResult(false, "Professor não encontrado", null);

            var turma = _repositorioTurma.BuscarTurmaPorId(command.IdTurma);

            if (turma == null)
                return new GenericCommandResult(false, "Turma não encontrada", null);

            var ProfessorTurma = new ProfessorTurma(command.IdTurma, command.IdProfessor);

            if (ProfessorTurma.Valid)
                _repositorio.AdicionarProfessorATurma(ProfessorTurma);

            return new GenericCommandResult(true, "Professor inserido na turma com sucesso", ProfessorTurma);
        }
    }
}
