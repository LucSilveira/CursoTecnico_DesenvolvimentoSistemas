using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Horario;
using Carometro.Dominio.Queries.Professor;
using Carometro.Dominio.Queries.ProfessorTurma;
using Carometro.Dominio.Queries.Turma;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Queries.ProfessoresTurmas
{
    public class BuscarProfessorTurmaHandler : IHandlerQuery<BuscarProfessorTurmaQuery>
    {
        private readonly IProfessorTurmaRepositorio _repositorio;

        private readonly IProfessorRepositorio _repositorioProfessor;

        private readonly ITurmaRepositorio _repositorioTurma;

        public BuscarProfessorTurmaHandler(IProfessorTurmaRepositorio repositorio, IProfessorRepositorio repositorioProfessor, ITurmaRepositorio repositorioTurma)
        {
            _repositorio = repositorio;
            _repositorioProfessor = repositorioProfessor;
            _repositorioTurma = repositorioTurma;
        }

        public IQueryResult Handle(BuscarProfessorTurmaQuery command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericQueryResult(false, "Dados inválidos", command.Notifications);

            var procurarProfessorTurma = _repositorio.BuscarProfessorTurmaPorId(command.Id);

            if (procurarProfessorTurma == null)
                return new GenericQueryResult(false, "Professor turma não encontrado", null);

            var Professor = _repositorioProfessor.BuscarProfessorPorId(procurarProfessorTurma.IdProfessor);

            var turma = _repositorioTurma.BuscarTurmaPorId(procurarProfessorTurma.IdTurma);

            var result = new BuscarProfessorTurmaResult
            {
                Id = procurarProfessorTurma.Id,
                Professor = new BuscarProfessorResult
                {
                    Id = Professor.Id,
                    NomeUsuario = Professor.NomeUsuario,
                    Email = Professor.Email,
                    Telefone = Professor.Telefone,
                    FotoProfessor = Professor.FotoProfessor
                },
                Turma = new BuscarTurmaResult
                {
                    Id = turma.Id,
                    Titulo = turma.Titulo,
                    Descricao = turma.Descricao,
                    Semestre = turma.Semestre.ToString(),
                    Horarios = turma.Horarios.Select(hrr =>

                        new ListarHorarioResult()
                        {
                            Id = hrr.Id,
                            DiaSemana = hrr.DiaSemana.ToString(),
                            HoraInicio = hrr.HoraInicio,
                            HoraTermino = hrr.HoraTermino
                        }

                    ).ToList()
                }
            };

            return new GenericQueryResult(true, "Dados do professor turma", result);
        }
    }
}
