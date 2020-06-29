using System.Collections.Generic;

namespace Interfaces
{
    public class Carrinho : ICarrinho
    {
        List<Produto> listCarrinho = new List<Produto>();

        public void Alterar(int _codigo, Produto _produtoAlterado)
        {
            listCarrinho.Find(x => x.Codigo == _codigo).Nome = _produtoAlterado.Nome;
            listCarrinho.Find(y => y.Codigo == _codigo).Preco = _produtoAlterado.Preco;
        }

        public void Excluir(Produto _produto)
        {
            listCarrinho.Remove(_produto);
        }

        public void Incluir(Produto _produto)
        {
            listCarrinho.Add(_produto);
        }

        public void Ler()
        {
            foreach(Produto prd in listCarrinho)
            {
                System.Console.WriteLine($"R$: {prd.Preco} - Nome: {prd.Nome}");
            }
        }
    }
}