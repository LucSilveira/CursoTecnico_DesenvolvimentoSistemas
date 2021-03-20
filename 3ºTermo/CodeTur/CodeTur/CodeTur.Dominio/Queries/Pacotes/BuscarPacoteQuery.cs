using CodeTur.Comum.Queries;
using CodeTur.Dominio.Domains;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Queries.Pacotes
{
    public class BuscarPacoteQuery : Notifiable, IQuery
    {
        //Construtor para recebermos nosso email de busca
        public BuscarPacoteQuery(string _parametro)
        {
            ParametroBuscaTitulo = _parametro;
        }

        //Construtor para recebermos nosso id de busca
        public BuscarPacoteQuery(Guid _parametro)
        {
            ParametroBuscaId = _parametro;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(ParametroBuscaTitulo, "Título", "Informe um título ao pacote")
                .HasMinLen(ParametroBuscaTitulo, 15, "Título", "O título deve possuir no mínimo 15 caracteres")
            );
        }

        public Guid ParametroBuscaId { get; set; }
        public string ParametroBuscaTitulo { get; set; }
    }

    public class BuscarPacoteResult
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public int QuantidadeComentarios { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
    }
}
