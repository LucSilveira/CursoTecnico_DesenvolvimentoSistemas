using CodeTur.Comum.Enum;
using CodeTur.Dominio.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Domains
{
    public class ComentarioTestes
    {
        [Fact]
        public void ErroCasoDadosComentarioInvalido()
        {
            var _comentario = new Comentario("", "", Guid.NewGuid(), Guid.NewGuid(), Comum.Enum.EnStatusComentario.Inapropriado);

            //Espera erro ao inserir um novo comentario
            //devido a falta de um resultado para o parametro 'texto', 'sentimento', 'id de usuario',
            //'id do pacote', 'status'
            Assert.True(_comentario.Invalid, "Dados do comentário válidos");
        }

        [Fact]
        public void ErroCasoTextoComentarioInvalido()
        {
            var _comentario = new Comentario("", "feliz", Guid.NewGuid(), Guid.NewGuid(), Comum.Enum.EnStatusComentario.Inapropriado);

            //Espera erro ao inserir um novo comentario
            //devido a falta de um resultado para o parametro 'texto'
            Assert.True(_comentario.Invalid, "Texto do comentário válido");
        }

        [Fact]
        public void ErroCasoSentimentoComentarioInvalido()
        {
            var _comentario = new Comentario("Muito bom o pacote", "", Guid.NewGuid(), Guid.NewGuid(), Comum.Enum.EnStatusComentario.Inapropriado);

            //Espera erro ao inserir um novo comentario
            //devido a falta de um resultado para o parametro 'sentimento'
            Assert.True(_comentario.Invalid, "Sentimento do comentário válido");
        }

        [Fact]
        public void SucessoCasoDadosComentarioValido()
        {
            var _comentario = new Comentario("Pacote muito excelente", "Feliz", Guid.NewGuid(), Guid.NewGuid(), EnStatusComentario.Publicado);

            //Espera sucesso ao inserir um novo comentario
            Assert.True(_comentario.Valid, "Dados do comentário inválidos");
        }
    }
}
