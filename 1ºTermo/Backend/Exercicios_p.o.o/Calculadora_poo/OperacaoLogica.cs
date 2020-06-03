using System;

namespace Calculadora_poo
{
    public class OperacaoLogica : Calculadora
    {

        public float[] test { get; set; }

        public string[] numeros { get; set; }

        private float resultadoMedia { get; set; }

        protected int contador { get; set; }



        public float CalculoMedia(string textoInformado){ //

            contador = 0;
            numeros = textoInformado.Split(' ', ',');

            for (int i = 0; i < numeros.Length ; i++)
            {
                System.Console.WriteLine("lçsdfnjvklskndjvls");
            }

            return 43f;
        }

    }
}