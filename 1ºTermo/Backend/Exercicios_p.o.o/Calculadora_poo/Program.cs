using System;

namespace Calculadora_poo
{
    class Program
    {
        static void Main(string[] args)
        {
            OperacaoLogica operacao = new OperacaoLogica();
            
            Console.WriteLine("Informe qual operação você deseja realizar");
            Console.WriteLine("opcão( + )\t-\tAdição");
            Console.WriteLine("opção( - )\t-\tSubtração");
            Console.WriteLine("opção( * )\t-\tMultiplicação");
            Console.WriteLine("opção( / )\t-\tDivisão");
            Console.WriteLine("opção( M )\t-\tMédia");
            string operacaoDesejada = Console.ReadLine();

            switch (operacaoDesejada)
            {
                
                case "+":
                    Console.WriteLine("Informe os números que você deseja fazer a conta:");
                    Console.WriteLine("(Os números podem ser separados por espaço ou vírgula)");
                    operacao.dadosInformados = Console.ReadLine().Split(' ', ',');

                    Console.WriteLine(operacao.CalculoAdicao());
                    break;

                case "-":
                    Console.WriteLine("Informe os números que você deseja fazer a conta:");
                    Console.WriteLine("(Os números podem ser separados por espaço ou vírgula)");
                    operacao.dadosInformados = Console.ReadLine().Split(' ', ',');

                    Console.WriteLine(operacao.CalculoSubtracao());
                    break;

                case "*":
                    Console.WriteLine("Informe os números que você deseja fazer a conta:");
                    Console.WriteLine("(Os números podem ser separados por espaço ou vírgula)");
                    operacao.dadosInformados = Console.ReadLine().Split(' ', ',');

                    Console.WriteLine(operacao.CalculoMultiplicacao());
                    break;

                case "/":
                    Console.WriteLine("Informe os números que você deseja fazer a conta:");
                    Console.WriteLine("(Os números podem ser separados por espaço ou vírgula)");
                    operacao.dadosInformados = Console.ReadLine().Split(' ', ',');

                    Console.WriteLine(operacao.CalculoDivisao());
                    break;

                case "M":
                    Console.WriteLine("Informe os números que você deseja fazer a conta:");
                    Console.WriteLine("(Os números podem ser separados por espaço ou vírgula)");

                    Console.WriteLine(operacao.CalculoMedia(Console.ReadLine()));
                    break;

                default:
                    Console.WriteLine("Operação não encontrada!");
                    break;
            }
        }
    }
}
