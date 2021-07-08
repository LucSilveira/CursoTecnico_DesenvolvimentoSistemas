using DoLink.Comum.Queries;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Empresa
{
    public class ListarEmpresaQuery : Notifiable, IQuery
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
    public class ListarEmpresaResult
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
