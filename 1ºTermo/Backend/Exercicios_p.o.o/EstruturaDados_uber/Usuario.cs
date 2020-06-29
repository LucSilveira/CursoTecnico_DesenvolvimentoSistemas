namespace EstruturaDados_uber
{
    public class Usuario
    {
        private string login = "lucas@email.com";
        private string senha = "abc123";
        public string Nome { get; set; }

        public int idade = 0;
        public int Idade {

            get{ return idade; }

            set
            {
                if(idade > 0){
                    idade = value;
                }
            }
        }
        public string LocalizacaoAtual { get; set; }
        public string TokenLogin { get; set; }
        public string TipoAcesso { get; set; }


        /// <summary>
        /// Método para efetuar Login
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns>Login verdadeiro ou falso</returns>
        public bool Login(string login, string senha)
        {
            if(this.login == login && this.senha == senha)
            {
                TokenLogin = "asd123das321asd123dsa321asd123";
                return true;
            }

            return false;
        }


        /// <summary>
        /// Método para efetuar o logout
        /// </summary>
        public void Logout()
        {
            TokenLogin = "";
        }
    }
}