using System;

namespace Restaurante_exercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente joao = new Cliente("Joaozinho");
            joao.Endereco = "Av abc, 123";
            // System.Console.WriteLine(joao.MostrarDados());

            Restaurante rest = new Restaurante("Mcdonalds");
            rest.Endereco = "Av 123, abc";
            // System.Console.WriteLine(rest.MostrarDados());

            Pedido pedido = new Pedido();
            pedido.Cliente = joao;
            pedido.Restaurante = rest;
            System.Console.WriteLine(pedido.EntregarPedido());            
        }
    }
}
