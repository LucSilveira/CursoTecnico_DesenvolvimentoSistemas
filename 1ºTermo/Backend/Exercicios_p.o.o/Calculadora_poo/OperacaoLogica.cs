using System;

namespace Calculadora_poo
{
    public class OperacaoLogica : Calculadora
    {
        //variavel para receber todos os números informados;
        public string[] numerosInformados { get; set; }

        //Variavel para armazenar os números informados porém já convertido em float;
        public float[] valoresCapturados { get; set; }

        // Variavel para armazenar o valor da media dos resultados;
        private float resultadoMedia { get; set; }

        // Variavel para fazer as contagens dos loops da função e achar quantos números o usuário informou;
        protected int contador { get; set; }


        /// <summary>
        /// Método para capturar e converter os números informados no console, e com isso fazer a soma
        /// desses valores e dividir pela quantidade de números informados
        /// </summary>
        /// <returns>Resultado da conta de média</returns>
        public float CalculoMedia(){

            valoresCapturados = new float[numerosInformados.Length];
            contador = 0;

            for (int i = 0; i < numerosInformados.Length ; i++)
            {
                valoresCapturados[i] += float.Parse(numerosInformados[i].ToString());
                resultadoMedia += valoresCapturados[i];

                contador++;
            }

            resultadoMedia /= contador;

            return resultadoMedia;
        }

    }
}