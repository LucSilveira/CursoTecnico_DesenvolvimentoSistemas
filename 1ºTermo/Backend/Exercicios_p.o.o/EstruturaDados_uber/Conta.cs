namespace EstruturaDados_uber
{
    public class Conta
    {
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }


        /// <summary>
        /// Método para cadastrar uma conta corrente
        /// </summary>
        /// <returns></returns>
        public string Cadastrar()
        {
            System.Console.WriteLine("Digite a agência:");
            Agencia = System.Console.ReadLine();

            System.Console.WriteLine("Digite a conta corrente:");
            ContaCorrente = System.Console.ReadLine();

            return "Dados da conta cadastrados";
        }


        /// <summary>
        /// Método para excluir os dados da conta
        /// </summary>
        public void Excluir()
        {
            Agencia = "";
            ContaCorrente = "";
        }
    }
}