using System;

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
        }
    }
}
