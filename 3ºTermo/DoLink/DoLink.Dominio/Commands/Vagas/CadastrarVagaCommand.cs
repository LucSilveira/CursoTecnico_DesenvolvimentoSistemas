using DoLink.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Vaga
{
    public class CadastrarVagaCommand : Notifiable, ICommand
    {
        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(IdEmpresa, Guid.Empty, "Id da empresa responsável", "Id da empresa responsável inválida")
               .HasMinLen(Titulo, 3, "Titulo", "O titulo deve ter no minimo 3 caracteres")
               .HasMaxLen(Titulo, 70, "Titulo", "O titulo deve ter no maximo 70 caracteres")
               .HasMinLen(Descricao, 10, "Descricao", "A Descricao deve ter no minimo 10 caracteres")
               .HasMaxLen(Descricao, 300, "Descricao", "A Descricao deve ter no maximo 300 caracteres")
               .HasMinLen(Local, 3, "Local", "O Local deve ter no minimo 3 caracteres")
               .HasMaxLen(Local, 70, "Local", "O Local deve ter no maximo 70 caracteres")
               .HasMinLen(Beneficios, 10, "Benefcios", "Os Benefcios deve ter no mínimo 10 caractéres")
               .HasMaxLen(Beneficios, 300, "Benefcios", "Os Benefcios deve ter no máximo 300 caractéres")
               .IsNotNull(FaixaSalarial, "FaixaSalarial", "A faixa Salarial nao deve ser nulo")
            );
        }

        public string IdEmpresa { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
        public string Local { get; set; }
        public DateTime DataVencimento { get; set; }
        public float FaixaSalarial { get; set; }
        public string Beneficios { get; set; }
        public DoLink.Dominio.Entidades.Skill[] EspecificacoesSkills { get; set; }
    }
}
