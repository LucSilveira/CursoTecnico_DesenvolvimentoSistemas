namespace Exercicio_heranca
{
    public class Cpf : Pessoa
    {
        public string cpf { get; set; }

        /// <summary>
        /// Método para verificar se a pessoa informou um cpf e se é válido
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns>Cpf válido ou não</returns>
        public bool ValidarCpf(){


            if(cpf.Length != 11){

                return false;
            }

            return true;
        }
    }
}