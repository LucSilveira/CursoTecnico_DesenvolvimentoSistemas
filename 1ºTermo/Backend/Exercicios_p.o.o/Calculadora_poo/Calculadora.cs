namespace Calculadora_poo
{
    public class Calculadora
    {
        
        public string[] dadosInformados { get; set; }

        public float[] numerosConvertidos { get; set; }

        private float resultadoOperacao { get; set; }

        protected int contadorLaco { get; set; }



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


        public float CalculoSubtracao(){

            numerosConvertidos = new float[dadosInformados.Length];
            contadorLaco = 1;

            do{

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


        public float CalculoDivisao(){

            numerosConvertidos = new float[dadosInformados.Length];
            contadorLaco = 1;

            do{

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