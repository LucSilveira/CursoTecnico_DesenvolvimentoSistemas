using System;

namespace StaticExemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            System.Console.WriteLine(Conversor.ConversorDolarEmReal(25f));
            System.Console.WriteLine(Conversor.ConversorRealEmDolar(250f));

            System.Console.WriteLine($"\n{Conversor.ConversorEuroEmReal(25f)}");
            System.Console.WriteLine(Conversor.ConversorRealEmEuro(250f));
        }
    }
}
