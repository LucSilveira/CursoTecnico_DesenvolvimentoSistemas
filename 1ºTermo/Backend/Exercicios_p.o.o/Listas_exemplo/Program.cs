using System;

namespace Listas_exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> produtos = new List<Produto>();

            //Adicionando de forma mais manual possivel
            Produto prod = new Produto();
            prod.Codigo = 1;
            prod.Nome = "Iphone X";
            prod.Preco = 3500f;

            // Adicionando os produtos na lista
            produtos.Add(prod);

            // Adicionando os produtos de forma mais automatica
            produtos.Add(new Produto(2, "Xiaomi", 2200.90f));
            produtos.Add(new Produto(3, "Galaxy", 1800.90f));
            produtos.Add(new Produto(4, "Asus", 2000.90f));
            produtos.Add(new Produto(5, "ZenFone", 2250.90f));


            // Listando todos os produtos que contém na lista
            foreach(Produto prd in produtos)
            {
                Console.WriteLine($"R$: {prd.Preco} - {prd.Nome}");
            }


            // como remover itens da lista
            produtos.Remove(prod);

            produtos.RemoveAt(1);

            produtos.RemoveAll( x => x.Nome = "Xiaomi")
        }
    }
}
