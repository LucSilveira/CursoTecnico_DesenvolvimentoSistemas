using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Pacotes
{
    /// <summary>
    /// Classe responsável pelo comando de alteração dos pacotes
    /// </summary>
    public class AlterarPacoteCommand : Notifiable, ICommand
    {
        /// <summary>
        /// Construtor do comando de alteração do objeto pacote
        /// </summary>
        /// <param name="idPacote">Código de identificação do próprio pacote</param>
        /// <param name="titulo">Titulo alterado</param>
        /// <param name="descricao">Descrição alterada</param>
        public AlterarPacoteCommand(Guid idPacote, string titulo, string descricao)
        {
            IdPacote = idPacote;
            Titulo = titulo;
            Descricao = descricao;
        }

        /// <summary>
        /// Método de validação dos parametros para alteração do objeto pacote
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdPacote, Guid.Empty, "IdPacote", "O id do pacote está inválido")
                .IsNotNullOrEmpty(Titulo, "Titulo", "Informe um título ao pacote")
                .HasMinLen(Titulo, 15, "Título", "O título deve possuir no mínimo 15 caracteres")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Informe uma descrição detalhando o pacote")
            );
        }

        public Guid IdPacote { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
