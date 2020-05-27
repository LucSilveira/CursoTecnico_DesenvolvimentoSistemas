using System;

namespace Periodo_estudo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao sistema da sua a universidade,");
            Console.WriteLine("O campus da universialegra!\n\n");

            Console.WriteLine("Por favor, selecione o período das suas aulas:");
            System.Console.WriteLine(" opção (1)\t-\t M - matutino");
            System.Console.WriteLine(" opção (2)\t-\t V - vespentino");
            System.Console.WriteLine(" opção (3)\t-\t N - noturno");
            string periodoResposta = Console.ReadLine();

            switch(periodoResposta){
                case "M":
                    System.Console.WriteLine("\nBom dia!!\ttenha bons estudos");
                    break;

                case "V":
                    System.Console.WriteLine("\nBoa Tarde!!\ttenha bons estudos");
                    break;

                case "N":
                    System.Console.WriteLine("\nBoa Noite!!\ttenha bons estudos");
                    break;

                default:
                    System.Console.WriteLine("\nDesculpe, período de estudos inválidos!!");
                    break;
            }
        }
    }
}
