using Carometro.Comum.Commands;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.Admin
{
    public class AlterarContaCommand : Notifiable, ICommand
    {
        public AlterarContaCommand(string nomeUsuario, string email, string telefone)
        {
            Nome = nomeUsuario;
            Email = email;
            Telefone = telefone;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "O Nome deve ter no mínimo 3 caractéres")
                .HasMaxLen(Nome, 40, "Nome", "O Nome deve ter no máximo 40 caractéres")
                .IsEmail(Email, "Email", "Informe um Email válido")
                .IsNewFormatCellPhone(Telefone, "Telefone", "Insira um Número de Telefone Válido")
                .AreNotEquals(Id, Guid.Empty, "Id do admininstrador", "O id do administrador não foi informado")
             );
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
