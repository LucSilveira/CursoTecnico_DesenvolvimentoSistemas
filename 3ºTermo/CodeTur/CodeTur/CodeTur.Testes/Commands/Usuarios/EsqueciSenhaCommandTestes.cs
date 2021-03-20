using CodeTur.Dominio.Commands.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands.Usuarios
{
    public class EsqueciSenhaCommandTestes
    {
        [Fact]
        public void ErroCasoDadosEsqueciSenhaCommandInvalidos()
        {
            var _command = new EsqueciSenhaCommand("");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um command de usuário
            //devido a falta de um resultado para o parametro 'email'
            Assert.True(_command.Invalid, "O email informado está correto");
        }

        [Fact]
        public void SucessoCasoDadosEsqueciSenhaCommandValidos()
        {
            var _command = new EsqueciSenhaCommand("esqueciSenhaCommand@email.com");

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao alterar um novo command usuário
            Assert.True(_command.Valid, "O email informado está incorreto");
        }
    }
}
