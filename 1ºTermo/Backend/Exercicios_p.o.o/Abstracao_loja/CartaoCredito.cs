namespace Abstracao_loja
{
    public class CartaoCredito : Cartao
    {
        public float limite { get; set; }

        public float AumentarLimite( float limiteAtual, float acrescimo ){

            return limiteAtual + acrescimo;
        }

        public string BloquearCartao(){

            return "Cartão bloqueado";
        }
    }
}