﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Comum.Utils
{
    public static class Senha
    {

        public static string CriptografarSenha(string senha)
        {
            //TODO : IMPLEMENTAR CRIPTOGRAFIA DE SENHA.
            return BCrypt.Net.BCrypt.HashPassword(senha);

        }

        public static bool Validar(string senha, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hashPassword);
        }

        public static string Gerar()
        {
            string caracteres = "abcdefstwxyz023489@!%&*";
            string senha = "";
            Random random = new Random();
            for (int f = 0; f < 8; f++)
            {
                senha = senha + caracteres.Substring(random.Next(0, caracteres.Length - 1), 1);
            }

            return senha;
        }

    }
}
