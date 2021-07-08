using DoLink.Comum.Entidades;
using DoLink.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoLink.Dominio.Entidades
{
    public class Vaga : Entidade
    {
        public Vaga()
        {}

        public Vaga(string idEmpresa, string titulo, string descricao, string local, float faixaSalarial, string beneficios, DateTime dataValidacao, Skill[] skills, string hash, string hashDesejavel)
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(idEmpresa, Guid.Empty, "Id da empresa responsável", "Id da empresa responsável inválida")
               .HasMinLen(titulo, 10, "Título", "O título deve ter no mínimo 10 caractéres!")
               .HasMaxLen(titulo, 70, "Título", "O título deve ter no máximo 70 caractéres!")
               .HasMinLen(descricao, 10, "Descrição", "A descrição deve ter no minimo 10 caracteres")
               .HasMaxLen(descricao, 300, "Descrição", "A descrição deve ter no maximo 300 caracteres")
               .HasMinLen(local, 3, "Local", "O local deve ter no mínimo 3 caractéres!")
               .HasMaxLen(local, 70, "Local", "O local deve ter no máximo 70 caractéres!")
               .HasMinLen(beneficios, 10, "Benefícios", "Os benefícios deve ter no mínimo 10 caractéres!")
               .HasMaxLen(beneficios, 300, "Benefícios", "Os benefícios deve ter no máximo 300 caractéres!")
               .IsNotNull(faixaSalarial, "Faixa salarial", "A faixa salarial deve ser informada")
            );

            if (Valid)
            {
                IdEmpresa = idEmpresa;
                Titulo = titulo;
                Descricao = descricao;
                FaixaSalarial = faixaSalarial;
                Beneficios = beneficios;
                Status = EnStatusVaga.Padrao;
                Local = local;
                EspecificacaoSkill = skills;
                DataVencimento = dataValidacao;
                HashRequeridas = hash;
                HashDesejaveis = hashDesejavel;
            }
        }


        public Vaga AlterarVaga(string titulo, string descricao, string local, float faixaSalarial, string beneficios, DateTime dataValidacao)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(titulo, 10, "Título", "O título deve ter no mínimo 10 caractéres!")
                .HasMaxLen(titulo, 70, "Título", "O título deve ter no máximo 70 caractéres!")
                .HasMinLen(descricao, 10, "Descrição", "A descrição deve ter no minimo 10 caracteres")
                .HasMaxLen(descricao, 300, "Descrição", "A descrição deve ter no maximo 300 caracteres")
                .HasMinLen(beneficios, 10, "Benefícios", "Os benefícios deve ter no mínimo 10 caractéres!")
                .HasMaxLen(beneficios, 300, "Benefícios", "Os benefícios deve ter no máximo 300 caractéres!")
                .IsNotNull(faixaSalarial, "Faixa salarial", "A faixa salarial deve ser informada")
            );

            if (Valid)
            {
                Titulo = titulo;
                Descricao = descricao;
                FaixaSalarial = faixaSalarial;
                Beneficios = beneficios;
                Status = EnStatusVaga.Padrao;
                Local = local;
                DataVencimento = dataValidacao;
            }

            return null;
        }

        public Vaga AlterarStatus(EnStatusVaga status)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(status, "Status", "O Status não pode ser nulo")
            );

            if (Valid)
            {
                Status = status;
            }

            return null;
        }

        public Vaga AlterarDataVencimento(DateTime dataVencimento)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(DataVencimento, "Data de vencimento", "A data vencimento deve ser informada")
            );

            if(Valid)
            {
                DataVencimento = dataVencimento;
            }

            return null;
        }

        public void AlterarDescricao(string descricao)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(descricao, 10, "Descrição", "A descrição deve ter no minimo 10 caracteres")
                .HasMaxLen(descricao, 300, "Descrição", "A descrição deve ter no maximo 300 caracteres")
            );

            if (Valid)
            {
                Descricao = descricao;
            }
        }

        public void AlterarSkills(Skill[] skills, string hash, string hashDesejavel)
        {
            EspecificacaoSkill = skills;
            HashRequeridas = hash;
            HashDesejaveis = hashDesejavel;
        }

        public string IdEmpresa { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public float FaixaSalarial { get; set; }
        public string Beneficios { get; set; }
        public EnStatusVaga Status { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Local { get; set; }
        public Skill[] EspecificacaoSkill { get; set; }
        public string HashRequeridas { get; private set; }
        public string HashDesejaveis { get; private set; }
    }
}
