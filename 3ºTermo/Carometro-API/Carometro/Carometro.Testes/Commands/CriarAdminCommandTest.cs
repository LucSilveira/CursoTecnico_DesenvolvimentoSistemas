using Carometro.Dominio.Commands.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Carometro.Testes.Commands
{
    public class CriarAdminCommandTest
    {
        [Fact]
        public void DeveRetornarErroSeDadosInvalidos()
        {

            var command = new CadastrarContaCommand();

            command.Validar();

            Assert.True(command.Valid, "Os dados estão preenchidos corretamente");

        }

    }
}
