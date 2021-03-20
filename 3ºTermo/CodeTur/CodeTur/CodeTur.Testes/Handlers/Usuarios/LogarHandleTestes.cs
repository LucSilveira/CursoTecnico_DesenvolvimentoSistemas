using CodeTur.Comum.Commands;
using CodeTur.Dominio.Commands.Usuarios;
using CodeTur.Dominio.Handlers.Usuarios;
using CodeTur.Testes.Repositories.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Handlers.Usuarios
{
    public class LogarHandleTestes
    {
        [Fact]
        public void ErroCasoDadosLogarHadandleInvalidos()
        {
            var _command = new LogarCommand("", "");

            var _handle = new LogarHandle(new FakeUsuarioRepository());

            var _result = (GenericCommandResult)_handle.Handle(_command);

            Assert.False(_result.Sucesso, "O login foi efetuado");
        }

        [Fact]
        public void ErroCasoEmailLogarHadandleInvalidos()
        {
            var _command = new LogarCommand("", "123456");

            var _handle = new LogarHandle(new FakeUsuarioRepository());

            var _result = (GenericCommandResult)_handle.Handle(_command);

            Assert.False(_result.Sucesso, "O email está correto");
        }

        [Fact]
        public void ErroCasoSenhaLogarHadandleInvalidos()
        {
            var _command = new LogarCommand("email@email.com", "");

            var _handle = new LogarHandle(new FakeUsuarioRepository());

            var _result = (GenericCommandResult)_handle.Handle(_command);

            Assert.False(_result.Sucesso, "A senha está correta");
        }

        /*[Fact]
        public void SucessoCasoDadosLogarHadandleValidos()
        {
            var _command = new LogarCommand("email@email.com", "123456");

            var _handle = new LogarHandle(new FakeUsuarioRepository());

            var _result = (GenericCommandResult)_handle.Handle(_command);

            Assert.False(_result.Sucesso, "O login foi efetuado");
        }*/
    }
}
