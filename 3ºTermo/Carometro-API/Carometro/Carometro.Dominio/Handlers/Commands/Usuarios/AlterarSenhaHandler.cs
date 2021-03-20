using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Utils;
using Carometro.Dominio.Commands.Usuario;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.Usuarios
{
    public class AlterarSenhaHandler : IHandler<AlterarSenhaCommand>
    {
        private readonly IAdminRepositorio _adminRepositorio;

        private readonly IAlunoRepositorio _alunoRepositorio;

        private readonly IProfessorRepositorio _professorRepositorio;

        public AlterarSenhaHandler(IAdminRepositorio adminRepositorio, IAlunoRepositorio alunoRepositorio, IProfessorRepositorio professorRepositorio)
        {
            _adminRepositorio = adminRepositorio;
            _alunoRepositorio = alunoRepositorio;
            _professorRepositorio = professorRepositorio;
        }

        public ICommandResult Handler(AlterarSenhaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos", command.Notifications);

            var usuarioAdminExiste = _adminRepositorio.BuscarPorEmail(command.Email);

            if (usuarioAdminExiste != null)
            {
                _ = SendEmailGrid.EnviarEmail(usuarioAdminExiste.Email, usuarioAdminExiste.NomeUsuario,
                      "Confirmação de alteração de senha", "Senha alterada com sucesso!", "Conforme a solicitação da alteração de senha, confirmamos que sua senha foi alterada com sucesso, faça o login na plataforma inserindo os novos dados, muito obrigado!", null);

                command.Senha = Senha.CriptografarSenha(command.Senha);

                usuarioAdminExiste.Alterarsenha(command.Senha);

                _adminRepositorio.Alterar(usuarioAdminExiste);

                return new GenericCommandResult(true, "Senha alterada com sucesso", usuarioAdminExiste);
            }

            var usuarioAlunoExiste = _alunoRepositorio.BuscarPorEmail(command.Email);

            if (usuarioAlunoExiste != null)
            {
                _ = SendEmailGrid.EnviarEmail(usuarioAlunoExiste.Email, usuarioAlunoExiste.NomeUsuario,
                      "Confirmação de alteração de senha", "Senha alterada com sucesso!", "Conforme a solicitação da alteração de senha, confirmamos que sua senha foi alterada com sucesso, faça o login na plataforma inserindo os novos dados, muito obrigado!", null);

                command.Senha = Senha.CriptografarSenha(command.Senha);

                usuarioAlunoExiste.Alterarsenha(command.Senha);

                _alunoRepositorio.Alterar(usuarioAlunoExiste);

                return new GenericCommandResult(true, "Senha alterada com sucesso", usuarioAlunoExiste);
            }

            var usuarioProfessorExiste = _professorRepositorio.BuscarProfessorPorEmail(command.Email);

            if (usuarioProfessorExiste != null)
            {
                _ = SendEmailGrid.EnviarEmail(usuarioAlunoExiste.Email, usuarioAlunoExiste.NomeUsuario,
                      "Confirmação de alteração de senha", "Senha alterada com sucesso!", "Conforme a solicitação da alteração de senha, confirmamos que sua senha foi alterada com sucesso, faça o login na plataforma inserindo os novos dados, muito obrigado!", null);

                command.Senha = Senha.CriptografarSenha(command.Senha);

                usuarioProfessorExiste.Alterarsenha(command.Senha);

                _professorRepositorio.AlterarProfessor(usuarioProfessorExiste);

                return new GenericCommandResult(true, "Senha alterada com sucesso", usuarioProfessorExiste);
            }

            return new GenericCommandResult(true, "Usuário não encontrado", null);
        }
    }
}
