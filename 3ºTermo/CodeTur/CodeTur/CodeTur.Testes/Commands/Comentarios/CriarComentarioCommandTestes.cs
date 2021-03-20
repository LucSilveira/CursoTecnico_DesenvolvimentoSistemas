using CodeTur.Comum.Enum;
using CodeTur.Dominio.Commands.Comentarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands.Comentarios
{
    public class CriarComentarioCommandTestes
    {
        [Fact]
        public void ErroCasoDadosCriarComentarioCommandInvalidos()
        {
            var _command = new CriarComentarioCommand("", "", EnStatusComentario.Inapropriado, Guid.Empty, Guid.Empty);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao inserir um novo comentario
            //devido a falta de um resultado para o parametro 'texto', 'sentimento', 'status', 'id do usuário', 'id do pacote'
            Assert.True(_command.Invalid, "Os dados estão corretos");
        }

        [Fact]
        public void ErroCasoTextoCriarComentarioCommandInvalido()
        {
            var _command = new CriarComentarioCommand("", "Feliz", EnStatusComentario.Inapropriado, Guid.NewGuid(), Guid.NewGuid());

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao inserir um novo comentario
            //devido a falta de um resultado para o parametro 'texto'
            Assert.True(_command.Invalid, "O texto está correto");
        }

        [Fact]
        public void ErroCasoSentimentoCriarComentarioCommandInvalido()
        {
            var _command = new CriarComentarioCommand("Pacote excepcional", "", EnStatusComentario.Inapropriado, Guid.NewGuid(), Guid.NewGuid());

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao inserir um novo comentario
            //devido a falta de um resultado para o parametro 'sentimento'
            Assert.True(_command.Invalid, "O sentimento está correto");
        }

        [Fact]
        public void ErroCasoIdUsuarioCriarComentarioCommandInvalido()
        {
            var _command = new CriarComentarioCommand("Pacote excepcional", "Feliz", EnStatusComentario.Inapropriado, Guid.Empty, Guid.NewGuid());

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao inserir um novo comentario
            //devido a falta de um resultado para o parametro 'id do usuário'
            Assert.True(_command.Invalid, "O id do usuário está correto");
        }

        [Fact]
        public void ErroCasoIdPacoteCriarComentarioCommandInvalidos()
        {
            var _command = new CriarComentarioCommand("Pacote excepcional", "Feliz", EnStatusComentario.Inapropriado, Guid.NewGuid(), Guid.Empty);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao inserir um novo comentario
            //devido a falta de um resultado para o parametro 'id do pacote'
            Assert.True(_command.Invalid, "O id do pacote está correto");
        }

        [Fact]
        public void SucessoCasoDadosCriarComentarioCommandValidos()
        {
            var _command = new CriarComentarioCommand("Pacote muito excepcional", "Feliz", EnStatusComentario.Inapropriado, Guid.NewGuid(), Guid.NewGuid());

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao inserir um novo comentario
            Assert.True(_command.Valid, "O sentimento está correto");
        }
    }
}
