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
            prod.Nome = "Apple TV";
            prod.Preco = 1800f;

            prod.Cadastrar(prod);

            List<Produto> lista = prod.LerProdutos();

            foreach (Produto item in lista)
            {
                System.Console.WriteLine($"R$ {item.Preco} - {item.Nome}");
            }
        }
    }
}
