namespace Calculadora_poo
{
    public class Calculadora
    {
        //variavel para receber todos os números informados;
        public string[] dadosInformados { get; set; }

        //Variavel para armazenar os números informados porém já convertido em float;
        public float[] numerosConvertidos { get; set; }

        // Variavel para armazenar o valor da operação realizada;
        private float resultadoOperacao { get; set; }

        // Variavel para fazer as contagens dos loops da função e achar quantos números o usuário informou;
        protected int contadorLaco { get; set; }


        /// <summary>
        /// Método para fazer a soma de todos os valores que o usuário informou
        /// </summary>
        /// <returns>Resultado da adição entre os valores</returns>
        public float CalculoAdicao(){
            
            numerosConvertidos = new float[dadosInformados.Length];
            resultadoOperacao = 0;

            for (int i = 0; i < dadosInformados.Length; i++)
            {
                numerosConvertidos[i] = float.Parse(dadosInformados[i].ToString());
                resultadoOperacao += numerosConvertidos[i];
            }

            return resultadoOperacao;
        }


        /// <summary>
        /// Método para fazer a subtração de todos os valores que o user informou
        /// </summary>
        /// <returns>Resultado da subtração dos valores</returns>
        public float CalculoSubtracao(){

            numerosConvertidos = new float[dadosInformados.Length];
            contadorLaco = 1;

            do{
                // função para fazer que o indice[0] dos dados informados sejam o mesmo que o indice[0] da converção
                // dessa forma é impedido que o valor sempre fique menor que 0;
                numerosConvertidos[0] = float.Parse(dadosInformados[0].ToString());
                resultadoOperacao = numerosConvertidos[0];


                for (int i = 1; i < dadosInformados.Length ; i++)
                {
                    numerosConvertidos[i] = float.Parse(dadosInformados[i].ToString());
                    resultadoOperacao -= numerosConvertidos[i];
                    contadorLaco++;
                }

            }while(contadorLaco == dadosInformados.Length);

            return resultadoOperacao;
        }


        /// <summary>
        /// Método para que seja possivel multiplicar todos os valores informados pelo user
        /// </summary>
        /// <returns>Resultado da multiplicação dos valores</returns>
        public float CalculoMultiplicacao(){

            numerosConvertidos = new float[dadosInformados.Length];
            resultadoOperacao = 1;

            for (int i = 0; i < dadosInformados.Length; i++)
            {
                numerosConvertidos[i] = float.Parse(dadosInformados[i].ToString());
                resultadoOperacao *= numerosConvertidos[i];
            }

            return resultadoOperacao;
        }


        /// <summary>
        /// Método para realizar a divisão de todos os valores informados
        /// </summary>
        /// <returns>Resultado da divisão</returns>
        public float CalculoDivisao(){

            numerosConvertidos = new float[dadosInformados.Length];
            contadorLaco = 1;

            do{
                // função para informar que o indice[0] dos dados informados seja o mesmo que indice[0] da conversao
                // dessa forma evita que os dados sejam sempre 0, pois o laco sempre retornava 0 / valores-informados
                numerosConvertidos[0] = float.Parse(dadosInformados[0].ToString());
                resultadoOperacao = numerosConvertidos[0];

                for (int i = 1; i < dadosInformados.Length ; i++)
                {
                    numerosConvertidos[i] = float.Parse(dadosInformados[i].ToString());
                    resultadoOperacao /= numerosConvertidos[i];
                    contadorLaco++;
                }

            }while(contadorLaco == dadosInformados.Length);

            return resultadoOperacao;
        }
    }
}