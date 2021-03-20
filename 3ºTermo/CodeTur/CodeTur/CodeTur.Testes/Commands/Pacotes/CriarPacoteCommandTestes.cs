using CodeTur.Dominio.Commands.Pacotes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands.Pacotes
{
    public class CriarPacoteCommandTestes
    {
        [Fact]
        public void ErroCasoDadosCriarPacoteCommandInvalidos()
        {
            var _command = new CriarPacoteCommand("", "", "", false);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao inserir um novo pacote
            //devido a falta de um resultado para o parametro 'titulo', 'descricao', 'imagem'
            Assert.True(_command.Invalid, "Os dados estão corretos");
        }

        [Fact]
        public void ErroCasoTituloCriarPacoteCommandInvalido()
        {
            var _command = new CriarPacoteCommand("", "Pacote muito excepcional", "pacote.jpg", true);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao inserir um novo pacote
            //devido a falta de um resultado para o parametro 'titulo'
            Assert.True(_command.Invalid, "O título informado está correto");
        }

        [Fact]
        public void ErroCasoDescricaoCriarPacoteCommandInvalidos()
        {
            var _command = new CriarPacoteCommand("Pacote excluivo para novos usuários", "", "pacote.jpg", false);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao inserir um novo pacote
            //devido a falta de um resultado para o parametro 'descricao'
            Assert.True(_command.Invalid, "A descrição informada está correta");
        }

        [Fact]
        public void ErroCasoImagemCriarPacoteCommandInvalidos()
        {
            var _command = new CriarPacoteCommand("Pacote excluivo para novos usuários", "Pacote muito excepcional", "", false);

            //Validando os campos informados
            _command.Validar();

            //Espera erro ao inserir um novo pacote
            //devido a falta de um resultado para o parametro 'imagem'
            Assert.True(_command.Invalid, "A imagem informada está correta");
        }

        [Fact]
        public void SucessoCasoDadosCriarPacoteCommandValidos()
        {
            var _command = new CriarPacoteCommand("Pacote excluivo para novos usuários", "Pacote muito excepcional!", "pacote.jpg", true);

            //Validando os campos informados
            _command.Validar();

            //Espera sucesso ao inserir um novo pacote
            Assert.True(_command.Valid, "Os dados estão incorretos");
        }
    }
}
