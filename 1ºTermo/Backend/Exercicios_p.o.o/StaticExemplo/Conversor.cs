namespace StaticExemplo
{
    public class Conversor
    {
        private static float CotacaoDolar = 5.29f;

        public static float ConversorDolar(float valor){

            return valor * CotacaoDolar;
        }

        public static  float ConversorReal(float valor){

            return valor / CotacaoDolar;
        }
    }
}