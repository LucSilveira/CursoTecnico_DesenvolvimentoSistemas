using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao sistema de fibonacci!\n");
            System.Console.WriteLine("Aguarde enquanto calculamos os resultados...\n\n");

            int numero1 = 0;
            int numero2 = 1;
            int fibonacci = 0;

            System.Console.WriteLine(numero1);
            System.Console.WriteLine(numero2);

            while(fibonacci <= 500){

                fibonacci = numero2 + numero1;
                numero1 = numero2;
                numero2 = fibonacci;

                System.Console.WriteLine(fibonacci);
            }

        }
    }
}
