using System;

namespace Posicoes_numeros
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao nosso sistema!\n\n");

            // Entradas
            Console.WriteLine("Por favor, insira o primeiro número ao seu gosto:");
            double numero1 = double.Parse(Console.ReadLine());

            Console.WriteLine("\nPor favor, insira o segundo número ao seu gosto:");
            double numero2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Por favor, insira o terceiro número ao seu gosto:");
            double numero3 = double.Parse(Console.ReadLine());

            double maiorNumero = numero1;

            // Processamento
            if(numero2 > numero1){

                maiorNumero = numero2;
            }

            if(numero3 > numero2){

                maiorNumero = numero3;
            }

            // Saída
            System.Console.WriteLine($"Maior número é: " + maiorNumero);

        }
    }
}
