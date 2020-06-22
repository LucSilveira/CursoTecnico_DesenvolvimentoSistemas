using System;

namespace Construtores
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto sapato = new Produto();

            Produto chinelo = new Produto(789);
            System.Console.WriteLine(chinelo.Codigo);

            Produto sandalia = new Produto(568, "Havaianas", "Sandalinhas de praia", 58);
            System.Console.WriteLine(sandalia.Codigo);
            System.Console.WriteLine(sandalia.Nome);
            System.Console.WriteLine(sandalia.Descricao);
            System.Console.WriteLine(sandalia.Estoque);
        }
    }
}
