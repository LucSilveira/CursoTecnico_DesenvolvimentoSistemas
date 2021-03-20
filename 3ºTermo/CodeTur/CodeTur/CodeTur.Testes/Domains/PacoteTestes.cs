using CodeTur.Comum.Enum;
using CodeTur.Dominio.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Domains
{
    public class PacoteTestes
    {
        [Fact]
        public void ErroCasoDadosPacoteInvalidos()
        {
            var _pacote = new Pacote("", "", "", false);

            //Espera erro ao inserir um novo pacote
            //devido a falta de um resultado para o parametro 'titulo', 'descricao', 'imagem'
            Assert.True(_pacote.Invalid, "Dados do pacote válidos");
        }

        [Fact]
        public void ErroCasoTituloPacoteInvalido()
        {
            var _pacote = new Pacote("", "Pacote para viagem nas ilhas maldivas com hospedagem e café da manhã incluso", "maldivas.jpg", false);

            //Espera erro ao inserir um novo pacote
            //devido a falta de um resultado para o parametro 'titulo'
            Assert.True(_pacote.Invalid, "Titulo do pacote válido");
        }

        [Fact]
        public void ErroCasoDescricaoPacoteInvalido()
        {
            var _pacote = new Pacote("Viagem as ilhas maldivas", "", "maldivas.jpg", false);

            //Espera erro ao inserir um novo pacote
            //devido a falta de um resultado para o parametro 'descricao'
            Assert.True(_pacote.Invalid, "Dados do pacote válidos");
        }

        [Fact]
        public void ErroCasoImagemPacoteInvalidos()
        {
            var _pacote = new Pacote("Viagem as ilhas maldivas", "Pacote para viagem nas ilhas maldivas com hospedagem e café da manhã incluso", "", false);

            //Espera erro ao inserir um novo pacote
            //devido a falta de um resultado para o parametro 'imagem'
            Assert.True(_pacote.Invalid, "Imagem do pacote válido");
        }

        [Fact]
        public void SucessoCasoDadosPacoteValidos()
        {
            var _pacote = new Pacote("Viagem as ilhas maldivas", "Pacote para viagem nas ilhas maldivas com hospedagem e café da manhã incluso", "maldivas.jpg", true);

            //Espera sucesso ao inserir um novo pacote
            Assert.True(_pacote.Valid, "Dados do pacote inválidos");
        }
    }
}
