using DoLink.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Utils
{
    public static class OrdenarSkills
    {
        public static Skill[] OrdenarArray(Skill[] array)
        {
            StringComparer ordenar = StringComparer.InvariantCultureIgnoreCase;

            var nome = "";

            for (var i = 0; i < array.Length; i++)
            {
                nome = nome + array[i].Nome;
                if (i < array.Length - 1)
                {
                    nome = nome + ",";
                }
            }

            string[] lista = nome.Split(',');

            Skill[] listaResultadoSkill = new Skill[array.Length];

            Array.Sort(lista, ordenar);


            for (var i = 0; i < lista.Length; i++)
            {
                for (var j = 0; j < array.Length; j++)
                {
                    if (lista[i] == array[j].Nome)
                    {
                        listaResultadoSkill[i] = (array[j]);
                    }
                }
            }

            return listaResultadoSkill;
        }
    }
}
