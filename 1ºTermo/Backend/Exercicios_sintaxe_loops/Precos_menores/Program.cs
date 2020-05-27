using System;

namespace Precos_menores
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao sistema econoBom");
            Console.WriteLine("Onde seu dinheiro importa!!\n\n");

            // entradas
            System.Console.WriteLine("Por favor, informe o valor do seu primeiro produto:");
            double produto1 = double.Parse(Console.ReadLine());

            System.Console.WriteLine("\nPor favor, informe o valor do segundo produto:");
            double produto2 = double.Parse(Console.ReadLine());

            System.Console.WriteLine("\nPor favor, informe o valor do terceiro produto:");
            double produto3 = double.Parse(Console.ReadLine());

            double menorProduto = produto1;

            // processamento
            if(produto2 <  produto1){

                menorProduto = produto2;
            }

            if(produto3 < produto2){

                menorProduto = produto3;
            }

            // saida
            System.Console.WriteLine($"\nCom base em nossas análises,\no preço mais acessivel é o de R${menorProduto}");
        }
    }
}
