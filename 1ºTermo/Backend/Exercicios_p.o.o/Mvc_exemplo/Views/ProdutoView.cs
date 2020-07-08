using System;
using System.Collections.Generic;
using Mvc_exemplo.Models;

namespace Mvc_exemplo.Views
{
    public class ProdutoView
    {
        public void MostrarNoConsole(List<Produto> _listaProduto)
        {
            foreach (Produto produto in _listaProduto)
            {
                Console.WriteLine($"Produto: {produto.Nome} -- {produto.Preco}");
            }
            
        }
    }
}