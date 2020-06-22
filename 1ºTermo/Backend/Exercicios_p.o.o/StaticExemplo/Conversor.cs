namespace StaticExemplo
{
    public class Conversor
    {
        private static float CotacaoDolar = 5.29f;

        private static float CotacaoEuro = 5.90f;



        public static float ConversorDolarEmReal(float valor){

            return valor * CotacaoDolar;
        }

        public static  float ConversorRealEmDolar(float valor){

            return valor / CotacaoDolar;
        }


        public static float ConversorEuroEmReal(float valor){

            return valor * CotacaoEuro;
        }

        public static float ConversorRealEmEuro(float valor){

            return valor / CotacaoEuro;
        }
    }
}