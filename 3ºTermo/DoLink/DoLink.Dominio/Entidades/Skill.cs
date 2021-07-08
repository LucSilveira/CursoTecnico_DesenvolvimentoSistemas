using DoLink.Comum.Entidades;
using DoLink.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Entidades
{
    public class Skill : Entidade
    {
        public Skill()
        {
            Nivel = EnNivelConhecimento.Padrao;
            Tipo = EnTipoSkill.Padrao;
        }

        public Skill(string nome, string hash)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(nome, "Nome", "Informe o nome da habilidade")
            );

            if (Valid)
            {
                Nome = nome;
                Hash = hash;
            }
        }

        public void AlterarSkill(string nome)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(nome, "Nome", "Informe o nome da habilidade")
            );

            if (Valid)
            {
                Nome = nome;
            }
        }

        public string Nome { get; set; }
        public EnNivelConhecimento Nivel { get; set; }
        public EnTipoSkill Tipo { get; set; }
        public string Hash { get; set; }
    }
}
