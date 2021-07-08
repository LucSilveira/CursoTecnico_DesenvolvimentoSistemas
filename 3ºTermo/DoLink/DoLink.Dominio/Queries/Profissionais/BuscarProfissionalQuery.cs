using DoLink.Comum.Queries;
using DoLink.Dominio.Entidades;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Queries.Profissionais
{
    public class BuscarProfissionalQuery : Notifiable, IQuery
    {
        public BuscarProfissionalQuery(string profissional)
        {
            Profissional = profissional;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsCpf(Profissional, "Cpf do profissional", "O CPF informado é inválido")
            );
        }

        public string Profissional { get; set; }
    }

    public class BuscarProfissionalResult
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public string CPF { get; set; }
        public float FaixaSalarial { get; set; }
        public string SobreMim { get; set; }
        public string Linkedin { get; set; }
        public string Repositorio { get; set; }
        public Curriculo Curriculo { get; set; }
        public Skill[] Skills { get; set; }
    }
}
