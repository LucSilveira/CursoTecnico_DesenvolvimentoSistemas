using CodeTur.Dominio.Commands.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands.Usuarios
{
    public class AlterarUsuarioCommandTestes
    {
        [Fact]
        public void ErroCasoDadosAterarCommandInvalidos()
        {
            var _command = new AlterarUsuarioCommand(Guid.Empty, "", "", "");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um command de usuário
            //devido a falta de um resultado para o parametro 'id de usuário', 'nome', 'email', 'telefone'
            Assert.True(_command.Invalid, "Os dados informados estão corretos");
        }

        [Fact]
        public void ErroCasoIdAterarCommandInvalido()
        {
            var _command = new AlterarUsuarioCommand(Guid.Empty, "Nome alterar command", "emailAlterarCommand@email.com", "11962553590");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um command de usuário
            //devido a falta de um resultado para o parametro 'id de usuário'
            Assert.True(_command.Invalid, "O id informado está correto");
        }

        [Fact]
        public void ErroCasoNomeAterarCommandInvalido()
        {
            var _command = new AlterarUsuarioCommand(Guid.NewGuid(), "", "emailAlterarCommand@email.com", "11962553590");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um command de usuário
            //devido a falta de um resultado para o parametro 'nome'
            Assert.True(_command.Invalid, "O nome informado está correto");
        }

        [Fact]
        public void ErroCasoEmailAterarCommandInvalido()
        {
            var _command = new AlterarUsuarioCommand(Guid.NewGuid(), "Nome alterar command", "", "11962553590");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um command de usuário
            //devido a falta de um resultado para o parametro 'email'
            Assert.True(_command.Invalid, "O email informado está correto");
        }

        [Fact]
        public void SucessoCasoDadosAterarCommandValidosSemTelefone()
        {
            var _command = new AlterarUsuarioCommand(Guid.NewGuid(), "Nome alterar command", "emailAlterarCommand@email.com", "");

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao inserir um novo usuário
            Assert.True(_command.Valid, "Os dados informados estão incorretos");
        }

        [Fact]
        public void SucessoCasoDadosAterarCommandValidosComTelefone()
        {
            var _command = new AlterarUsuarioCommand(Guid.NewGuid(), "Nome alterar command", "emailAlterarCommand@email.com", "11962553590");

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao inserir um novo usuário
            Assert.True(_command.Valid, "Os dados informados estão incorretos");
        }
    }
}
