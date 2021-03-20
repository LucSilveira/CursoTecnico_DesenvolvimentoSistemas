using CodeTur.Comum.Commands;
using CodeTur.Comum.Enum;
using CodeTur.Dominio.Commands.Usuarios;
using CodeTur.Dominio.Handlers.Usuarios;
using CodeTur.Testes.Repositories.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Handlers.Usuarios
{
    public class CriarUsuarioHandleTestes
    {
        [Fact]
        public void ErroCasoDadosUsuarioHandleInvalidos()
        {
            //Criando o command de usuário
            var _command = new CriarUsuarioCommand();

            //Criando o handle para o teste do command
            var _handle = new CriarUsuarioHandle(new FakeUsuarioRepository());

            //Pegando os valores
            var _result = (GenericCommandResult)_handle.Handle(_command);

            //Validando os parametros
            Assert.False(_result.Sucesso, "Usuario válido");
        }

        [Fact]
        public void ErroCasoNomeUsuarioHandleInvalido()
        {
            //Criando o command de usuário
            var _command = new CriarUsuarioCommand("", "email3@email.com", "123456", "", EnTipoPerfil.Comum);

            //Criando o handle para o teste do command
            var _handle = new CriarUsuarioHandle(new FakeUsuarioRepository());

            //Pegando os valores
            var _result = (GenericCommandResult)_handle.Handle(_command);

            //Validando os parametros
            Assert.False(_result.Sucesso, "Nome de usuario válido");
        }

        [Fact]
        public void ErroCasoEmailUsuarioHandleInvalido()
        {
            //Criando o command de usuário
            var _command = new CriarUsuarioCommand("Nome qualquer", "", "123456", "", EnTipoPerfil.Comum);

            //Criando o handle para o teste do command
            var _handle = new CriarUsuarioHandle(new FakeUsuarioRepository());

            //Pegando os valores
            var _result = (GenericCommandResult)_handle.Handle(_command);

            //Validando os parametros
            Assert.False(_result.Sucesso, "Email de usuario válido");
        }

        [Fact]
        public void ErroCasoSenhaUsuarioHandleInvalido()
        {
            //Criando o command de usuário
            var _command = new CriarUsuarioCommand("Nome Qualquer", "email3@email.com", "", "", EnTipoPerfil.Comum);

            //Criando o handle para o teste do command
            var _handle = new CriarUsuarioHandle(new FakeUsuarioRepository());

            //Pegando os valores
            var _result = (GenericCommandResult)_handle.Handle(_command);

            //Validando os parametros
            Assert.False(_result.Sucesso, "Senha de usuario válida");
        }

        [Fact]
        public void SucessoCasoDadosUsuarioHandleInvalidos()
        {
            //Criando o command de usuário
            var _command = new CriarUsuarioCommand("Marcelo", "lucas1-portal@hotmail.com", "123456", "", EnTipoPerfil.Comum);

            //Criando o handle para o teste do command
            var _handle = new CriarUsuarioHandle(new FakeUsuarioRepository());

            //Pegando os valores
            var _result = (GenericCommandResult)_handle.Handle(_command);

            //Validando os parametros
            Assert.True(_result.Sucesso, "Usuario inválido");
        }
    }
}
