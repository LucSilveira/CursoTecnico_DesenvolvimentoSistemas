using CodeTur.Comum.Commands;
using CodeTur.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuarios
{
    /// <summary>
    /// Classe para definir os comandos de criação dos usuários
    /// </summary>
    public class CriarUsuarioCommand : Notifiable, ICommand
    {
        public CriarUsuarioCommand()
        {

        }

        /// <summary>
        /// Construtor de comando para criação do objeto usuário
        /// </summary>
        /// <param name="nome">Nome do usuário</param>
        /// <param name="email">Email de contato</param>
        /// <param name="senha">Senha de autorização</param>
        /// <param name="telefone">Telefone de contato opcional</param>
        /// <param name="tipoPerfil">Perfil de acesso de usuário</param>
        public CriarUsuarioCommand(string nome, string email, string senha, string telefone, EnTipoPerfil tipoPerfil)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            TipoPerfil = tipoPerfil;
        }

        /// <summary>
        /// Método de validação dos parametros do objeto usuário
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "O nome deve possuir no mínimo 3 caracteres")
                .HasMaxLen(Nome, 50, "Nome", "O nome deve possuir no máximo 50 caracteres")
                .IsEmail(Email, "Email", "Informe um email válido")
                .HasMinLen(Senha, 6, "Senha", "A senha deve possuir no mínimo 6 caracteres")
                .HasMaxLen(Senha, 80, "Senha", "A senha deve possuir no máximo 80 caracteres")
            );
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public EnTipoPerfil TipoPerfil { get; set; }
    }
}
