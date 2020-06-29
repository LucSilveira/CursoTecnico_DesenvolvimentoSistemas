namespace EstruturaDados_uber
{
    public class Cartao
    {
        public string Numero { get; set; }
        public string Titular { get; set; }
        public string Bandeira { get; set; }
        public string Cvv { get; set; }


        /// <summary>
        /// Método para cadastrar os dados do cartão do usuário
        /// </summary>
        /// <returns>Cartão cadastrado com sucesso</returns>
        public string Cadastrar()
        {
            System.Console.WriteLine("Digite o nome do titular do cartão:");
            Titular = System.Console.ReadLine();

            System.Console.WriteLine("Digite o número do cartão:");
            Numero = System.Console.ReadLine();

            System.Console.WriteLine("Digite a bandeira do cartão:");
            Bandeira = System.Console.ReadLine();

            System.Console.WriteLine("Digite o código de segurança do cartão:");
            Cvv = System.Console.ReadLine();

            return "Cartão cadastrado com sucesso";
        }


        /// <summary>
        /// Método para excluir os dados do cartão
        /// </summary>
        public void Excluir()
        {
            Titular = "";
            Numero = "";
            Bandeira = "";
            Cvv = "";
        }
    }
}