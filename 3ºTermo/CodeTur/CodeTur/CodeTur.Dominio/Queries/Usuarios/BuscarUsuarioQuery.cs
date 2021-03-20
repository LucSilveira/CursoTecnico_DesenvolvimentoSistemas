using CodeTur.Comum.Queries;
using CodeTur.Dominio.Domains;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Queries.Usuarios
{
    public class BuscarUsuarioQuery : Notifiable, IQuery
    {
        //Construtor para recebermos nosso email de busca
        public BuscarUsuarioQuery(string _parametro)
        {
            ParametroBuscaEmail = _parametro;
        }

        //Construtor para recebermos nosso id de busca
        public BuscarUsuarioQuery(Guid _parametro)
        {
            ParametroBuscaId = _parametro;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(ParametroBuscaEmail, "Email", "O email informado está inválido")
            );
        }

        public Guid ParametroBuscaId { get; set; }
        public string ParametroBuscaEmail { get; set; }
    }

    public class BuscarUsuarioResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCriacao { get; set; }
        public int QuantidadeComentarios { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
    }
}
