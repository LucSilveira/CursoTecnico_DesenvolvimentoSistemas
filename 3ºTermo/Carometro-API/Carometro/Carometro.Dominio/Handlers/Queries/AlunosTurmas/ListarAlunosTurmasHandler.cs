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
    public class ListarAlunosTurmasHandler : IHandlerQuery<ListarAlunosTurmasQuery>
    {
        private readonly IAlunoTurmaRepositorio _repositorio;

        private readonly IAlunoRepositorio _repositorioAluno;

        private readonly ITurmaRepositorio _repositorioTurma;

        private readonly IHorarioRepositorio _repositorioHorario;

        public ListarAlunosTurmasHandler(IAlunoTurmaRepositorio repositorio, IAlunoRepositorio repositorioAluno, ITurmaRepositorio repositorioTurma, IHorarioRepositorio repositorioHorario)
        {
            _repositorio = repositorio;
            _repositorioAluno = repositorioAluno;
            _repositorioTurma = repositorioTurma;
            _repositorioHorario = repositorioHorario;
        }

        public IQueryResult Handle(ListarAlunosTurmasQuery command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericQueryResult(false, "Dados inválidos", command.Notifications);

            var alunosTurmas = _repositorio.ListarAlunosTurmas();

            var result = alunosTurmas.Select(atms =>
            {
                var aluno = _repositorioAluno.BuscarPorId(atms.IdAluno);

                var turma = _repositorioTurma.BuscarTurmaPorId(atms.IdTurma);

                var horarios = _repositorioHorario.BuscarHorarioPorIdTurma(turma.Id);

                return new ListarAlunosTurmasResult()
                {
                    Id = atms.Id,
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
                    },
                    Aluno = new BuscarAlunoResult
                    {
                        Id = aluno.Id,
                        NomeUsuario = aluno.NomeUsuario,
                        Email = aluno.Email,
                        Telefone = aluno.Telefone,
                        Rg = aluno.Rg,
                        FotoAluno = aluno.FotoAluno
                    },
                    AnotacaoProfessor = atms.AnotacaoProfessor
                };
            });

            return new GenericQueryResult(true, "Lista de alunos turmas", result);
        }
    }
}
