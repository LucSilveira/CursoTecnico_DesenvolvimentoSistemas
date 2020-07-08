using System;
using System.Collections.Generic;

namespace Csv_file
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Produto prod = new Produto();

            prod.Codigo = 007;
            prod.Nome = "xyaz";
            prod.Preco = 11112f;

            prod.Cadastrar(prod);
            prod.RemoverLinhas("xyz");

            Produto alterado = new Produto();
            alterado.Codigo = 005;
            alterado.Nome = "mno";
            alterado.Preco = 11111f;

            prod.Alterar(alterado);

            List<Produto> lista = prod.LerProdutos();

            foreach (Produto item in lista)
            {
                System.Console.WriteLine($"R$ {item.Preco} - {item.Nome}");
            }
        }
    }
}
