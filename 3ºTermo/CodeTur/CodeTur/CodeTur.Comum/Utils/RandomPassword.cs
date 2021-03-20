using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Utils
{
    public static class RandomPassword
    {
        public static string GeradorDeSenha()
        {
            string _guid = Guid.NewGuid().ToString().Replace("-", "");

            Random _random = new Random();
            int _tamanhoSenha = _random.Next(6, 10);

            string _senhaGerada = "";

            for(int i = 0; i < _tamanhoSenha; i++)
            {
                _senhaGerada += _guid.Substring(_random.Next(1, _guid.Length), 1);
            }

            return _senhaGerada;
        }
    }
}
