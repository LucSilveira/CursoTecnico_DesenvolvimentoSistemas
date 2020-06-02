namespace Abstracao_loja
{
    public class CartaoDebito
    {
        public float saldo { get; set; }

        
        public string PagarTitulo(){

            return "Titulo, pago com cartão de débito";
        }

        public string Transferir(float valor){

            return $"R$ {valor} tranferido para sua conta";
        }
    }
}