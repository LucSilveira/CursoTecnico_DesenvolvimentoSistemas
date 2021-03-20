using CodeTur.Dominio.Commands.Pacotes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands.Pacotes
{
    public class AlterarPacoteCommandTestes
    {
        [Fact]
        public void ErroCasoDadosAlterarPacoteCommandInvalidos()
        {
            var _command = new AlterarPacoteCommand(Guid.Empty, "", "");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um pacote
            //devido a falta de um resultado para o parametro 'id do pacote', 'titulo', 'descricao'
            Assert.True(_command.Invalid, "Os dados estão corretos");
        }

        [Fact]
        public void ErroCasoIdAlterarPacoteCommandInvalido()
        {
            var _command = new AlterarPacoteCommand(Guid.Empty, "Novo pacote cadastrado", "Pacote muito excepcional!");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um pacote
            //devido a falta de um resultado para o parametro 'id do pacote'
            Assert.True(_command.Invalid, "O id do pacote está correto");
        }

        [Fact]
        public void ErroCasoTituloAlterarPacoteCommandInvalido()
        {
            var _command = new AlterarPacoteCommand(Guid.NewGuid(), "", "Pacote muito excepcional!");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um pacote
            //devido a falta de um resultado para o parametro 'titulo'
            Assert.True(_command.Invalid, "O título do pacote está correto");
        }

        [Fact]
        public void ErroCasoDescricaoAlterarPacoteCommandInvalido()
        {
            var _command = new AlterarPacoteCommand(Guid.NewGuid(), "Novo pacote cadastrado", "");

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao alterar um pacote
            //devido a falta de um resultado para o parametro 'descricao'
            Assert.True(_command.Invalid, "A descrição do pacote está correto");
        }

        [Fact]
        public void SucessoCasoDadosAlterarPacoteCommandValidos()
        {
            var _command = new AlterarPacoteCommand(Guid.NewGuid(), "Novo pacote cadastrado", "Pacote muito excepcional!");

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao alterar um pacote
            Assert.True(_command.Valid, "Os dados estão incorretos");
        }
    }
}
