namespace Encapsulamento_exercicio
{
    public class MasterCard : Cartao
    {
        public int parcelas { get; set; }

        public void ComprarDescontoMasterCard( float desconto ){

            System.Console.WriteLine($"Aplicando um desconto de {desconto}, no total de {parcelas} parcelas");
        }
    }
}