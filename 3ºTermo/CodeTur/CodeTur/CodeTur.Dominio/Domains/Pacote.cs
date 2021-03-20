using CodeTur.Comum.Domain;
using Flunt.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace CodeTur.Dominio.Domains
{
    public class Pacote : BaseDomain
    {
        public Pacote()
        {
        }

        /// <summary>
        /// Construtor responsável por fazer a validação dos paramêtros do objeto pacote
        /// </summary>
        /// <param name="titulo">Título do pacote</param>
        /// <param name="descricao">Descrição detalhada sobre suas ofertas</param>
        /// <param name="imagem">Imagem dobre o lugar tratado no pacote</param>
        /// <param name="ativo">Status do pacote</param>
        public Pacote(string titulo, string descricao, string imagem, bool ativo)
        {
            //Adicionando um contrato na aplicação para validação dos parametros
            //informados acerca do objeto pacote
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(titulo, "Título", "Informe um título ao pacote")
                .HasMinLen(titulo, 15, "Título", "O título deve possuir no mínimo 15 caracteres")
                .IsNotNullOrEmpty(descricao, "Descricao", "Informe uma descrição detalhando o pacote")
                .HasMinLen(descricao, 25, "Descricao", "A descricao deve possuir no mínimo 25 caracteres")
                .IsNotNullOrEmpty(imagem, "Imagem", "Informe uma imagem ao pacote")
            );

            //Verificando se todos os atributos estão corretos
            //para atribuir a um novo objeto pacotes
            if (Valid)
            {
                Titulo = titulo;
                Descricao = descricao;
                Imagem = imagem;
                Ativo = ativo;
                _comentarios = new List<Comentario>();
            }
        }

        /// <summary>
        /// Método para alterar os dados contidos no pacote
        /// </summary>
        /// <param name="titulo">Titulo do pacote</param>
        /// <param name="descricao">Possível descrição adicionada ou alterada</param>
        public void AlterarPacote(string titulo, string descricao)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(titulo, "Titulo", "Informe um título ao pacote")
                .HasMinLen(titulo, 15, "Título", "O título deve possuir no mínimo 15 caracteres")
                .IsNotNullOrEmpty(descricao, "Descricao", "Informe uma descrição detalhando o pacote")
            );

            if (Valid)
            {
                Titulo = titulo;
                Descricao = descricao;
                DataAlteracao = DateTime.Now;
            }
        }

        /// <summary>
        /// Método para alterar a imagem dentro do pacote
        /// </summary>
        /// <param name="imagem">Imagem a ser alterada</param>
        public void AlterarImagemPacote(string imagem)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(imagem, "Imagem", "Informe uma imagem ao pacote")
            );

            if (Valid)
            {
                Imagem = imagem;
                DataAlteracao = DateTime.Now;
            }
        }

        /// <summary>
        /// Método para alterar o status do pacote seja para ativalo ou desativalo
        /// </summary>
        public void AlterarStatus(bool ativo)
        {
            Ativo = ativo;
            DataAlteracao = DateTime.Now;
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile Arquivo { get; set; }

        public string Imagem { get; private set; }
        public bool Ativo { get; private set; }


        //Atribuindo a lista de comentários pertencentes ao pacote
        private readonly IList<Comentario> _comentarios;
        public IReadOnlyCollection<Comentario> Comentarios { get; set; }


        /// <summary>
        /// Método para adicionar um novo comentário dentro do pacote especificado
        /// </summary>
        /// <param name="comentario">O próprio comentário do usuário</param>
        public void AdicionarComentario(Comentario comentario)
        {
            //Verificando se o usuário já possui um comentário cadastrado dentro do pacote
            if (_comentarios.Any(cmt => cmt.IdUsuario == comentario.IdUsuario))
            {
                AddNotification("Comentários", "Usuário já possui um comentário no pacote");
            }

            //Caso não tenha, adicionamos o seu comentário ao pacote selecionado
            if (Valid)
            {
                _comentarios.Add(comentario);
            }
        }
    }
}
