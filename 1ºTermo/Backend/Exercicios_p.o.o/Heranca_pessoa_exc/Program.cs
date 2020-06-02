using System;

namespace Heranca_pessoa_exc
{
    class Program
    {
        static void Main(string[] args)
        {
            Cpf cpf = new Cpf();
            cpf.nome = "Lucao";

            System.Console.WriteLine(cpf.Saudar());
        }
    }
}
