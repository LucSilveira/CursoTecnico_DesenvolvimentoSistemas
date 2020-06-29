namespace EstruturaDados_uber
{
    public class Passageiro : Usuario
    {
        /// <summary>
        /// Método para solicitar um motorista em uma viagem
        /// </summary>
        /// <returns></returns>
        public string SolicitarMotorista()
        {
            return "Procurando motorista...";
        }


        /// <summary>
        /// Método para pagar a corrida finalizada
        /// </summary>
        /// <param name="statusCorrida"></param>
        /// <returns></returns>
        public bool Pagar(string statusCorrida)
        {
            if(statusCorrida == "Finalizada")
            {
                return true;
            }

            return false;
        }
    }
}