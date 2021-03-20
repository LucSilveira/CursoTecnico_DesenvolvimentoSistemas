using CodeTur.Dominio.Commands.Pacotes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands.Pacotes
{
    public class AlterarStatusPacoteCommandTestes
    {
        [Fact]
        public void ErroCasoDadosAlterarStatusPacoteCommandInvalidos()
        {
            var _command = new AlterarStatusPacoteCommand(Guid.Empty, false);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um pacote
            //devido a falta de um resultado para o parametro 'id do pacote'
            Assert.True(_command.Invalid, "Os dados estão corretos");
        }

        [Fact]
        public void SucessoCasoDadosAlterarStatusPacoteCommandValidos()
        {
            var _command = new AlterarStatusPacoteCommand(Guid.NewGuid(), true);

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao alterar um pacote
            Assert.True(_command.Valid, "Os dados estão incorretos");
        }
    }
}
