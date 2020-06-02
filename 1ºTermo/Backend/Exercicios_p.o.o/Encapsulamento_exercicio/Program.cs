using System;

namespace Encapsulamento_exercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            MasterCard master = new MasterCard();

            master.numero = "0123456789012";
            master.bandeira = "qualquer kkk";
            master.parcelas = 12;
            
            Console.WriteLine(master.AprovarCompra());
            Console.WriteLine(master.ValidarToken());
            Console.WriteLine(master.ValidarCompra());
            master.ComprarDescontoMasterCard(200f);
        }
    }
}
