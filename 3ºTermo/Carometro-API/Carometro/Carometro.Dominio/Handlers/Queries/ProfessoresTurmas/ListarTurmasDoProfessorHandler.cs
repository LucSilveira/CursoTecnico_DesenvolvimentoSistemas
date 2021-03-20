﻿using Carometro.Comum.Handlers.Contracts;
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
    public class ListarTurmasDoProfessorHandler : IHandlerQuery<ListarTurmasDoProfessorQuery>
    {
        private readonly IProfessorTurmaRepositorio _repositorio;

        private readonly IProfessorRepositorio _repositorioProfessor;

        private readonly ITurmaRepositorio _repositorioTurma;

        private readonly IHorarioRepositorio _repositorioHorario;

        public ListarTurmasDoProfessorHandler(IProfessorTurmaRepositorio repositorio, IProfessorRepositorio repositorioProfessor, ITurmaRepositorio repositorioTurma, IHorarioRepositorio repositorioHorario)
        {
            _repositorio = repositorio;
            _repositorioProfessor = repositorioProfessor;
            _repositorioTurma = repositorioTurma;
            _repositorioHorario = repositorioHorario;
        }

        public IQueryResult Handle(ListarTurmasDoProfessorQuery command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericQueryResult(false, "Dados inválidos", command.Notifications);

            var turmasDoProfessor = _repositorio.ListarTurmasDoProfessor(command.IdProfessor);

            var result = turmasDoProfessor.Select(tal =>
            {
                var turma = _repositorioTurma.BuscarTurmaPorId(tal.IdTurma);

                var Professor = _repositorioProfessor.BuscarProfessorPorId(tal.IdProfessor);

                var horarios = _repositorioHorario.BuscarHorarioPorIdTurma(turma.Id);

                return new ListaTurmasDoProfessorResult()
                {
                    Professor = new BuscarProfessorResult
                    {
                        Id = Professor.Id,
                        NomeUsuario = Professor.NomeUsuario,
                        Email = Professor.Email,
                        Telefone = Professor.Telefone,
                        FotoProfessor = Professor.FotoProfessor
                    },
                    Turmas = turmasDoProfessor.Select(tam =>

                        new ListarTurmaResult
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

                    ).ToList()
                };
            });

            return new GenericQueryResult(true, "Turmas do Professor", result);
        }
    }
}
