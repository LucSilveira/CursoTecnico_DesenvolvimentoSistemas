using CodeTur.Comum.Enum;
using CodeTur.Dominio.Commands.Comentarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands.Comentarios
{
    public class AlterarComentarioCommandTestes
    {
        [Fact]
        public void ErroCasoDadosAlterarComentarioInvalidos()
        {
            var _command = new AlterarComentarioCommand(Guid.Empty, Guid.Empty, "", "", EnStatusComentario.Inapropriado);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um comentario
            //devido a falta de um resultado para o parametro 'id do usuário', 'id do pacote', 'texto', 'sentimento'
            Assert.True(_command.Invalid, "Os dados estão corretos");
        }

        [Fact]
        public void ErroCasoIdUsuarioAlterarComentarioInvalido()
        {
            var _command = new AlterarComentarioCommand(Guid.Empty, Guid.NewGuid(), "Pacote muito excepcional", "Feliz", EnStatusComentario.Inapropriado);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um comentario
            //devido a falta de um resultado para o parametro 'id do usuário'
            Assert.True(_command.Invalid, "O id do usuário está correto");
        }

        [Fact]
        public void ErroCasoIdPacoteAlterarComentarioInvalido()
        {
            var _command = new AlterarComentarioCommand(Guid.NewGuid(), Guid.Empty, "Pacote muito excepcional", "Feliz", EnStatusComentario.Inapropriado);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um comentario
            //devido a falta de um resultado para o parametro 'id do pacote'
            Assert.True(_command.Invalid, "O id do pacote está correto");
        }

        [Fact]
        public void ErroCasoTextoAlterarComentarioInvalido()
        {
            var _command = new AlterarComentarioCommand(Guid.NewGuid(), Guid.NewGuid(), "", "Feliz", EnStatusComentario.Inapropriado);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um comentario
            //devido a falta de um resultado para o parametro 'texto'
            Assert.True(_command.Invalid, "O texto está correto");
        }

        [Fact]
        public void ErroCasoSentimentoAlterarComentarioInvalido()
        {
            var _command = new AlterarComentarioCommand(Guid.NewGuid(), Guid.NewGuid(), "Pacote muito excepcional", "", EnStatusComentario.Inapropriado);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um comentario
            //devido a falta de um resultado para o parametro 'sentimento'
            Assert.True(_command.Invalid, "O sentimento está correto");
        }

        [Fact]
        public void SucessoCasoDadosAlterarComentarioValidos()
        {
            var _command = new AlterarComentarioCommand(Guid.NewGuid(), Guid.NewGuid(), "Pacote muito excepcional", "Feliz", EnStatusComentario.Inapropriado);

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao alterar um comentario
            Assert.True(_command.Valid, "Os dados estão incorretos");
        }
    }
}
