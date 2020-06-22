namespace Restaurante_exercicio
{
    public class Restaurante
    {
        public string NomeRestaurante {get; set;}

        public string Endereco {get; set;}



        public Restaurante(string _nomeRestaurante){

            this.NomeRestaurante = _nomeRestaurante;
        }

        public string MostrarDados(){

            return $"Restaurante : {NomeRestaurante}, endereco : {Endereco}";
        }
    }
}