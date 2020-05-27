using System;

namespace Cadastro_aluno
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno paulera = new Aluno();

            paulera.nome = "Paulera brabo";
            paulera.idade = 18;
            paulera.rg = "12.345.678-9";
                Console.WriteLine("O Aluno em questão é bolsista?");
                paulera.bolsista = paulera.TraducaoBolsista(Console.ReadLine());
            paulera.mensalidade = 1500f;
            paulera.mediaFinal = 9.9f;

            Console.WriteLine(paulera.VerMensalidade());
            Console.WriteLine(paulera.VerMediaFinal());



            Aluno tsukinha = new Aluno();
            tsukinha.nome = "Tsukaboy";
            tsukinha.idade = 20;
            tsukinha.rg = "98.765.432-1";
                Console.WriteLine("O aluno em questão é bolsista?");
                tsukinha.bolsista = tsukinha.TraducaoBolsista(Console.ReadLine());
            tsukinha.mensalidade = 1500f;
            tsukinha.porcentagemBolsa = 55f;
            tsukinha.mediaFinal = 9.8f;

            Console.WriteLine(tsukinha.VerMensalidade());
            Console.WriteLine(tsukinha.VerMediaFinal());

        }
    }
}
