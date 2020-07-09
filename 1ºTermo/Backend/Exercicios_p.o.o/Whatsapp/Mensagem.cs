namespace Whatsapp
{
    public class Mensagem
    {
        public string TextoMensagem { get; set; }

        public string Destinatario { get; set; }


        public string EnviarMenagem(Contato _contato, string _mensagem)
        {
            return $"Enviando mensagem para {_contato.Nome}: \n\t{_mensagem}";
        }
    }
}