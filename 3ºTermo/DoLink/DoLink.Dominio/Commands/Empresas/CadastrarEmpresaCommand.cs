using DoLink.Comum.Commands;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Empresa
{
    public class CadastrarEmpresaCommand : Notifiable, ICommand
    {
        public CadastrarEmpresaCommand()
        {}

        public CadastrarEmpresaCommand(string nome, string email, string senha, string telefone)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 5, "Nome", "O nome deve ter no mínimo 5 caractéres!")
                .HasMaxLen(Nome, 30, "Nome", "O nome deve ter no máximo 30 caractéres!")
                .IsEmail(Email, "Email", "O email deve ser um email válido!")
                .HasMinLen(Senha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres!")
            );
        }
    }
}
