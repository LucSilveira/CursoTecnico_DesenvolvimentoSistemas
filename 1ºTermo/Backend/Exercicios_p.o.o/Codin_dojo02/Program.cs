using System;

namespace Codin_dojo02
{
    class Program
    {
        static void Main(string[] args)
        {
            IngressoVip bilhete = new IngressoVip();
            bilhete.Valor = 20f;
            bilhete.ValorAdicional = 15.50f;
            bilhete.ImprimirValor();
            bilhete.ImprimirValorVip();

            System.Console.WriteLine($"A diferença entre valors é R$:{bilhete.ValorAdicional}");
        }
    }
}
