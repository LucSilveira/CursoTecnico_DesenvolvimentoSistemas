using DoLink.Comum.Commands;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Profissionais
{
    public class AlterarProfissionalCommand : Notifiable, ICommand
    {
        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(Id, Guid.Empty, "Id do profissional", "Id do profissional inválido")
               .HasMinLen(Nome, 3, "Nome de usuário", "O nome deve ter no mínimo 3 caractéres")
               .IsEmail(Email, "Email", "Informe um Email válido")
               .IsNewFormatCellPhone(Telefone, "Telefone", "Insira um número de telefone válido")
               .IsCep(CEP, "CEP", "Informe um CEP válido")
               .HasMinLen(SobreMim, 15, "Sobre mim", "O texto deve conter no mínimo 15 caractéres")
               .IsUrl(Linkedin, "Link do LinkedIn", "Informe um link válido")
               .IsUrl(Repositorio, "Link do Github", "Informe um link válido")
               .IsNotNull(FaixaSalarial, "FaixaSalarial", "A faixa Salarial nao deve ser nulo")
            );
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string SobreMim { get; set; }
        public float FaixaSalarial { get; set; }
        public string Linkedin { get; set; }
        public string Repositorio { get; set; }
    }
}
