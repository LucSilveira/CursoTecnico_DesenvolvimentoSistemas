using System.Collections.Generic;
using Mvc_exemplo.Models;
using Mvc_exemplo.Views;

namespace Mvc_exemplo.Controllers
{
    public class ProdutoController
    {
        Produto produtoModel = new Produto();
        ProdutoView produtoView = new ProdutoView();
    
        public void Listar()
        {
            produtoView.MostrarNoConsole(produtoModel.LerProdutos());
        }

        public void BuscarProdutos(string _preco)
        {
            List<Produto> listaBusca = produtoModel.LerProdutos().FindAll(x => x.Preco == float.Parse(_preco));
            produtoView.MostrarNoConsole(listaBusca);
        }
    }
}