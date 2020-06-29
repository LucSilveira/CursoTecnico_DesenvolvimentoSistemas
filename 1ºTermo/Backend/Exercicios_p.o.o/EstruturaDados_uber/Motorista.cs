namespace EstruturaDados_uber
{
    public class Motorista : Usuario
    {
        public string Carro { get; set; }
        public string Placa { get; set; }


        /// <summary>
        /// Método para mostrar um texto para o passageiro que o usuário
        /// seja informado que sua viagem foi aceita
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Um texto para exibir a aceitação da viagem</returns>
        public string AceitarPassageiro(string nome)
        {
            return $"Passageiro: {nome} aceito pelo motorista {this.Nome}";
        }


        /// <summary>
        /// Método para receber o pagamento da corrida
        /// </summary>
        /// <param name="statusCorrida"></param>
        /// <returns>Pagamento feito ou não</returns>
        public bool ReceberPagamento(string statusCorrida)
        {
            if(statusCorrida == "Finalizada")
            {
                return true;
            }

            return false;
        }
    }
}