using System;

namespace Calculo_imposto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao calculo de imposto!\n\n");

            // Entrada
            Console.WriteLine("Por favor, quantas horas por dia você trabalha?");
            double horasTrabalhadas = double.Parse(Console.ReadLine());

            Console.WriteLine("\nPor favor, quanto você recebe por hora trabalhada?");
            double valorHora = double.Parse(Console.ReadLine());

            double salarioBruto = 0;
            double salarioLiquido = 0;
            double valorInss = 0;
            double valorSindicato = 0;
            double valorImposto = 0;


            // Processamento
            salarioBruto = horasTrabalhadas * valorHora;

            valorInss = (salarioBruto * 8) / 100;
            valorSindicato = (salarioBruto * 5) / 100;
            valorImposto = (salarioBruto * 11) / 100; 

            salarioLiquido = salarioBruto - valorInss - valorSindicato - valorImposto;

            // saida
            Console.WriteLine($"\n\nSegue a nota fiscal:\n");
            System.Console.WriteLine($"Seu salário bruto : " + salarioBruto + "\nSeu salário liquido: " + salarioLiquido + "\n");
            System.Console.WriteLine($"Descontos atrelados : \n" + 
            "Inss : " + valorInss + "\tImposto de Renda : " + valorImposto + "\tSindicato : " + valorSindicato);
        }
    }
}
