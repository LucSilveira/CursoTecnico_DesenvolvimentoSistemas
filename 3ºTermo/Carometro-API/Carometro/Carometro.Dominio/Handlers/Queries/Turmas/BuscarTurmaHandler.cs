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
    public class BuscarTurmaHandler : IHandlerQuery<BuscarTurmaQuery>
    {
        private readonly ITurmaRepositorio _repositorio;

        private readonly IHorarioRepositorio _repositorioHorario;

        public BuscarTurmaHandler(ITurmaRepositorio repositorio, IHorarioRepositorio repositorioHorario)
        {
            _repositorio = repositorio;
            _repositorioHorario = repositorioHorario;
        }

        public IQueryResult Handle(BuscarTurmaQuery command)
        {
            var turma = _repositorio.BuscarTurmaPorId(command.IdTurma);

            if (turma == null)
                return new GenericQueryResult(false, "Turma não encontrada", null);

            var result = new BuscarTurmaResult()
            {
                Id = turma.Id,
                Titulo = turma.Titulo,
                Descricao = turma.Descricao,
                Semestre = turma.Semestre.ToString(),
                DataIniciacao = turma.DataIniciacao,
                DataConclusao = turma.DataConclusao,
                Horarios = turma.Horarios.Select(hrr =>

                    new ListarHorarioResult()
                    {
                        Id = hrr.Id,
                        DiaSemana = hrr.DiaSemana.ToString(),
                        HoraInicio = hrr.HoraInicio,
                        HoraTermino = hrr.HoraTermino
                    }

                ).ToList()
            };

            return new GenericQueryResult(true, "Dados da turma", result);
        }
    }
}
