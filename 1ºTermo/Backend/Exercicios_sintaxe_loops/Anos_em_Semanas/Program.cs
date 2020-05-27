using System;

namespace Anos_em_Semanas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculando quantas semenas de vida você possui: \n");

            Console.WriteLine("Informe a data de seu nascimento:");
            DateTime dataNascimento = new DateTime();
            dataNascimento = DateTime.Parse(Console.ReadLine());

            DateTime dataAtual = new DateTime();
            dataAtual = DateTime.Now;

            // Verificando se a data de nascimento não é maior do que hoje
            if(dataNascimento >= dataAtual){
                Console.WriteLine("Data de nascimento inválida");
    
            }else{

                int anosUsuario = 0;
                int semanasUsuario = 0;

                // Calculando os anos da pessoa
                anosUsuario = dataAtual.Year - dataNascimento.Year;

                // Calculando a quantidade de semanas que a pessoa possui
                semanasUsuario = (anosUsuario * 365) / 7;


                Console.WriteLine("\n\n Exibindo o resultado ...");
                Console.WriteLine($"Você possui : " + anosUsuario + " anos vividos");
                Console.WriteLine($"Você possui : " + semanasUsuario + " semanas vividas");
            }
        }
    }
}
