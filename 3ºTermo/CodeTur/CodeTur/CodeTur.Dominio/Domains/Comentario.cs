using CodeTur.Comum.Domain;
using CodeTur.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Domains
{
    public class Comentario : BaseDomain
    {
        public Comentario()
        {
        }

        /// <summary>
        /// Construtor responsável por fazer a validação dos paramêtros do objeto comentário
        /// </summary>
        /// <param name="texto">Texto do comentário</param>
        /// <param name="sentimento">Sentimento identificado pelo usuário</param>
        /// <param name="idUsuario">Código de identificação do usuário</param>
        /// <param name="idPacote">Código de identificação do pacote</param>
        /// <param name="status">Status de autorização do comentário</param>
        public Comentario(string texto, string sentimento, Guid idUsuario, Guid idPacote, EnStatusComentario status)
        {
            //Adicionando um contrato na aplicação para validação dos parametros
            //informados acerca do objeto comentario
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(texto, "Texto", "Informe o texto do comentário")
                .HasMinLen(texto, 20, "Texto", "O texto deve ter no mínimo 20 caracteres")
                .IsNotNullOrEmpty(sentimento, "Sentimento", "Informe o sentimento do comentário")
                .AreNotEquals(idUsuario, Guid.Empty, "IdUsuario", "Informe o ID do usuário do comentário")
                .AreNotEquals(idPacote, Guid.Empty, "IdPacote", "Informe o ID do pacote do comentário")
            );

            //Verificando se todos os atributos estão corretos
            //para atribuir a um novo objeto comentario
            if (Valid)
            {
                Texto = texto;
                Sentimento = sentimento;
                IdUsuario = idUsuario;
                IdPacote = idPacote;
                Status = status;
            }
        }

        /// <summary>
        /// Método que alterara os status do comentário caso necessário
        /// </summary>
        /// <param name="status"></param>
        public void AlteraStatus(EnStatusComentario status)
        {
            Status = status;
        }

        /// <summary>
        /// Método para alterar o texto do comentário
        /// </summary>
        /// <param name="texto">Texto alterado ou adicionado</param>
        public void AlteraTexto(string texto)
        { 
            Texto = texto;
        }

        /// <summary>
        /// Método para alterar o sentimento identificado no comentário caso esteja
        /// infiel ao sentimento do cliente, ou o mesmo tenha alterado seu conteúdo publicado
        /// </summary>
        /// <param name="sentimento"></param>
        public void AlteraSentimento(string sentimento)
        {
            Sentimento = sentimento;
        }

        public string Texto { get; private set; }
        public string Sentimento { get; private set; }
        public EnStatusComentario Status { get; private set; }

        //Pegando a referência do usuário que criou o comentário
        public Guid IdUsuario { get; private set; }
        public virtual Usuario Usuario { get; private set; }

        //Pegando a referência do pacote que o comentário se designa
        public Guid IdPacote { get; private set; }
        public virtual Pacote Pacote { get; private set; }
    }
}
