using System;

namespace Calculadora_poo
{
    class Program
    {
        static void Main(string[] args)
        {
            OperacaoLogica operacao = new OperacaoLogica();
            
            // Menu para verificar a operação desejada
            System.Console.WriteLine("\n\nBem vindo ao sistema Calculo-Legal\n");
            Console.WriteLine("Informe qual operação você deseja realizar:");
            Console.WriteLine("opcão( + )\t-\tAdição");
            Console.WriteLine("opção( - )\t-\tSubtração");
            Console.WriteLine("opção( * )\t-\tMultiplicação");
            Console.WriteLine("opção( / )\t-\tDivisão");
            Console.WriteLine("opção( M )\t-\tMédia\n");
            string operacaoDesejada = Console.ReadLine();

            // Menu de opções e ações que seram realizadas
            switch (operacaoDesejada)
            {
                
                case "+":
                    Console.WriteLine("\n\nInforme os números que você deseja fazer a conta:");
                    Console.WriteLine("(Os números podem ser separados por espaço ou vírgula)");

                    // Recebendo os valores informados e transforma-los em um array;
                    operacao.dadosInformados = Console.ReadLine().Split(' ', ',');

                    Console.WriteLine("\n\nO resultado da adição é:");

                    //Chamando a função de subtração
                    Console.WriteLine(operacao.CalculoAdicao());
                    break;

                case "-":
                    Console.WriteLine("\n\nInforme os números que você deseja fazer a conta:");
                    Console.WriteLine("(Os números podem ser separados por espaço ou vírgula)");

                    // Recebendo os valores informados e transforma-los em um array;
                    operacao.dadosInformados = Console.ReadLine().Split(' ', ',');

                    Console.WriteLine("\n\nO resultado da subtração é:");

                    //Chamando a função de subtração
                    Console.WriteLine(operacao.CalculoSubtracao());
                    break;

                case "*":
                    Console.WriteLine("\n\nInforme os números que você deseja fazer a conta:");
                    Console.WriteLine("(Os números podem ser separados por espaço ou vírgula)");

                    // Recebendo os valores informados e transforma-los em um array;
                    operacao.dadosInformados = Console.ReadLine().Split(' ', ',');

                    Console.WriteLine("\n\nO resultado da multiplicação é:");

                    //Chamando a função de subtração
                    Console.WriteLine(operacao.CalculoMultiplicacao());
                    break;

                case "/":
                    Console.WriteLine("\n\nInforme os números que você deseja fazer a conta:");
                    Console.WriteLine("(Os números podem ser separados por espaço ou vírgula)");

                    // Recebendo os valores informados e transforma-los em um array;
                    operacao.dadosInformados = Console.ReadLine().Split(' ', ',');

                    Console.WriteLine("\n\nO resultado da Divisão é:");

                    //Chamando a função de subtração
                    Console.WriteLine(operacao.CalculoDivisao());
                    break;

                case "M":
                case "m":
                    Console.WriteLine("\n\nInforme os números que você deseja fazer a conta:");
                    Console.WriteLine("(Os números podem ser separados por espaço ou vírgula)");

                    // Recebendo os valores informados e transforma-los em um array;
                    operacao.numerosInformados = Console.ReadLine().Split(' ', ',');

                    Console.WriteLine("\n\nO resultado da média é:");

                    //Chamando a função de subtração
                    Console.WriteLine(operacao.CalculoMedia());
                    break;

                default:
                    Console.WriteLine("\n\nDesculpe ....operação não encontrada!");
                    break;
            }
        }
    }
}
