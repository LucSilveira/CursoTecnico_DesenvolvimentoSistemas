using Carometro.Comum.Commands;
using Carometro.Comum.Enum;
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
    public class CadastrarContaCommand : Notifiable, ICommand
    {

        public CadastrarContaCommand()
        {

        }

        public CadastrarContaCommand(string nome, string email, string senha, string telefone, EnTipoUsuario tipoUsuario)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            TipoUsuario = tipoUsuario;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public EnTipoUsuario TipoUsuario { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "O Nome deve ter no mínimo 3 caractéres")
                .HasMaxLen(Nome, 40, "Nome", "O Nome deve ter no máximo 40 caractéres")
                .IsEmail(Email, "Email", "Informe um Email válido")
                .IsNewFormatCellPhone(Telefone, "Telefone", "Insira um Número de Telefone Válido")
                .HasMinLen(Senha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres")
                .HasMaxLen(Senha, 20, "Senha", "A senha deve ter no mínimo 20 caractéres")
                );
        }
    }
}
