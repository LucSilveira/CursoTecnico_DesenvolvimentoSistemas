using DoLink.Comum.Commands;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Empresa
{
    public class AlterarEmpresaCommand : Notifiable, ICommand
    {
        public AlterarEmpresaCommand()
        {}

        public AlterarEmpresaCommand(string id, IFormFile arquivo,  string imagem, string nome, string email, string telefone, string cNPJ, string cEP, string regiao, string descricao, string dominio)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CNPJ = cNPJ;
            CEP = cEP;
            Regiao = regiao;
            Descricao = descricao;
            Dominio = dominio;
            Arquivo = arquivo;
            Imagem = imagem;
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public IFormFile Arquivo { get; set; }
        public string Imagem { get; set; }
        public string CNPJ { get; set; }
        public string CEP { get; set; }
        public string Regiao { get; set; }
        public string Descricao { get; set; }
        public string Dominio { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id", "O Id deve ser válido")
                .HasMinLen(Nome, 5, "Nome", "O nome deve ter no mínimo 5 caractéres!")
                .HasMaxLen(Nome, 30, "Nome", "O nome deve ter no máximo 30 caractéres!")
                .IsEmail(Email, "Email", "O email deve ser um email válido!")
                .IsCnpj(CNPJ, "CNPJ", "O CNPJ deve ser válido!")
                .IsCep(CEP, "CEP", "Informe um CEP válido!")
                .HasMinLen(Regiao, 5, "Região", "A Região deve ter no mínimo 5 caractéres!")
                .HasMaxLen(Regiao, 20, "Região", "A Região deve ter no máximo 20 caractéres!")
                .HasMinLen(Descricao, 10, "Descrição", "A descrição deve ter no mínimo 10 caractéres")
                .HasMaxLen(Descricao, 300, "Descrição", "A descrição deve ter no máximo 300 caractéres")
                .IsUrl(Dominio, "Domínio", "O domínio deve ser um link válido")
                .IsNotNullOrEmpty(Imagem, "Imagem da empresa", "O logo da empresa deve ser informada!")
            );
        }
    }
}
