using System;

namespace Laco_numeros
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculando numeros\n\n");

            Console.WriteLine("Informe um número ao seu desejo:");
            int numeroInformado = Int32.Parse(Console.ReadLine());

            int espaco = 1;

            Console.WriteLine("\nMostrando os espaços entre o número escolhido e 0\n");
            Console.WriteLine("-> 0");
            while(numeroInformado != espaco){

                Console.WriteLine(espaco);

                espaco++;
            }
           Console.WriteLine($"-> {numeroInformado}");
        }
    }
}
