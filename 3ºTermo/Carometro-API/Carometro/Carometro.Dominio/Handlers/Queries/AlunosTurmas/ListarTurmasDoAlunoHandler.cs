using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Aluno;
using Carometro.Dominio.Queries.AlunoTurma;
using Carometro.Dominio.Queries.Horario;
using Carometro.Dominio.Queries.Turma;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Queries.AlunosTurmas
{
    public class ListarTurmasDoAlunoHandler : IHandlerQuery<ListarTurmasDoAlunoQuery>
    {
        private readonly IAlunoTurmaRepositorio _repositorio;

        private readonly IAlunoRepositorio _repositorioAluno;

        private readonly ITurmaRepositorio _repositorioTurma;

        private readonly IHorarioRepositorio _repositorioHorario;

        public ListarTurmasDoAlunoHandler(IAlunoTurmaRepositorio repositorio, IAlunoRepositorio repositorioAluno, ITurmaRepositorio repositorioTurma, IHorarioRepositorio repositorioHorario)
        {
            _repositorio = repositorio;
            _repositorioAluno = repositorioAluno;
            _repositorioTurma = repositorioTurma;
            _repositorioHorario = repositorioHorario;
        }

        public IQueryResult Handle(ListarTurmasDoAlunoQuery command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericQueryResult(false, "Dados inválidos", command.Notifications);

            var turmasDoAluno = _repositorio.ListarTurmasDoAluno(command.IdAluno);

            var result = turmasDoAluno.Select(tal =>
            {
                var turma = _repositorioTurma.BuscarTurmaPorId(tal.IdTurma);

                var aluno = _repositorioAluno.BuscarPorId(tal.IdAluno);

                var horarios = _repositorioHorario.BuscarHorarioPorIdTurma(turma.Id);

                return new ListaTurmasDoAlunoResult()
                {
                    Aluno = new BuscarAlunoResult
                    {
                        Id = aluno.Id,
                        NomeUsuario = aluno.NomeUsuario,
                        Email = aluno.Email,
                        Telefone = aluno.Telefone,
                        Rg = aluno.Rg,
                        FotoAluno = aluno.FotoAluno
                    },
                    Turmas = turmasDoAluno.Select(tam => 
                        
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

            return new GenericQueryResult(true, "Turmas do aluno", result);
        }
    }
}
