using CodeTur.Dominio.Commands.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands.Usuarios
{
    public class LogarCommandTestes
    {
        [Fact]
        public void ErroCasoDadosLogarCommandInvalidos()
        {
            var _command = new LogarCommand("", "");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um command de usuário
            //devido a falta de um resultado para o parametro 'email', 'senha'
            Assert.True(_command.Invalid, "Os dados estão corretos");
        }

        [Fact]
        public void ErroCasoEmailLogarCommandInvalido()
        {
            var _command = new LogarCommand("", "123456");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um command de usuário
            //devido a falta de um resultado para o parametro 'email'
            Assert.True(_command.Invalid, "O email informado está correto");
        }

        [Fact]
        public void ErroCasoSenhaLogarCommandInvalidos()
        {
            var _command = new LogarCommand("logarCommand@email.com", "");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um command de usuário
            //devido a falta de um resultado para o parametro 'senha'
            Assert.True(_command.Invalid, "A senha informada está correta");
        }

        [Fact]
        public void SucessoCasoDadosLogarCommandValidos()
        {
            var _command = new LogarCommand("logarCommand@email.com", "123456");

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao alterar um command de usuário
            Assert.True(_command.Valid, "Os dados estão incorretos");
        }
    }
}
