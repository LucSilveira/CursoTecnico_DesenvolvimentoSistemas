using System.Collections.Generic;

namespace Interfaces
{
    public class Carrinho : ICarrinho
    {
        List<Produto> listCarrinho = new List<Produto>();

        public float ValorTotal { get; set; }



        public void Alterar(int _codigo, Produto _produtoAlterado)
        {
            listCarrinho.Find(x => x.Codigo == _codigo).Nome = _produtoAlterado.Nome;
            listCarrinho.Find(y => y.Codigo == _codigo).Preco = _produtoAlterado.Preco;
        }

        public void RemoverProduto(Produto _produto)
        {
            listCarrinho.Remove(_produto);
        }

        public void AdicionarProduto(Produto _produto)
        {
            listCarrinho.Add(_produto);
        }

        public void MostrarProdutos()
        {
            if(listCarrinho != null)
            {
                foreach (Produto prd in listCarrinho)
                {
                    System.Console.WriteLine($"R$ {prd.Preco.ToString("n2")} - {prd.Nome}");
                }
            }
        }

        public void MostrarTotal()
        {
            if(listCarrinho != null)
            {
                foreach (Produto prd in listCarrinho)
                {
                    ValorTotal += prd.Preco;
                }

                System.Console.WriteLine($"Valor total do carrinho R$ {ValorTotal.ToString("n2")}");
            }
            else
            {
                System.Console.WriteLine($"Seu carrinho está vazio!");
            }
        }
    }
}