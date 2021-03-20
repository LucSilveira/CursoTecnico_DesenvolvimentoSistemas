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
    public class AlterarContaHandler : IHandler<AlterarContaCommand>
    {
        private readonly IAdminRepositorio _adminRepositorio;

        public AlterarContaHandler(IAdminRepositorio adminRepositorio)
        {
            _adminRepositorio = adminRepositorio;
        }

        public ICommandResult Handler(AlterarContaCommand command)
        {
            //Verifica se o comando recebido é válido.
            command.Validar();

            //Verifica se os dados são válidos.
            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos", command.Notifications);

            //Variável de apoio para validação de email.
            var usuarioExiste = _adminRepositorio.BuscarPorId(command.Id);

            //Verifica se o email do usuário já foi cadastrado no banco.
            if (usuarioExiste == null)
                return new GenericCommandResult(false, "Administrdor não encontrado", null);

            if (command.Email != usuarioExiste.Email)
            {
                var novoEmailExistente = _adminRepositorio.BuscarPorEmail(command.Email);

                if (novoEmailExistente != null)
                    return new GenericCommandResult(false, "Este e-mail já está vinculado a uma conta, informe outro email", command.Notifications);
            }

            usuarioExiste.AlterarAdmin(command.Nome, command.Email, command.Telefone);

            if (usuarioExiste.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", usuarioExiste.Notifications);

            _adminRepositorio.Alterar(usuarioExiste);

            return new GenericCommandResult(true, "Administrador alterado com sucesso", usuarioExiste);
        }
    }
}
