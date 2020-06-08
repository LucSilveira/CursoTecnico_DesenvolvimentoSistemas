using System;

namespace Exercico_override
{
    class Program
    {
        static void Main(string[] args)
        {
            RelatorioMensal relatoriomsl = new RelatorioMensal();

            Console.WriteLine("\n\nRelatório mensal\n");
            relatoriomsl.MostrarRelatorio();

            RelatorioAnual relatorioanl = new RelatorioAnual();

            Console.WriteLine("\n\nRelatório anual\n");
            relatorioanl.MostrarRelatorio();
        }
    }
}
