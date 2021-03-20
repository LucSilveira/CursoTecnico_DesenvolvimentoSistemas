using CodeTur.Dominio.Commands.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands.Usuarios
{
    public class AdicionarTelefoneCommandTestes
    {
        [Fact]
        public void ErroCasoDadosAdicionarTelefoneInvalidos()
        {
            var _command = new AdicionarTelefoneCommand(Guid.Empty, "");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um command de usuário
            //devido a falta de um resultado para o parametro 'id de usuário', 'telefone'
            Assert.True(_command.Invalid, "Os dados estão corretos");
        }

        [Fact]
        public void ErroCasoIdAdicionarTelefoneInvalido()
        {
            var _command = new AdicionarTelefoneCommand(Guid.NewGuid(), "");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um command de usuário
            //devido a falta de um resultado para o parametro 'telefone'
            Assert.True(_command.Invalid, "O id de usuário está correto");
        }

        [Fact]
        public void ErroCasoTelefoneAdicionarTelefoneInvalido()
        {
            var _command = new AdicionarTelefoneCommand(Guid.NewGuid(), "");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um command de usuário
            //devido a falta de um resultado para o parametro 'telefone'
            Assert.True(_command.Invalid, "O telefone informado está correto");
        }

        [Fact]
        public void SucessoCasoDadosAdicionarTelefoneValidos()
        {
            var _command = new AdicionarTelefoneCommand(Guid.NewGuid(), "+5511980985567");

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao alterar um command de usuário
            Assert.True(_command.Valid, "O dados estão incorretos");
        }
    }
}
