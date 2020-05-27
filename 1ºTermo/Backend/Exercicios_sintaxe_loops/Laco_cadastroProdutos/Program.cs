using System;

namespace Laco_cadastroProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cadastro de produtos!!\n\n");

            System.Console.WriteLine("Quantos produtos você deseja cadastrar?");
            int numeroProdutos = Int32.Parse(Console.ReadLine());

            double precoProduto = 0;
            string nomeProduto;

            while(numeroProdutos > 0){
                
                Console.WriteLine("\nInforme o nome do produto:");
                nomeProduto = Console.ReadLine();

                Console.WriteLine("\nInforme o preço do produto:");
                precoProduto = double.Parse(Console.ReadLine());

                Console.WriteLine($"\n\nNome do produto: {nomeProduto}, preço do produto: R${precoProduto}");
                Console.WriteLine("Cadastrado com sucesso!!!");

                numeroProdutos--;
            }

            Console.WriteLine("\n\nObrigado por usar nosso sistema ;-D");
        }
    }
}
