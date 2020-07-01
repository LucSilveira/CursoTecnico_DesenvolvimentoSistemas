using System;
using System.Collections.Generic;

namespace Csv_file
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Produto prod = new Produto();

            prod.Codigo = 001;
            prod.Nome = "Npx";
            prod.Preco = 10000f;

            prod.Cadastrar(prod);
            prod.RemoverLinhas("Macbook Pro");

            List<Produto> lista = prod.LerProdutos();

            foreach (Produto item in lista)
            {
                System.Console.WriteLine($"R$ {item.Preco} - {item.Nome}");
            }

            Console.WriteLine(prod.BuscarProduto("Npx") + " lsdm ");
        }
    }
}
