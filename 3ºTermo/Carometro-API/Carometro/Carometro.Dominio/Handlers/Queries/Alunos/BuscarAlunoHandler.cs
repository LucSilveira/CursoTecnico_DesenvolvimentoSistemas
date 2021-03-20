using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Aluno;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Queries.Alunos
{
    public class BuscarAlunoHandler : IHandlerQuery<BuscarAlunoQuery>
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public BuscarAlunoHandler(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public IQueryResult Handle(BuscarAlunoQuery command)
        {
            command.Validate();

            if (command.BuscarRg != null)
            {
                if (command.Invalid)
                    return new GenericQueryResult(false, "Dados inválidos", command.Notifications);

                var alunoProcuradoRG = _alunoRepositorio.BuscarPorRg(command.BuscarRg);

                if (alunoProcuradoRG == null)
                    return new GenericQueryResult(false, "Aluno não encontrado", null);

                var professorEmailResult = new BuscarAlunoResult
                {
                    Id = alunoProcuradoRG.Id,
                    NomeUsuario = alunoProcuradoRG.NomeUsuario,
                    Email = alunoProcuradoRG.Email,
                    Telefone = alunoProcuradoRG.Telefone,
                    Rg = alunoProcuradoRG.Rg,
                    Cpf = alunoProcuradoRG.Cpf,
                    FotoAluno = alunoProcuradoRG.FotoAluno,
                };

                return new GenericQueryResult(true, "Dados do professor", professorEmailResult);
            }

            var alunoProcurado = _alunoRepositorio.BuscarPorId(command.BuscarId);

            if (alunoProcurado == null)
                return new GenericQueryResult(false, "Aluno não encontrado", null);

            var alunoResult = new BuscarAlunoResult
            {
                Id = alunoProcurado.Id,
                NomeUsuario = alunoProcurado.NomeUsuario,
                Email = alunoProcurado.Email,
                Telefone = alunoProcurado.Telefone,
                Rg = alunoProcurado.Rg,
                Cpf = alunoProcurado.Cpf,
                FotoAluno = alunoProcurado.FotoAluno,
            };

            return new GenericQueryResult(true, "Dados do professor", alunoResult);
        }
    }
}
