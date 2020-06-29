using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Carrinho carrinho = new Carrinho();

            Produto prod1 = new Produto();
            prod1.Codigo = 01;
            prod1.Nome = "Xbox 360";
            prod1.Preco = 1500.00f;

            carrinho.Incluir(prod1);


            Produto prod2 = new Produto();
            prod2.Codigo = 02;
            prod2.Nome = "Xbox One";
            prod2.Preco = 2500.00f;

            carrinho.Incluir(prod2);


            carrinho.Ler();

            prod2.Nome = "Xbox One X";
            prod2.Preco = 2550.90f;
            carrinho.Alterar(2, prod2);

            carrinho.Ler();

            carrinho.Excluir(prod1);

            carrinho.Ler();
        }
    }
}
