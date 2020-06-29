namespace EstruturaDados_uber
{
    public class Corrida
    {
        public string LocalInicio { get; set; }
        public string LocalChegada { get; set; }
        public string StatusCorrida { get; set; }
        public string Motorista { get; set; }
        public string Passageiro { get; set; }


        /// <summary>
        /// Método para exibir o cancelamento de uma viagem
        /// </summary>
        /// <returns>Corrida cancelada</returns>
        public string Cancelar()
        {
            StatusCorrida = "Cancelar";
            return "Corrida cancelar";
        }
    }
}