using System;

namespace Exercicio_overload
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculos player = new Calculos();

            System.Console.WriteLine(player.Calcular());

            System.Console.WriteLine(player.Calcular(100));

            System.Console.WriteLine(player.Calcular(100, 50));

            System.Console.WriteLine(player.Calcular(100, 50, 70));
        }
    }
}
