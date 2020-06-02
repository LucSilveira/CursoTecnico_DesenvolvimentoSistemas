namespace Heranca_pessoa_exc
{
    public class Cpf : Pessoa
    {
        public string cpf;

        public string rg;

        public bool ValidarCpf(){

            if(cpf != ""){

                return true;
            }else{

                return false;
            }

        }
    }
}