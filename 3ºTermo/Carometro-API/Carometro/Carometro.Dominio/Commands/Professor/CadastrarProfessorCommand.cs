using Carometro.Comum.Commands;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.Professor
{
    public class CadastrarProfessorCommand : Notifiable, ICommand
    {
        public CadastrarProfessorCommand(string nomeProfessor, string email, string senha, string telefone, string fotoProfessor)
        {
            Nome = nomeProfessor;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            FotoProfessor = fotoProfessor;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "NomeProfessor", "O Nome do Professor deve conter no mínimo 3 caractéres")
                .IsEmail(Email, "Email", "Informe um Email válido")
                .HasMinLen(Senha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres")
                .IsNewFormatCellPhone(Telefone, "Telefone", "Insira um Número de Telefone Válido")
                .IsNotNullOrEmpty(FotoProfessor, "Foto do professor", "Informe uma imagem para o professor")
            );
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string FotoProfessor { get; set; }
    }
}
