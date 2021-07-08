using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Entidades
{
    public class Curriculo
    {
        public Curriculo()
        {
            NaoTenhoExperiencia = false;
        }

        public string UltimaEmpresa { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Cargo { get; set; }
        public string DescricaoFuncao { get; set; }
        public bool NaoTenhoExperiencia { get; set; }
    }
}
