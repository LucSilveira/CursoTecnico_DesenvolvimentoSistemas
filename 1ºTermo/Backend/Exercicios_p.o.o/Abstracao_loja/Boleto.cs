using System;

namespace Abstracao_loja
{
    public class Boleto : Pagamento
    {
        
        public DateTime dataVencimento { get; set; }

        public string bancoEmissor { get; set; }
        
        public string codBarras { get; set; }

        public string RegistrarSistema(){

            return "";
        }

    }
}