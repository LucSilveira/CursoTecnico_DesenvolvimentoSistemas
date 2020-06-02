namespace Heranca_pessoa_exc
{
    public class Cnpj
    {
        public string cnpj;

        public bool ValidarCnp(){

            if(cnpj != ""){

                return true;
            }

            return false;
        }
    }
}