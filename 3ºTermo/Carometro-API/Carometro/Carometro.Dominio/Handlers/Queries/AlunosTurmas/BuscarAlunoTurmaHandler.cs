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
    public class BuscarAlunoTurmaHandler : IHandlerQuery<BuscarAlunoTurmaQuery>
    {
        private readonly IAlunoTurmaRepositorio _repositorio;

        private readonly IAlunoRepositorio _repositorioAluno;

        private readonly ITurmaRepositorio _repositorioTurma;

        public BuscarAlunoTurmaHandler(IAlunoTurmaRepositorio repositorio, IAlunoRepositorio repositorioAluno, ITurmaRepositorio repositorioTurma)
        {
            _repositorio = repositorio;
            _repositorioAluno = repositorioAluno;
            _repositorioTurma = repositorioTurma;
        }

        public IQueryResult Handle(BuscarAlunoTurmaQuery command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericQueryResult(false, "Dados inválidos", command.Notifications);

            var procurarAlunoTurma = _repositorio.BuscarAlunoTurmaPorId(command.Id);

            if (procurarAlunoTurma == null)
                return new GenericQueryResult(false, "Aluno turma não encontrado", null);

            var aluno = _repositorioAluno.BuscarPorId(procurarAlunoTurma.IdAluno);

            var turma = _repositorioTurma.BuscarTurmaPorId(procurarAlunoTurma.IdTurma);

            var result = new BuscarAlunoTurmaResult
            {
                Id = procurarAlunoTurma.Id,
                Aluno = new BuscarAlunoResult
                {
                    Id = aluno.Id,
                    NomeUsuario = aluno.NomeUsuario,
                    Email = aluno.Email,
                    Telefone = aluno.Telefone,
                    Rg = aluno.Rg,
                    FotoAluno = aluno.FotoAluno
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
                },
                Anotacao = procurarAlunoTurma.AnotacaoProfessor
            };

            return new GenericQueryResult(true, "Dados do aluno turma", result);
        }
    }
}
