namespace Encapsulamento_exercicio
{
    public class Cartao
    {
        public string numero { get; set; }

        public string bandeira { get; set; }

        public string token = "ir1n3uv0c3n40s4b3n3m4u";

        protected int cvc { get; set; }


        public string AprovarCompra(){

            return "Compra aprovada com sucesso";
        }

        public bool ValidarToken(){

            if(token != null && token != ""){

                return true;
            }

            return false;
        }

        public bool ValidarCompra(){

            return true;
        }
    }
}