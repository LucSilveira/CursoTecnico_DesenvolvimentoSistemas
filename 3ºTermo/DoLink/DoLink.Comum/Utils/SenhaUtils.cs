using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Comum.Utils
{
    public static class SenhaUtils
    {
        /// <summary>
        /// Método para criptografar a senha
        /// </summary>
        /// <param name="_senha">Senha que será encriptografada</param>
        /// <returns>Senha encriptografada</returns>
        public static string CriptografarSenha(string _senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(_senha);
        }

        /// <summary>
        /// Método para validar a senha caso a mesma confirme com o hash existe
        /// </summary>
        /// <param name="_senha">Senha informada</param>
        /// <param name="_hashPassword">Hash salvo no banco</param>
        /// <returns></returns>
        public static bool ValidarSenha(string _senha, string _hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(_senha, _hashPassword);
        }

        /// <summary>
        /// Método para gerar uma nova senha caso necessário
        /// </summary>
        /// <returns>Nova senha gerada</returns>
        public static string GerarNovaSenha()
        {
            string _guid = Guid.NewGuid().ToString().Replace("-", "");

            Random _random = new Random();
            int _tamanhoSenha = _random.Next(6, 10);

            string _senhaGerada = "";

            for (int i = 0; i < _tamanhoSenha; i++)
            {
                _senhaGerada += _guid.Substring(_random.Next(1, _guid.Length), 1);
            }

            return _senhaGerada;
        }
    }
}
