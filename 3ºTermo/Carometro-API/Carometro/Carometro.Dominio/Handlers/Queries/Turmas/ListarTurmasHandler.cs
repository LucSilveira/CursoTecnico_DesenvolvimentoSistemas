using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Horario;
using Carometro.Dominio.Queries.Turma;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Queries.Turmas
{
    public class ListarTurmasHandler : IHandlerQuery<ListaTurmaQuery>
    {
        private readonly ITurmaRepositorio _repositorio;

        private readonly IHorarioRepositorio _repositorioHorario;

        public ListarTurmasHandler(ITurmaRepositorio repositorio, IHorarioRepositorio repositorioHorario)
        {
            _repositorio = repositorio;
            _repositorioHorario = repositorioHorario;
        }

        public IQueryResult Handle(ListaTurmaQuery command)
        {
            var turmas = _repositorio.ListarTurmas();

            var turmaResult = turmas.Select(tm =>
            {
                var horarios = _repositorioHorario.BuscarHorarioPorIdTurma(tm.Id);

                return new ListarTurmaResult()
                {
                    Id = tm.Id,
                    Titulo = tm.Titulo,
                    Descricao = tm.Descricao,
                    Semestre = tm.Semestre.ToString(),
                    Horarios = tm.Horarios.Select(hrr => 
                    
                        new ListarHorarioResult()
                        {
                            Id = hrr.Id,
                            DiaSemana = hrr.DiaSemana.ToString(),
                            HoraInicio = hrr.HoraInicio,
                            HoraTermino = hrr.HoraTermino
                        }

                    ).ToList()
                };
            });

            return new GenericQueryResult(true, "Turmas", turmaResult);
        }
    }
}
