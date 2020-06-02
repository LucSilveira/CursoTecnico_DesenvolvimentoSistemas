namespace Exercicio_heranca
{
    public class Cnpj : Pessoa
    {
        public string cnpj { get; set; }


        /// <summary>
        /// Método para validação do Cnpj
        /// </summary>
        /// <returns>Cnpj válido ou não</returns>
        public bool ValidarCnpj(){

            if(cnpj.Length != 13){

                return false;
            }

            return true;
        }
    }
}