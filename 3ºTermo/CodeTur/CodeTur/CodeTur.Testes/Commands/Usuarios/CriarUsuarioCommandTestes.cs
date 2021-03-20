using CodeTur.Comum.Enum;
using CodeTur.Dominio.Commands.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands.Usuarios
{
    public class CriarUsuarioCommandTestes
    {
        [Fact]
        public void ErroCasoDadosCommandInvalidos()
        {
            var _command = new CriarUsuarioCommand("", "", "", "", EnTipoPerfil.Comum);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao inserir um novo command de usuário
            //devido a falta de um resultado para o parametro 'nome', 'email', 'senha', 'telefone'
            Assert.True(_command.Invalid, "Os dados estão corretos");
        }

        [Fact]
        public void ErroCasoNomeCommandInvalido()
        {
            var _command = new CriarUsuarioCommand("", "emailcommand@email.com", "123456", "11962553590", EnTipoPerfil.Comum);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao inserir um novo command de usuário
            //devido a falta de um resultado para o parametro 'nome'
            Assert.True(_command.Invalid, "O nome do usuário está correto");
        }

        [Fact]
        public void ErroCasoEmailCommandInvalido()
        {
            var _command = new CriarUsuarioCommand("Nome command", "", "123456", "11962553590", EnTipoPerfil.Comum);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao inserir um novo command de usuário
            //devido a falta de um resultado para o parametro 'email'
            Assert.True(_command.Invalid, "O email de usuário está correto");
        }

        [Fact]
        public void ErroCasoSenhaCommandInvalida()
        {
            var _command = new CriarUsuarioCommand("Nome command", "emailcommand@email.com", "", "1162553590", EnTipoPerfil.Comum);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao inserir um novo command de usuário
            //devido a falta de um resultado para o parametro 'senha'
            Assert.True(_command.Invalid, "A senha informada está correta");
        }

        [Fact]
        public void SucessoCasoDadosCommandValidosSemTelefone()
        {
            var _command = new CriarUsuarioCommand("Nome command", "emailcommand@email.com", "123456", "", EnTipoPerfil.Comum);

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao inserir um novo usuário
            Assert.True(_command.Valid, "Os dados estão incorretos");
        }

        [Fact]
        public void SucessoCasoDadosCommandValidosComTelefone()
        {
            var _command = new CriarUsuarioCommand("Nome command", "emailcommand@email.com", "123456", "11962553590", EnTipoPerfil.Comum);

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao inserir um novo usuário
            Assert.True(_command.Valid, "Os dados estão incorretos");
        }
    }
}
