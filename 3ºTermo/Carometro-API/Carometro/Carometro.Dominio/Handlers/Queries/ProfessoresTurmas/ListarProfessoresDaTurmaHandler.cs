using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Queries;
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
    public class ListarProfessoresDaTurmaHandler : IHandlerQuery<ListarProfessoresDaTurmaQuery>
    {
        private readonly IProfessorTurmaRepositorio _repositorio;

        private readonly IProfessorRepositorio _repositorioProfessor;

        private readonly ITurmaRepositorio _repositorioTurma;

        public ListarProfessoresDaTurmaHandler(IProfessorTurmaRepositorio repositorio, IProfessorRepositorio repositorioProfessor, ITurmaRepositorio repositorioTurma)
        {
            _repositorio = repositorio;
            _repositorioProfessor = repositorioProfessor;
            _repositorioTurma = repositorioTurma;
        }

        public IQueryResult Handle(ListarProfessoresDaTurmaQuery command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericQueryResult(false, "Dados inválidos", command.Notifications);

            var ProfessoresDaTurma = _repositorio.ListarProfessoresDaTurma(command.IdTurma);

            var result = ProfessoresDaTurma.Select(alt =>
            {
                var turma = _repositorioTurma.BuscarTurmaPorId(alt.IdTurma);

                var Professor = _repositorioProfessor.BuscarProfessorPorId(alt.IdProfessor);

                return new ListarProfessoresDaTurmaResult()
                {
                    Turma = new BuscarTurmaResult
                    {
                        Id = turma.Id,
                        Titulo = turma.Titulo,
                        Descricao = turma.Descricao,
                        Semestre = turma.Semestre.ToString(),
                    },
                    Professores = ProfessoresDaTurma.Select(atm =>

                        new ListarProfessorResult
                        {
                            Id = Professor.Id,
                            NomeUsuario = Professor.NomeUsuario,
                            Email = Professor.Email,
                            Telefone = Professor.Telefone,
                            FotoProfessor = Professor.FotoProfessor
                        }

                    ).ToList()
                };
            });

            return new GenericQueryResult(true, "Lista dos Professores da turma", result);
        }
    }
}
