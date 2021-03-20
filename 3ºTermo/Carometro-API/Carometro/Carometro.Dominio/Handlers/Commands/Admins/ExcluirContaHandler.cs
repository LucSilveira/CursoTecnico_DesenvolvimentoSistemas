using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.Admin;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.Admins
{
    public class ExcluirContaHandler : IHandler<ExcluirContaCommand>
    {
        private readonly IAdminRepositorio _adminRepositorio;
        public ExcluirContaHandler(IAdminRepositorio adminRepositorio)
        {
            _adminRepositorio = adminRepositorio;
        }

        public ICommandResult Handler(ExcluirContaCommand command)
        {
            command.Validar();

            //Caso seja inválido, recebemos quando são os valores incorretos identificados por ele
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Informe um id correto", command.Notifications);
            }

            var adminExiste = _adminRepositorio.BuscarPorId(command.Id);

            if (adminExiste == null)
                return new GenericCommandResult(false, "Administrador não encontrado", null);

            _adminRepositorio.Excluir(adminExiste);

            return new GenericCommandResult(true, "Administrador excluído com sucesso", adminExiste);
        }
    }
}
