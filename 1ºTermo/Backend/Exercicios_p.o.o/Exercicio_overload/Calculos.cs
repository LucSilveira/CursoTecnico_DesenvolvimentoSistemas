namespace Exercicio_overload
{
    public class Calculos
    {
        public string Calcular(){

            return "A vida do player ainda não está sendo calculada";
        }

        public string Calcular(int vidaPlayer){

            return "A vida do player é " + vidaPlayer;
        }

        public string Calcular(int vidaPlayer, int escudo){

            return "A vida do player com escudo é " + (vidaPlayer + escudo);
        }

        public string Calcular(int vidaPlayer, int escudo, int armadura){

            return "A vida do player com armadura é " + (vidaPlayer + escudo + armadura);
        }
    }
}