using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Utils
{
    public static class HashDeSenha
    {
        public static string EncriptografarSenha(string _senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(_senha);
        }

        public static bool ValidarSenha(string _senha, string _hash)
        {
            return BCrypt.Net.BCrypt.Verify(_senha, _hash);
        }
    }
}
