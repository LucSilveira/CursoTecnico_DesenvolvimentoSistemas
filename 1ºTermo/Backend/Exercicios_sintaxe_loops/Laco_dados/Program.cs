using System;

namespace Laco_dados
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao nosso sistema de cadastro!!\n\n");

            Console.WriteLine("Por favor, informe seu nome:");
            string nomeInformado = Console.ReadLine();

            while(nomeInformado == null || nomeInformado.Length == 0){

                Console.WriteLine("\nO nome não pode ser vazio!!!");
                Console.WriteLine("Insira seu nome:");
                nomeInformado = Console.ReadLine();
            }

            Console.WriteLine("\nPor favor, informe sua idade (deve ser maior que 0 e menor que 150):");
            int idadeInformada = Int32.Parse(Console.ReadLine());

            while(idadeInformada < 0 || idadeInformada > 150){

                Console.WriteLine("\nidade inválida, por favor verificar as exigências!");
                Console.WriteLine("Insira sua idade:");
                idadeInformada = Int32.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nPor favor, informe seu salário:");
            double salarioInformado = double.Parse(Console.ReadLine());

            while(salarioInformado <= 0){

                Console.WriteLine("\nSalário inválido!");
                Console.WriteLine("Insira seu salário:");
                salarioInformado = double.Parse(Console.ReadLine());;
            }

            Console.WriteLine("Por favor, informe seu estado civil");
            Console.WriteLine("\n\nInforme de acordo com as nossas opções:");
            Console.WriteLine(" Opção (s)    -   Solteiro(a)");
            Console.WriteLine(" Opção (c)    -   Casado(a)");
            Console.WriteLine(" Opção (v)    -   Viuvo(a)");
            Console.WriteLine(" Opção (d)    -   Divorciado(a)");
            string estadoCivil = Console.ReadLine();

            while(estadoCivil != "s" && estadoCivil != "c" && estadoCivil != "v" && estadoCivil != "d"){

                Console.WriteLine("\nEstado civil inválido, informar de acordo com as opções!");
                Console.WriteLine("Informe o estado civil novamente:");
                Console.WriteLine(" Opção (s)    -   Solteiro(a)");
                Console.WriteLine(" Opção (c)    -   Casado(a)");
                Console.WriteLine(" Opção (v)    -   Viuvo(a)");
                Console.WriteLine(" Opção (d)    -   Divorciado(a)");
                estadoCivil = Console.ReadLine();
            }


            Console.WriteLine("\n\nDados coletados:");
            Console.WriteLine($"Nome : {nomeInformado}, Idade : {idadeInformada}");
            Console.WriteLine($"Salário : {salarioInformado}, Estado civil : {estadoCivil}");
        }
    }
}
