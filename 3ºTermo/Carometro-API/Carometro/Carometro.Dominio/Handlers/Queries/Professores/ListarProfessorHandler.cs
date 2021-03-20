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
    public class ListarProfessorHandler : IHandlerQuery<ListarProfessorQuery>
    {
        private readonly IProfessorRepositorio _repositorio;

        public ListarProfessorHandler(IProfessorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IQueryResult Handle(ListarProfessorQuery command)
        {
            var professores = _repositorio.ListarProfessores();

            if (professores == null)
                return new GenericQueryResult(false, "Nenhum professor foi encontrado", null);

            var result = professores.Select(pff =>
            {
                return new ListarProfessorResult
                {
                    Id = pff.Id,
                    NomeUsuario = pff.NomeUsuario,
                    Email = pff.Email,
                    Telefone = pff.Telefone,
                    FotoProfessor = pff.FotoProfessor
                };
            });

            return new GenericQueryResult(true, "Lista de professores", result);
        }
    }
}
