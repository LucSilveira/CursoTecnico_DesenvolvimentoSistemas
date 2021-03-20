using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.AlunoTurma;
using Carometro.Dominio.Queries.Turma;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Carometro.Dominio.Queries.Aluno.ListarAlunoQuery;

namespace Carometro.Dominio.Handlers.Queries.AlunosTurmas
{
    public class ListarAlunosDaTurmaHandler : IHandlerQuery<ListarAlunosDaTurmaQuery>
    {
        private readonly IAlunoTurmaRepositorio _repositorio;

        private readonly IAlunoRepositorio _repositorioAluno;

        private readonly ITurmaRepositorio _repositorioTurma;

        public ListarAlunosDaTurmaHandler(IAlunoTurmaRepositorio repositorio, IAlunoRepositorio repositorioAluno, ITurmaRepositorio repositorioTurma)
        {
            _repositorio = repositorio;
            _repositorioAluno = repositorioAluno;
            _repositorioTurma = repositorioTurma;
        }

        public IQueryResult Handle(ListarAlunosDaTurmaQuery command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericQueryResult(false, "Dados inválidos", command.Notifications);

            var alunosDaTurma = _repositorio.ListarAlunosDaTurma(command.IdTurma);

            var result = alunosDaTurma.Select(alt => 
            {
                var turma = _repositorioTurma.BuscarTurmaPorId(alt.IdTurma);

                var aluno = _repositorioAluno.BuscarPorId(alt.IdAluno);

                return new ListarAlunosDaTurmaResult()
                {
                    Turma = new BuscarTurmaResult
                    {
                        Id = turma.Id,
                        Titulo = turma.Titulo,
                        Descricao = turma.Descricao,
                        Semestre = turma.Semestre.ToString(),
                    },
                    Alunos = alunosDaTurma.Select(atm => 
                        
                        new ListarQueryResult
                        {
                            Id = aluno.Id,
                            NomeUsuario = aluno.NomeUsuario,
                            Email = aluno.Email,
                            Telefone = aluno.Telefone,
                            Rg = aluno.Rg,
                            FotoAluno = aluno.FotoAluno
                        }

                    ).ToList()
                };
            });

            return new GenericQueryResult(true, "Lista dos alunos da turma", result);
        }
    }
}
