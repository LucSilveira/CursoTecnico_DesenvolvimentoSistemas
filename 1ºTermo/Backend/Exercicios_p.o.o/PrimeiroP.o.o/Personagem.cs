namespace PrimeiroPoo
{
    public class Personagem
    {
        
        public string nome;

        public float vida;

        public float forca;

        public float potencia;


        public string Atacar(){
            return "O personagem acabou de realizar um ataque";
        }

        public float CalcularDanoRecebido(float dano){

            return vida - dano;
        }

        public float CalcularDanoInserido(){

            return forca * potencia;
        }
    }
}