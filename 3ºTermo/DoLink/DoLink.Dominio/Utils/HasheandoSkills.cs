using DoLink.Comum.Enum;
using DoLink.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Utils
{
    public static class HasheandoSkills
    {
        public static string Hasheando(Skill[] array)
        {
            var hash = "";

            foreach(Skill skill in array)
            {
                hash += skill.Hash;

                if(skill.Nivel == EnNivelConhecimento.Iniciante)
                {
                    hash += "bsic";
                }
                else if(skill.Nivel == EnNivelConhecimento.Intermediario)
                {
                    hash += "intr";
                }
                else
                {
                    hash += "hard";
                }
            }

            return hash;
        }

        public static (string, string) HashSkill(Skill[] array)
        {
            string hashRequerida = "";
            string hashDesejavel = "";

            foreach(Skill skill in array)
            {
                if(skill.Tipo == EnTipoSkill.Requerida)
                {
                    if(skill.Nivel == EnNivelConhecimento.Iniciante)
                    {
                        hashRequerida += skill.Hash + "bsic|";
                    }
                    else if(skill.Nivel == EnNivelConhecimento.Intermediario)
                    {
                        hashRequerida += skill.Hash + "intr|";
                    }
                    else
                    {
                        hashRequerida += skill.Hash + "hard|";
                    }
                }
                else
                {
                    if (skill.Nivel == EnNivelConhecimento.Iniciante)
                    {
                        hashDesejavel += skill.Hash + "bsic|";
                    }
                    else if (skill.Nivel == EnNivelConhecimento.Intermediario)
                    {
                        hashDesejavel += skill.Hash + "intr|";
                    }
                    else
                    {
                        hashDesejavel += skill.Hash + "hard|";
                    }
                }
            }

            return (hashRequerida, hashDesejavel);
        }
    }
}
