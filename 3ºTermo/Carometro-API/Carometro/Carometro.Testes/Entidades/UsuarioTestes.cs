using Carometro.Comum.Enum;
using Carometro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Carometro.Testes.Entidades
{
    public class UsuarioTestes
    {
            
        [Fact]
        public void Usuario()
        {

            var usuario = new Admin("Ga", "gabriel@kdj.com", "1234", "11989877709");
            Assert.True(usuario.Invalid, "Usuario é valido");

        }

        [Fact]
        public void DeveRetornarErroNoEmail()
        {

            var usuario = new Admin("Gab", "gabrielkdj.com", "1234", "11989877709");
            Assert.True(usuario.Valid, "Usuario é valido");

        }


    }
}
