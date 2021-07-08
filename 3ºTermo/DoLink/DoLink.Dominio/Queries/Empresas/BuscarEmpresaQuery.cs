using DoLink.Comum.Queries;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Empresas
{
    public class BuscarEmpresaQuery : Notifiable, IQuery
    {

        public BuscarEmpresaQuery(string empresa)
        {
            Empresa = empresa;
        }

        public string Empresa { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsCnpj(Empresa, "Cnpj da empresa", "O Cnpj informado é inválido")
            );
        }
    }

    public class BuscarEmpersaResult
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string CNPJ { get; set; }
        public string CEP { get; set; }
        public string Regiao { get; set; }
        public string Descricao { get; set; }
        public string Dominio { get; set; }
        public string Imagem { get; set; }
    }
}
