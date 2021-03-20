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
    public class BuscarAdminHandler : IHandlerQuery<BuscarAdminQuery>
    {
        private readonly IAdminRepositorio _adminRepositorio;

        public BuscarAdminHandler(IAdminRepositorio adminRepositorio)
        {
            _adminRepositorio = adminRepositorio;
        }

        public IQueryResult Handle(BuscarAdminQuery command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericQueryResult(false, "Dados inválidos", command.Notifications);

            var adminProcurado = _adminRepositorio.BuscarPorId(command.Id);

            if (adminProcurado == null)
                return new GenericQueryResult(false, "Administrador não encontrado", null);

            var result = new BuscarAdminResult
            {
                Id = adminProcurado.Id,
                Nome = adminProcurado.NomeUsuario,
                Email = adminProcurado.Email,
                Telefone = adminProcurado.Telefone
            };

            return new GenericQueryResult(true, "Dados do administrador", result);
        }
    }
}
