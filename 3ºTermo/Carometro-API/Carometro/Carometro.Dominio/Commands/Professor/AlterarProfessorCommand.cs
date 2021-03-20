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
    public class AlterarProfessorCommand : Notifiable, ICommand
    {
        public AlterarProfessorCommand(Guid id, string nome, string email, string telefone, string fotoProfessor)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            FotoProfessor = fotoProfessor;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id de indentificação", "o id do professor não foi especificado")
                .HasMinLen(Nome, 3, "Nome professor", "O Nome do Professor deve conter no mínimo 3 caractéres")
                .IsEmail(Email, "Email", "Informe um Email válido")
                .IsNewFormatCellPhone(Telefone, "Telefone", "Insira um Número de Telefone Válido")
                .IsNotNullOrEmpty(FotoProfessor, "Foto do professor", "Informe uma imagem para o professor")
            );
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string FotoProfessor { get; set; }
    }
}
