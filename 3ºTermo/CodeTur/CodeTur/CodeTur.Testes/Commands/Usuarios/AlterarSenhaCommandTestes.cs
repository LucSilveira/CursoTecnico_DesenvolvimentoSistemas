using CodeTur.Dominio.Commands.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands.Usuarios
{
    public class AlterarSenhaCommandTestes
    {
        [Fact]
        public void ErroCasoDadosAlterarSenhaCommandInvalidos()
        {
            var _command = new AlterarSenhaCommand("", "");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um command de usuário
            //devido a falta de um resultado para o parametro 'email', 'senha'
            Assert.True(_command.Invalid, "Os dados estão corretos");
        }

        [Fact]
        public void ErroCasoEmailAlterarSenhaCommandInvalidos()
        {
            var _command = new AlterarSenhaCommand("", "123456");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um command de usuário
            //devido a falta de um resultado para o parametro 'email'
            Assert.True(_command.Invalid, "O email de usuário está correto");
        }

        [Fact]
        public void ErroCasoSenhaAlterarSenhaCommandInvalidos()
        {
            var _command = new AlterarSenhaCommand("email@email.com", "");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um command de usuário
            //devido a falta de um resultado para o parametro 'senha'
            Assert.True(_command.Invalid, "A senha informada está correta");
        }

        [Fact]
        public void SucessoCasoDadosAlterarCommandValidos()
        {
            var _command = new AlterarSenhaCommand("email@email.com", "123456");

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao alterar um novo command usuário
            Assert.True(_command.Valid, "os dados estão corretos");
        }
    }
}
