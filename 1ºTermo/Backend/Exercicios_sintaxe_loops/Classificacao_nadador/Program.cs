using System;

namespace Classificacao_nadador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seja bem-vindo ao nosso torneio:\n");
            Console.WriteLine("Para saber a sua categoria, por favor informe sua idade:");
            int idadeAtleta = int.Parse(Console.ReadLine());

            if(idadeAtleta < 7){
               Console.WriteLine("A sua classificação é: Infantil A");
            }else if(idadeAtleta < 10){
                Console.WriteLine("A sua classificação é: Infantil B");
            }else if(idadeAtleta < 13){
                Console.WriteLine("A sua classificação é: Juvenil A");
            }else if(idadeAtleta < 17){
                Console.WriteLine("A sua classificação é: Juvenil B");
            }else{
                Console.WriteLine("A sua classificação é: Sênior");
            }
        }
    }
}
