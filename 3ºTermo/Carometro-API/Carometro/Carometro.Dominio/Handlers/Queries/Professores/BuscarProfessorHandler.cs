using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Professor;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Queries.Professores
{
    public class BuscarProfessorHandler : IHandlerQuery<BuscarProfessorQuery>
    {
        private readonly IProfessorRepositorio _repositorio;

        public BuscarProfessorHandler(IProfessorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IQueryResult Handle(BuscarProfessorQuery command)
        {
            command.Validate();

            if(command.BuscarEmail != null)
            {
                if (command.Invalid)
                    return new GenericQueryResult(false, "Dados inválidos", command.Notifications);

                var professorProcuradoEmail = _repositorio.BuscarProfessorPorEmail(command.BuscarEmail);

                if (professorProcuradoEmail == null)
                    return new GenericQueryResult(false, "Professor não encontrado", null);

                var professorEmailResult = new BuscarProfessorResult
                {
                    Id = professorProcuradoEmail.Id,
                    NomeUsuario = professorProcuradoEmail.NomeUsuario,
                    Email = professorProcuradoEmail.Email,
                    Telefone = professorProcuradoEmail.Telefone,
                    FotoProfessor = professorProcuradoEmail.FotoProfessor,
                };

                return new GenericQueryResult(true, "Dados do professor", professorEmailResult);
            }

            var professorProcurado = _repositorio.BuscarProfessorPorId(command.BuscarId);

            if (professorProcurado == null)
                return new GenericQueryResult(false, "Professor não encontrado", null);

            var professorResult = new BuscarProfessorResult
            {
                Id = professorProcurado.Id,
                NomeUsuario = professorProcurado.NomeUsuario,
                Email = professorProcurado.Email,
                Telefone = professorProcurado.Telefone,
                FotoProfessor = professorProcurado.FotoProfessor,
            };

            return new GenericQueryResult(true, "Dados do professor", professorResult);
        }
    }
}
