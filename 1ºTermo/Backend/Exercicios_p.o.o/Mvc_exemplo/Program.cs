using System;
using Mvc_exemplo.Controllers;

namespace Mvc_exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            ProdutoController controller = new ProdutoController();

            controller.BuscarProdutos("11112");
        }
    }
}
