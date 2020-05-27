using System;

namespace Laco_espacosNumeros
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculando espaços entre valores!!\n\n");

            // entradas

            Console.WriteLine("Informe o primeiro número ao seu desejo:");
            int numero1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nInforme o segundo número ao seu desejo:");
            int numero2 = Int32.Parse(Console.ReadLine());

            int espacos = 0;
            int somaEspacos = 0;

            // Processamento
            
            if(numero2 > numero1){

                espacos = numero2 - numero1;

                while(espacos > 0){

                    somaEspacos += espacos;
                    espacos--;
                }
            }

            espacos = numero1 - numero2;

            while(espacos > 0){

                somaEspacos += espacos;
                espacos--;
            }

            // saida

            Console.WriteLine($"O resultado da soma dos espaços: {somaEspacos}");


            //// if(numero2 > numero1){

            ////     espacoSoma = numero2 - 1;
            ////     verificadorEspacos = numero2;

            ////     while(verificadorEspacos > numero1){

            ////         espacoSoma += numero1 - 1;
            ////         verificadorEspacos--;
            ////     }

            ////     Console.WriteLine($"Soma dos espaços é: {espacoSoma}");

            //// }
            


            //// espacoSoma = numero1 - 1;
            //// verificadorEspacos = numero1;

            //// while(verificadorEspacos > numero2){
            ////     espacoSoma += numero2 - 1;
            ////     verificadorEspacos--;
            //// }

            //// Console.WriteLine($"Soma dos espaços é: {espacoSoma}");
        }
    }
}
