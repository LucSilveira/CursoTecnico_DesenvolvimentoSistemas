using System;

namespace Laco_notasEscola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculo das notas escolares!!\n\n");

            int notasInseridas = 0;
            double somaNotas = 0;
            string nomeAluno;
            double notaAluno = 0;

            do{

                Console.WriteLine("Informe o nome do aluno: ");
                nomeAluno = Console.ReadLine();

                Console.WriteLine("\nInforme a nota do aluno:");
                notaAluno = double.Parse(Console.ReadLine());

                somaNotas += notaAluno;
                notasInseridas++;

                Console.WriteLine($"\nNome do aluno: {nomeAluno}, nota do aluno: {notaAluno}\n");

            }while(notasInseridas < 10);

            double mediaNotas = somaNotas / notasInseridas;
            Console.WriteLine($"\n\nMédia das notas inseridas: {mediaNotas}");
        }
    }
}
