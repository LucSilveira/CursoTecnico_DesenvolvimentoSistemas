using System;

namespace Ajuste_salario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de reajuste de sálarios: \n\n");

            Console.WriteLine("Por favor insira os dados de acordo com a exigência:");

            Console.WriteLine("Informe o seu nome:");
            string nomeFuncionario = Console.ReadLine();

            Console.WriteLine("\nInforme o seu sálario");
            double salarioFuncionario  = double.Parse(Console.ReadLine());


            Console.WriteLine("\n\nExibindo resultado ...");
            Console.WriteLine("Funcionario: " + nomeFuncionario);
            Console.WriteLine("Salário: R$" + salarioFuncionario);
            if(salarioFuncionario < 500){

                double salarioAjustado = 0;
                salarioAjustado = (salarioFuncionario * 30) / 100;

                salarioFuncionario += salarioAjustado;

                Console.WriteLine("\nStatus de reajuste:  aprovado!");
                Console.WriteLine("Reajuste aplicado:   R$" + salarioAjustado);
                Console.WriteLine("Salário com reajuste:    R$" + salarioFuncionario);
            }else{

                Console.WriteLine("\nStatus de reajuste:  reprovado!");
                Console.WriteLine("Salário sem reajuste.");
            }
        }
    }
}
