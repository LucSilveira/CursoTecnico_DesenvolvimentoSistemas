using CodeTur.Comum.Enum;
using CodeTur.Dominio.Commands.Comentarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands.Comentarios
{
    public class AlterarStatusComentarioCommandTestes
    {
        [Fact]
        public void ErroCasoDadosAlterarStatusCommandInvalidos()
        {
            var _command = new AlterarStatusComentarioCommand(Guid.Empty, EnStatusComentario.Publicado);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um comentario
            //devido a falta de um resultado para o parametro 'id do comentario'
            Assert.True(_command.Invalid, "Os dados estão corretos");
        }

        [Fact]
        public void SucessoCasoDadosAlterarStatusCommandValidos()
        {
            var _command = new AlterarStatusComentarioCommand(Guid.NewGuid(), EnStatusComentario.Publicado);

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao alterar um comentario
            Assert.True(_command.Valid, "Os dados estão incorretos");
        }
    }
}
