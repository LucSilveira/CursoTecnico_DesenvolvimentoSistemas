using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuarios
{
    /// <summary>
    /// Classe responsável pelo comando de alteração dos usuários
    /// </summary>
    public class AlterarUsuarioCommand : Notifiable, ICommand
    {
        /// <summary>
        /// Construtor do comando de alteração do objeto usuário
        /// </summary>
        /// <param name="idUsuario">Código de identificação do próprio usuário</param>
        /// <param name="nome">Nome do usuário</param>
        /// <param name="email">Email de contato</param>
        public AlterarUsuarioCommand(Guid idUsuario, string nome, string email, string telefone)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        /// <summary>
        /// Método de validação dos parametros para alteração do objeto usuário
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Id do usuário inválido")
                .HasMinLen(Nome, 3, "Nome", "O nome deve possuir no mínimo 3 caracteres")
                .HasMaxLen(Nome, 50, "Nome", "O nome deve possuir no máximo 50 caracteres")
                .IsEmail(Email, "Email", "Informe um email válido")
            );
        }

        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
