using System;

namespace PrimeiroPoo
{
    class Program
    {
        static void Main(string[] args)
        {

            Personagem capitao = new Personagem();

            capitao.nome = "Steve Rogers";
            capitao.vida = 100f;
            capitao.forca = 45.3f;
            capitao.potencia = 25.0f;

            System.Console.WriteLine(capitao.Atacar());
            System.Console.WriteLine(capitao.CalcularDanoInserido());
            System.Console.WriteLine(capitao.CalcularDanoRecebido(22.3f));
        }
    }
}
