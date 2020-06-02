using System;

namespace Abstracao_loja
{
    public class Pagamento
    {
        public DateTime data { get; set; }

        public float valor { get; set; }


        public string Pagar(){

            return "Pagamento efetuado";
        }

        public string Cancelar(){

            return "Pagamento cancelado";
        }
    }
}