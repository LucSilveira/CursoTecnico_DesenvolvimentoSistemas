using System;

namespace Media_Escolar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calcular a média!\n\n");

            System.Console.WriteLine("Informe a sua nota no primeiro semestre:");
            double nota1 = double.Parse(Console.ReadLine());

            System.Console.WriteLine("\nInforme a sua nota no segundo semestre:");
            double nota2 = double.Parse(Console.ReadLine());

            System.Console.WriteLine("\nO resultado da sua média é:");
            double media = (nota1 + nota2) / 2;
            System.Console.WriteLine(media);

            if(media >= 50){
                System.Console.WriteLine("Você está aprovado! Meus parabéns");
            }else{
                System.Console.WriteLine("Você está reprovado! Mais sorte ná próxima");
            }
        }
    }
}
