using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Carrinho carrinho = new Carrinho();

            Produto prod1 = new Produto(1, "Read Dead Redemption 2", 499f);
            Produto prod2 = new Produto(2, "Gta 5", 60.90f);
            Produto prod3 = new Produto(3, "Pac man", 0f);

            carrinho.AdicionarProduto(prod1);
            carrinho.AdicionarProduto(prod2);
            carrinho.AdicionarProduto(prod3);

            prod2.Nome = "GTA V";
            prod2.Preco = 80f;
            carrinho.Alterar(2, prod2);

            carrinho.RemoverProduto(prod3);
            carrinho.MostrarProdutos();
            carrinho.MostrarTotal();
        }
    }
}
