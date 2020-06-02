using System;

namespace Abstracao_loja
{
    public class Pagamento
    {
        public DateTime data { get; set; }

        public float valor { get; set; }


        public string Pagar( float valor ){

            return "Pagamento efetuado no valor de " + valor;
        }

        public string Cancelar(){

            return "Pagamento cancelado";
        }
    }
}