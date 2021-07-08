using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Comum.Entidades
{
    public class Administrador : Entidade
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
