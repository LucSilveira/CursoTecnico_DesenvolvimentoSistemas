using CodeTur.Dominio.Commands.Pacotes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands.Pacotes
{
    public class AlterarImagemPacoteCommandTestes
    {
        [Fact]
        public void ErroCasoDadosAlterarImagemCommandInvalidos()
        {
            var _command = new AlterarImagemPacoteCommand(Guid.Empty, "");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um novo pacote
            //devido a falta de um resultado para o parametro 'id do pacote', 'imagem'
            Assert.True(_command.Invalid, "Os dados estão corretos");
        }

        [Fact]
        public void ErroCasoIdAlterarImagemCommandInvalido()
        {
            var _command = new AlterarImagemPacoteCommand(Guid.Empty, "pacote.jpg");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um novo pacote
            //devido a falta de um resultado para o parametro 'id do pacote'
            Assert.True(_command.Invalid, "O id do pacote está válido");
        }

        [Fact]
        public void ErroCasoImagemAlterarImagemCommandInvalidos()
        {
            var _command = new AlterarImagemPacoteCommand(Guid.NewGuid(), "");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um novo pacote
            //devido a falta de um resultado para o parametro 'imagem'
            Assert.True(_command.Invalid, "A imagem alterada está correta");
        }

        [Fact]
        public void SucessoCasoDadosAlterarImagemCommandValidos()
        {
            var _command = new AlterarImagemPacoteCommand(Guid.NewGuid(), "pacote.jpg");

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao alterar um novo pacote
            Assert.True(_command.Valid, "Os dados estão incorretos");
        }
    }
}
