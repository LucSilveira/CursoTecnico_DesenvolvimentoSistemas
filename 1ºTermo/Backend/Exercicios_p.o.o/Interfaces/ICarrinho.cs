namespace Interfaces
{
    public interface ICarrinho
    {
        void Ler ();

        void Incluir (Produto _produto);

        void Excluir (Produto _produto);

        void Alterar(int _codigo, Produto _produtoAlterado);
    }
}