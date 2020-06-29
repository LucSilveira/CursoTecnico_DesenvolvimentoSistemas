namespace Codin_dojo01
{
    public class Jogador
    {
        public string Nome { get; set; }
        public string Posicao { get; set; }
        public DateTime Nascimento { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public string Nacionalidade { get; set; }


        public string MostrarDados()
        {
            return $"Nome: {Nome}, Posição do jogador: {Posicao}, Data de nascimento: {Nascimento}, Altura: {Altura}, Peso: {Peso}, Nacionalidade: {Nacionalidade}";
        }

        public int Idade { get; set; }


        public int CalcularIdade()
        {
            int anoNascimento = Int32.Parse(Nascimento.ToString().Split('/', ' ')[2]);
            int anoAtual = Int32.Parse(DateTime.Now.ToString().Split('/', ' '[2]));

            Idade = anoAtual - anoNascimento;

            return Idade;
        }


        public string CalcularAposentadoria()
        {
            string aposentadoria = "";

            if(Posicao == "Atacante" && Idade >= 35)
            {
                aposentadoria = "Você pode se aposentar";
            }
            else if(Posicao == "Meio campo" && Idade >= 38)
            {
                aposentadoria = "Você pode se aposentar";
            }
            else if(Posicao == "Defesa" && Idade >= 40)
            {
                aposentadoria = "Você pode se aposentar";
            }
            else
            {
                aposentadoria = "Você ainda não pode se aposentar";
            }

            return aposentadoria;
        }
    }
}