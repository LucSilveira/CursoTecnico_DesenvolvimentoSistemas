using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Utils;
using Carometro.Dominio.Commands.Admin;
using Carometro.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.Admins
{
    public class LogarHandler : Notifiable, IHandler<LogarCommand>
    {
        private readonly IAdminRepositorio _adminRepositorio;

        private readonly IAlunoRepositorio _alunoRepositorio;

        private readonly IProfessorRepositorio _professorRepositorio;

        public LogarHandler(IAdminRepositorio adminRepositorio, IAlunoRepositorio alunoRepositorio, IProfessorRepositorio professorRepositorio)
        {
            _adminRepositorio = adminRepositorio;
            _alunoRepositorio = alunoRepositorio;
            _professorRepositorio = professorRepositorio;
        }

        public ICommandResult Handler(LogarCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos", command.Notifications);

            var usuarioAdminExiste = _adminRepositorio.BuscarPorEmail(command.Email);

            if (usuarioAdminExiste != null)
            {
                if(!Senha.Validar(command.Senha, usuarioAdminExiste.Senha))
                {
                    return new GenericCommandResult(false, "Senha inválida", command.Notifications);
                }

                return new GenericCommandResult(true, "Usuário Logado com sucesso", usuarioAdminExiste);
            }

            var usuarioAlunoExiste = _alunoRepositorio.BuscarPorEmail(command.Email);

            if(usuarioAlunoExiste != null)
            {
                if (!Senha.Validar(command.Senha, usuarioAlunoExiste.Senha))
                {
                    return new GenericCommandResult(false, "Senha inválida", command.Notifications);
                }

                return new GenericCommandResult(true, "Usuário Logado com sucesso", usuarioAlunoExiste);
            }

            var usuarioProfessorExiste = _professorRepositorio.BuscarProfessorPorEmail(command.Email);

            if (usuarioProfessorExiste != null)
            {
                if (!Senha.Validar(command.Senha, usuarioProfessorExiste.Senha))
                {
                    return new GenericCommandResult(false, "Senha inválida", command.Notifications);
                }

                return new GenericCommandResult(true, "Professor logado com sucesoo", usuarioProfessorExiste);
            }

            return new GenericCommandResult(false, "Usuário não encontrado", null);
        }
    }
}
