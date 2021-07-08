using DoLink.Comum.Entidades;
using Flunt.Validations;
using Flunt.Br.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DoLink.Comum.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson.Serialization.Attributes;

namespace DoLink.Dominio.Entidades
{
    public class Empresa : Usuario
    {
        public Empresa()
        {
            TipoPerfil = EnTipoPerfil.Empresa;
        }

        public Empresa(string nome, string email, string senha, string telefone)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nome, 5, "Nome da Empresa", "O nome da empresa deve ter no mínimo 5 caractéres!")
                .HasMaxLen(nome, 30, "Nome da Empresa", "O nome da empresa deve ter no máximo 30 caractéres!")
                .IsEmail(email, "Email", "O email deve ser um email válido!")
                .HasMinLen(senha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres!")
                .IsNewFormatCellPhone(telefone, "Telefone", "O telefone da empresa deve ser válido")
            );

            if (Valid)
            {
                Nome = nome;
                Email = email;
                Senha = senha;
                Telefone = telefone;
                TipoPerfil = EnTipoPerfil.Empresa;
            }
        }

        public Empresa AlterarEmpresaGeneral(string imagem, string cnpj, string cep, string regiao, string descricao, string dominio)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsCnpj(cnpj, "CNPJ", "O CNPJ deve ser válido!")
                .IsCep(cep, "CEP", "Informe um CEP válido!")
                .IsNotNullOrEmpty(imagem, "Imagem da empresa", "O logo da empresa deve ser informada!")
                .HasMinLen(regiao, 5, "Região", "A Região deve ter no mínimo 5 caractéres!")
                .HasMaxLen(regiao, 20, "Região", "A Região deve ter no máximo 20 caractéres!")
                .HasMinLen(descricao, 10, "Descrição", "A descrição deve ter no mínimo 10 caractéres")
                .HasMaxLen(descricao, 300, "Descrição", "A descrição deve ter no máximo 300 caractéres")
                .IsUrl(dominio, "Domínio", "O domínio deve ser um link válido")
            );

            if (Valid)
            {
                Imagem = imagem;
                CNPJ = cnpj;
                CEP = cep;
                Regiao = regiao;
                Descricao = descricao;
                Dominio = dominio;
            }

            return null;
        }

        public Empresa AlterarEmpresa(string id,string nome, string email, string telefone, string cNPJ, string cEP, string regiao, string descricao, string dominio, string imagem)
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(id, Guid.Empty, "Id", "Houve um erro na identificação da empresa!")
                .HasMinLen(nome, 5, "Nome de Empresa", "O nome da empresa deve ter no mínimo 5 caractéres!")
                .HasMaxLen(nome, 60, "Nome de Empresa", "O nome da empresa deve ter no máximo 60 caractéres!")
                .IsEmail(email, "Email", "O email deve ser um email válido!")
                .IsCnpj(cNPJ, "CNPJ", "O CNPJ deve ser válido!")
                .IsCep(cEP, "CEP", "Informe um CEP válido!")
                .HasMinLen(regiao, 5, "Região", "A Região deve ter no mínimo 5 caractéres!")
                .HasMaxLen(regiao, 20, "Região", "A Região deve ter no máximo 20 caractéres!")
                .HasMinLen(descricao, 10, "Descrição", "A descrição deve ter no mínimo 10 caractéres")
                .HasMaxLen(descricao, 300, "Descrição", "A descrição deve ter no máximo 300 caractéres")
                .IsUrl(dominio, "Domínio", "O domínio deve ser um link válido")
                .IsNotNullOrEmpty(imagem, "Imagem da empresa", "O logo da empresa deve ser informada!")
            );

            if (Valid)
            {
                Id = id;
                Descricao = descricao;
                Nome = nome;
                Imagem = imagem;
                Telefone = telefone;
                Dominio = dominio;
                CNPJ = cNPJ;
                CEP = cEP;
                Regiao = regiao;
                Email = email;
            }

            return null;
        }

        public void AlterarCnpj(string cnpj)
        {
            AddNotifications(new Contract()
               .Requires()
               .IsCnpj(cnpj, "CNPJ", "O CNPJ deve ser válido!")
            );

            if (Valid)
            {
                CNPJ = cnpj;
            }
        }

        public void AlterarDescricao(string descricao)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(descricao, 10, "Descrição", "A descrição deve ter no mínimo 10 caractéres")
                .HasMaxLen(descricao, 300, "Descrição", "A descrição deve ter no máximo 300 caractéres")
            );

            if (Valid)
            {
                Descricao = descricao;
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

        public string CNPJ { get; private set; }
        public string CEP { get; private set; }
        public string Regiao { get; private set; }
        public string Descricao { get; private set; }
        public string Dominio { get; private set; }

        [BsonIgnore]
        [JsonIgnore]
        public IFormFile Arquivo { get; private set; }
        public string Imagem { get; set; }
    }
}
