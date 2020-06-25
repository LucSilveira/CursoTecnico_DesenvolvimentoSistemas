using System;

namespace Recursividade
{
    class Program
    {
        static void Main(string[] args)
        {
            Recursividade recur = new Recursividade();
            recur.GerarSequenciaFibonacci(0, 1, 15);
            System.Console.WriteLine($"\n {recur.GerarFatorial(3)}");
        }
    }
}
