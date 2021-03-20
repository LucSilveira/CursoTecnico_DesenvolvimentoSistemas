using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Aluno;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Carometro.Dominio.Queries.Aluno.ListarAlunoQuery;

namespace Carometro.Dominio.Handlers.Queries
{
    public class ListarAlunoQueryHandle : IHandlerQuery<ListarAlunoQuery>
    {

        private readonly IAlunoRepositorio _alunoRepositorio;
        public ListarAlunoQueryHandle(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public IQueryResult Handle(ListarAlunoQuery command)
        {
            var query = _alunoRepositorio.Listar();

            var alunos = query.Select(
                x =>
                {
                    return new ListarQueryResult()
                    {
                        Id = x.Id,
                        NomeUsuario = x.NomeUsuario,
                        Email = x.Email,
                        Telefone = x.Telefone,
                        Rg = x.Rg,
                        Cpf = x.Cpf,
                    };
                }

             );

            return new GenericQueryResult(true, "Alunos", alunos);
        }
    }
}
