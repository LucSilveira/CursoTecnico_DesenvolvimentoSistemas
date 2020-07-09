namespace Interfaces
{
    public interface ICarrinho
    {
        void MostrarProdutos();

        void AdicionarProduto(Produto _produto);

        void RemoverProduto(Produto _produto);

        void Alterar(int _codigo, Produto _produtoAlterado);

        void MostrarTotal();
    }
}