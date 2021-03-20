using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Pacotes
{
    /// <summary>
    /// Classe para definir os comandos de criação dos nossos pacotes
    /// </summary>
    public class CriarPacoteCommand : Notifiable, ICommand
    {
        public CriarPacoteCommand()
        {

        }

        /// <summary>
        /// Construtor de comando para criação do objeto pacotes
        /// </summary>
        /// <param name="titulo">Título do pacote</param>
        /// <param name="descricao">Descrição detalhada da oferta</param>
        /// <param name="imagem">Imagem de referencia do local</param>
        /// <param name="ativo">Status de ativação do pacote</param>
        public CriarPacoteCommand(string titulo, string descricao, string imagem, bool ativo)
        {
            Titulo = titulo;
            Descricao = descricao;
            Imagem = imagem;
            Ativo = ativo;
        }

        /// <summary>
        /// Método de validação dos parametros do objeto pacote
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Titulo, "Título", "Informe um título ao pacote")
                .HasMinLen(Titulo, 15, "Título", "O título deve possuir no mínimo 15 caracteres")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Informe uma descrição detalhando o pacote")
                .HasMinLen(Descricao, 25, "Descricao", "A descricao deve possuir no mínimo 25 caracteres")
                .IsNotNullOrEmpty(Imagem, "Imagem", "Informe uma imagem ao pacote")
            );
        }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IFormFile Arquivo { get; set; }
        public string Imagem { get; set; }
        public bool Ativo { get; set; }
    }
}
