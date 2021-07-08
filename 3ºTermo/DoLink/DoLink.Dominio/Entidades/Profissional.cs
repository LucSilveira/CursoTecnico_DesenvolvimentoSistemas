using DoLink.Comum.Entidades;
using DoLink.Comum.Enum;
using Flunt.Br.Extensions;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Entidades
{
    public class Profissional : Usuario
    {
        public Profissional()
        {
            TipoPerfil = EnTipoPerfil.Profissional;
        }

        public Profissional(string nome, string email, string senha, string telefone)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nome, 5, "Nome da Empresa", "O nome da empresa deve ter no mínimo 5 caractéres!")
                .HasMaxLen(nome, 30, "Nome da Empresa", "O nome da empresa deve ter no máximo 30 caractéres!")
                .IsEmail(email, "Email", "O email deve ser um email válido!")
                .HasMinLen(senha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres!")
                .IsNewFormatCellPhone(telefone, "Telefone", "Insira um número de telefone válido")
            );

            if (Valid)
            {
                Nome = nome;
                Email = email;
                Senha = senha;
                Telefone = telefone;
                TipoPerfil = EnTipoPerfil.Profissional;
            }
        }

        public void AlterarProfissionalGeral(string cPF, string cEP, string sobreMim, string linkedin, string repositorio, float faixaSalarial, Curriculo curriculo, Skill[] skills, string hash)
        {
            AddNotifications(new Contract()
               .Requires()
               .IsCpf(cPF, "CPF", "Informe um CPF válido")
               .IsCep(cEP, "CEP", "Informe um CEP válido")
               .HasMinLen(sobreMim, 15, "Sobre mim", "A descrição deve conter no mínimo 15 caractéres")
               .IsUrl(linkedin, "Link do LinkedIn", "Informe um link do linkedin válido")
               .IsUrl(repositorio, "Link do Github", "Informe um link do github válido")
               .IsNotNull(faixaSalarial, "Faixa salarial", "A faixa salarial deve ser informada")
            );

            if (Valid)
            {
                CPF = cPF;
                CEP = cEP;
                SobreMim = sobreMim;
                Linkedin = linkedin;
                Repositorio = repositorio;
                FaixaSalarial = faixaSalarial;
                CurriculoProfissional = curriculo;
                SkillsProfissional = skills;
                Hash = hash;
            }
        }

        public void AlterarProfissional(string nome, string email, string telefone, string cPF, string cEP, string sobreMim, string linkedin, string repositorio, float faixaSalarial)
        {
            AddNotifications(new Contract()
               .Requires()
               .HasMinLen(nome, 5, "Nome da Empresa", "O nome da empresa deve ter no mínimo 5 caractéres!")
               .HasMaxLen(nome, 30, "Nome da Empresa", "O nome da empresa deve ter no máximo 30 caractéres!")
               .IsEmail(email, "Email", "O email deve ser um email válido!")
               .IsNewFormatCellPhone(telefone, "Telefone", "Insira um número de telefone válido")
               .IsCpf(cPF, "CPF", "Informe um CPF válido")
               .IsCep(cEP, "CEP", "Informe um CEP válido")
               .HasMinLen(sobreMim, 15, "Sobre mim", "A descrição deve conter no mínimo 15 caractéres")
               .IsUrl(linkedin, "Link do LinkedIn", "Informe um link do linkedin válido")
               .IsUrl(repositorio, "Link do Github", "Informe um link do github válido")
               .IsNotNull(faixaSalarial, "Faixa salarial", "A faixa salarial deve ser informada")
            );

            if (Valid)
            {
                Nome = nome;
                Email = email;
                Telefone = telefone;
                CPF = cPF;
                CEP = cEP;
                FaixaSalarial = faixaSalarial;
                SobreMim = sobreMim;
                Linkedin = linkedin;
                Repositorio = repositorio;
            }
        }

        public void AlterarSenha(string senha)
        {
            AddNotifications(new Contract()
               .Requires()
               .HasMinLen(senha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres!")
            );

            if (Valid)
            {
                Senha = senha;
            }
        }

        public void AlterarCPFProfissional(string cPF)
        {
            AddNotifications(new Contract()
               .Requires()
               .IsCpf(cPF, "CPF", "Informe um CPF válido")
            );

            if (Valid)
            {
                CPF = cPF;
            }
        }

        public void AlterarSkills(Skill[] skills, string hash)
        {
            SkillsProfissional = skills;
            Hash = hash;
        }

        public string CPF { get; private set; }
        public string CEP { get; private set; }
        public string SobreMim { get; private set; }
        public float FaixaSalarial { get; private set; }
        public string Linkedin { get; private set; }
        public string Repositorio { get; private set; }
        public Curriculo CurriculoProfissional { get; private set; }
        public Skill[] SkillsProfissional { get; private set; }
        public string Hash { get; private set; }
    }
}
