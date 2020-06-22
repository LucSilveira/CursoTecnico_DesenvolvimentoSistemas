namespace Restaurante_exercicio
{
    public class Cliente
    {
        public string NomeCliente { get; set; }

        public string Endereco { get; set; }


        public Cliente(string _nomeCliente){

            this.NomeCliente = _nomeCliente;
        }

        public string MostrarDados(){

            return $"Cliente : {NomeCliente}, endereco : {Endereco}";
        }
    }
}