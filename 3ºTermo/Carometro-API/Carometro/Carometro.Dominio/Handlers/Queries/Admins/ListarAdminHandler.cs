using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Queries;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Queries.Admins
{
    public class ListarAdminHandler : IHandlerQuery<ListarAdminQuery>
    {
        private readonly IAdminRepositorio _adminRepositorio;
        public ListarAdminHandler(IAdminRepositorio adminRepositorio)
        {
            _adminRepositorio = adminRepositorio;
        }

        public IQueryResult Handle(ListarAdminQuery command)
        {
            var admins = _adminRepositorio.Listar();

            if (admins == null)
                return new GenericQueryResult(false, "Nenhum administrador foi encontrado", null);

            var adminResult = admins.Select(adm =>
            {
                return new ListaAdminResult
                {
                    Id = adm.Id,
                    Nome = adm.NomeUsuario,
                    Email = adm.Email,
                    Telefone = adm.Telefone
                };
            });

            return new GenericQueryResult(true, "Lista de administradores", adminResult);
        }
    }
}
