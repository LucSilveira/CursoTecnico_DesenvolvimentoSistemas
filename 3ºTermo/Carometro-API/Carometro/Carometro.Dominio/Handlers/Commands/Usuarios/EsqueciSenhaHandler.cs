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
    public class EsqueciSenhaHandler : IHandler<EsqueciSenhaCommand>
    {
        private readonly IAdminRepositorio _adminRepositorio;

        private readonly IAlunoRepositorio _alunoRepositorio;

        private readonly IProfessorRepositorio _professorRepositorio;

        public EsqueciSenhaHandler(IAdminRepositorio adminRepositorio, IAlunoRepositorio alunoRepositorio, IProfessorRepositorio professorRepositorio)
        {
            _adminRepositorio = adminRepositorio;
            _alunoRepositorio = alunoRepositorio;
            _professorRepositorio = professorRepositorio;
        }

        public ICommandResult Handler(EsqueciSenhaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos", command.Notifications);

            var novaSenha = Senha.Gerar();

            var novaSenhaEncriptografada = Senha.CriptografarSenha(novaSenha);


            var usuarioAdminExiste = _adminRepositorio.BuscarPorEmail(command.Email);

            if (usuarioAdminExiste != null)
            {
                _ = SendEmailGrid.EnviarEmail(usuarioAdminExiste.Email, usuarioAdminExiste.NomeUsuario,
                        "Confirmação de nova senha", "Senha alterada com sucesso!", $"Conforme a solicitação da alteração de senha, nos da plataforma CodeTur disponibizamos uma nova senha para você, faça o login na plataforma inserindo os novos dados e sinta-se a vontade para altera-lá quando precisar, muito obrigado!<br><br>Sua nova senha é: ", novaSenha);

                usuarioAdminExiste.Alterarsenha(novaSenhaEncriptografada);

                _adminRepositorio.Alterar(usuarioAdminExiste);

                return new GenericCommandResult(true, "Nova senha gerada com sucesso", novaSenha);
            }

            var usuarioAlunoExiste = _alunoRepositorio.BuscarPorEmail(command.Email);

            if (usuarioAlunoExiste != null)
            {
                _ = SendEmailGrid.EnviarEmail(usuarioAlunoExiste.Email, usuarioAlunoExiste.NomeUsuario,
                       "Confirmação de nova senha", "Senha alterada com sucesso!", $"Conforme a solicitação da alteração de senha, nos da plataforma CodeTur disponibizamos uma nova senha para você, faça o login na plataforma inserindo os novos dados e sinta-se a vontade para altera-lá quando precisar, muito obrigado!<br><br>Sua nova senha é: ", novaSenha);

                usuarioAlunoExiste.Alterarsenha(novaSenhaEncriptografada);

                _alunoRepositorio.Alterar(usuarioAlunoExiste);

                return new GenericCommandResult(true, "Nova senha gerada com sucesso", novaSenha);
            }

            var usuarioProfessorExiste = _professorRepositorio.BuscarProfessorPorEmail(command.Email);

            if (usuarioProfessorExiste != null)
            {
                _ = SendEmailGrid.EnviarEmail(usuarioProfessorExiste.Email, usuarioProfessorExiste.NomeUsuario,
                       "Confirmação de nova senha", "Senha alterada com sucesso!", $"Conforme a solicitação da alteração de senha, nos da plataforma CodeTur disponibizamos uma nova senha para você, faça o login na plataforma inserindo os novos dados e sinta-se a vontade para altera-lá quando precisar, muito obrigado!<br><br>Sua nova senha é: ", novaSenha);

                usuarioProfessorExiste.Alterarsenha(novaSenhaEncriptografada);

                _professorRepositorio.AlterarProfessor(usuarioProfessorExiste);

                return new GenericCommandResult(true, "Nova senha gerada com sucesso", novaSenha);
            }

            return new GenericCommandResult(true, "Usuário não encontrado", null);
        }
    }
}
