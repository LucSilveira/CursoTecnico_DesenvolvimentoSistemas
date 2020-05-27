using System;

namespace Laco_notas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao nosso sistema:\n\n");

            // entrada
            System.Console.WriteLine("Por favor, informe uma nota:");
            System.Console.WriteLine("Condições : menor que 10 e maior que 0!");
            double notaInformada = double.Parse(Console.ReadLine());

            // processamento
            while(notaInformada < 0 || notaInformada > 10){

                System.Console.WriteLine("\n\nNota inválida, por favor verificar\nas condições informadas!");
                System.Console.WriteLine("\n\nInforme a nota novamente:");
                notaInformada = double.Parse(Console.ReadLine());
            }

            // saída
            System.Console.WriteLine("\n\nMuito obrigado pela preferencia, volte sempre!");
        }
    }
}
