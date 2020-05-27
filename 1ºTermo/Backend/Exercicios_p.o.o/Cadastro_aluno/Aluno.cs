namespace Cadastro_aluno
{
    public class Aluno
    {
        public string nome;

        public int idade;

        public string rg;

        public bool bolsista;

        public float mediaFinal;

        public float mensalidade;

        public float porcentagemBolsa;


        
        public float VerMediaFinal(){

            return mediaFinal;
        }


        public float VerMensalidade(){

            float valorCalculadoMensalidade = mensalidade;

            if(bolsista){

                valorCalculadoMensalidade -=((mensalidade * porcentagemBolsa) / 100);

            }

            return valorCalculadoMensalidade;
        }


        public bool TraducaoBolsista(string console){

            if(console == "sim"){

                bolsista = true;
            }else{

                bolsista = false;
            }

            return bolsista;
        }
    }
}