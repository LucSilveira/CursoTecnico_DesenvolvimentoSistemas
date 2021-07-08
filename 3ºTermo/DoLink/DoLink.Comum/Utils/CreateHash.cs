using DoLink.Comum.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Comum.Utils
{
    public static class CreateHash
    {
        public static string HashSkill()
        {
            Random random = new Random();
            int tamanhoHash = random.Next(6, 7);
            string guid = Guid.NewGuid().ToString().Replace("-", "");

            string _hash = "";

            for (int i = 0; i < tamanhoHash; i++)
            {
                _hash += guid.Substring(random.Next(1, guid.Length), 1);
            }

            return _hash;
        }
    }
}
