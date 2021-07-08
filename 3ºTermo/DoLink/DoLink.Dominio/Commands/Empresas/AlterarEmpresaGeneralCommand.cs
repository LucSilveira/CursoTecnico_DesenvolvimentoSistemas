using DoLink.Comum.Commands;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Empresas
{
    public class AlterarEmpresaGeneralCommand : Notifiable, ICommand
    {
        public AlterarEmpresaGeneralCommand()
        {}

        public AlterarEmpresaGeneralCommand(string id, IFormFile arquivo, string imagem, string cNPJ, string cEP, string regiao, string descricao, string dominio)
        {
            Id = id;
            Arquivo = arquivo;
            Imagem = imagem;
            CNPJ = cNPJ;
            CEP = cEP;
            Regiao = regiao;
            Descricao = descricao;
            Dominio = dominio;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id", "O Id deve ser válido")
                .IsCnpj(CNPJ, "CNPJ", "O CNPJ deve ser válido!")
                .IsCep(CEP, "CEP", "Informe um CEP válido!")
                .IsNotNullOrEmpty(Imagem, "Imagem da empresa", "O logo da empresa deve ser informada!")
                .HasMinLen(Regiao, 5, "Região", "A Região deve ter no mínimo 5 caractéres!")
                .HasMaxLen(Regiao, 20, "Região", "A Região deve ter no máximo 20 caractéres!")
                .HasMinLen(Descricao, 10, "Descrição", "A descrição deve ter no mínimo 10 caractéres")
                .HasMaxLen(Descricao, 300, "Descrição", "A descrição deve ter no máximo 300 caractéres")
                .IsUrl(Dominio, "Domínio", "O domínio deve ser um link válido")
            );
        }

        public string Id { get; set; }
        public IFormFile Arquivo { get; set; }
        public string Imagem { get; set; }
        public string CNPJ { get; set; }
        public string CEP { get; set; }
        public string Regiao { get; set; }
        public string Descricao { get; set; }
        public string Dominio { get; set; }
    }
}
