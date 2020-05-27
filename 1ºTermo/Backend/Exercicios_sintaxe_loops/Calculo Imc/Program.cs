using System;

namespace Calculo_Imc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculando o IMC:\n");

            System.Console.WriteLine("Nos fale o seu peso por favor!");
            double pesoUsuario = double.Parse(Console.ReadLine());
            System.Console.WriteLine($"Peso informado: " + pesoUsuario + "Kg\n\n");

            System.Console.WriteLine("Nos fale a sua altura por favor!");
            double alturaUsuario = double.Parse(Console.ReadLine());
            System.Console.WriteLine($"Altura informada: " + alturaUsuario + "m\n\n");

            System.Console.WriteLine("Resultado do seu IMC:");
            double imcUsuario = pesoUsuario / (alturaUsuario * alturaUsuario);
            System.Console.WriteLine(imcUsuario);
        }
    }
}
