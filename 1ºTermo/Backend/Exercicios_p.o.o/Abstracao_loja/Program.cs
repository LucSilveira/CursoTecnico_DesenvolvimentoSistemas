using System;

namespace Abstracao_loja
{
    class Program
    {
        static void Main(string[] args)
        {
            CartaoCredito visa = new CartaoCredito();
            visa.data = DateTime.Parse(Console.ReadLine());
            visa.limite = 1200f;
            visa.AumentarLimite(1200f, 1300f);
            visa.Pagar();

        }
    }
}
