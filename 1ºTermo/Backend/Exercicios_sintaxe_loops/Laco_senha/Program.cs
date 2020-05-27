using System;

namespace Laco_senha
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao nosso sistema:\n\n");

            // entrada
            Console.WriteLine("Por favor, informe seu nome");
            string nomeInformado = Console.ReadLine();

            Console.WriteLine("\nPor favor, informe uma senha (diferente de seu nome!)");
            string senhaInformada = Console.ReadLine();


            // processamento
            while(nomeInformado == senhaInformada){

                Console.WriteLine("\n\nSenha inválida, por favor verificar a exigência");
                Console.WriteLine("\nInforme a senha novamente:");
                senhaInformada = Console.ReadLine();
            }

            // saída
            Console.WriteLine($"\n\nDados coletados, nome : {nomeInformado} e senha : {senhaInformada}");
            Console.WriteLine("\nMuito obrigado pela preferencia, volte sempre!");
        }
    }
}
