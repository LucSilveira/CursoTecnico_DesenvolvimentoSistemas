using CodeTur.Dominio.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Domains
{
    public class UsuarioTestes
    {
        [Fact]
        public void ErroCasoDadosUsuarioInvalido()
        {
            var _usuario = new Usuario("", "", "", Comum.Enum.EnTipoPerfil.Comum);

            //Espera erro ao inserir um novo usuário
            //devido a falta de um resultado para o parametro 'nome', 'email', 'senha'
            Assert.True(_usuario.Invalid, "Dados de usuário válidos");
        }

        [Fact]
        public void ErroCasoNomeUsuarioInvalido()
        {
            var _usuario = new Usuario("", "email@emai.com", "123456", Comum.Enum.EnTipoPerfil.Comum);

            //Espera erro ao inserir um novo usuário
            //devido a falta de um resultado para o parametro 'nome'
            Assert.True(_usuario.Invalid, "Nome de usuário válido");
        }

        [Fact]
        public void ErroCasoEmailUsuarioInvalido()
        {
            var _usuario = new Usuario("Nome qualquer", "email.com", "123456", Comum.Enum.EnTipoPerfil.Comum);

            //Espera erro ao inserir um novo usuário
            //devido o valor informado ser incorreto no padrão de um email
            Assert.True(_usuario.Invalid, "Email de usuário válido");
        }

        [Fact]
        public void ErroCasoSenhaUsuarioInvalido()
        {
            var _usuario = new Usuario("Nome qualquer", "email@emai.com", "", Comum.Enum.EnTipoPerfil.Comum);

            //Espera erro ao inserir um novo usuário
            //devido a falta de um resultado para o parametro 'senha'
            Assert.True(_usuario.Invalid, "Senha de usuário válido");
        }

        [Fact]
        public void ErroCasoTelefoneUsuarioInvalido()
        {
            var _usuario = new Usuario("Nome qualquer", "email@emai.com", "123456", Comum.Enum.EnTipoPerfil.Comum);
            _usuario.AdicionarTelefone("1195568");

            //Espera erro ao inserir um novo usuário
            //devido a falta de um resultado para o parametro 'telefone'
            Assert.True(_usuario.Invalid, "Telefone de usuário válido");
        }

        [Fact]
        public void SucessoCasoDadosUsuarioValidos()
        {
            var _usuario = new Usuario("Nome qualquer", "email@email.com", "123456", Comum.Enum.EnTipoPerfil.Comum);
            _usuario.AdicionarTelefone("+5511980985567");

            //Espera sucesso ao inserir um novo usuário
            Assert.True(_usuario.Valid, "Dados de usuário inválidos");
        }
    }
}
