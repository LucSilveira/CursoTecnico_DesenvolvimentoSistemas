namespace Exercicio_heranca
{
    public class Pessoa
    {
        public string nome { get; set; }

        public string rg { get; set; }

        public string Saudacao(){

            return $"Seja bem vindo {nome}";
        }
    }
}