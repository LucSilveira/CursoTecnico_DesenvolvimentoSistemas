using System;

namespace Exercicio_heranca
{
    class Program
    {
        static void Main(string[] args)
        {
            Cpf cpfExemplo = new Cpf();

            cpfExemplo.cpf = "12345678901";
            cpfExemplo.nome = "Lucao";

            Console.WriteLine(cpfExemplo.ValidarCpf());
            Console.WriteLine(cpfExemplo.Saudacao());

            Cnpj cnpjExemplo = new Cnpj();

            cnpjExemplo.nome = "Paulera";
            cnpjExemplo.cnpj = "1234567890123";

            Console.WriteLine(cnpjExemplo.ValidarCnpj());
            Console.WriteLine(cnpjExemplo.Saudacao());

        }
    }
}
