using DoLink.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Vaga
{
    public class AlterarVagaCommand : Notifiable, ICommand
    {
        public AlterarVagaCommand(string titulo, string descricao, int status, string local , float faixaSalarial, string beneficios, DateTime dataValidacao)
        {

            Titulo = titulo;
            Descricao = descricao;
            Status = status;
            Local = local;
            FaixaSalarial = faixaSalarial;
            Beneficios = beneficios;
            DataVencimento = dataValidacao;
        }

        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
        public string Local { get; set; }
        public float FaixaSalarial { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Beneficios { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .HasMinLen(Titulo, 3, "Título", "O título deve ter no mínimo 3 caracteres")
               .HasMaxLen(Titulo, 70, "Título", "O título deve ter no máximo 70 caracteres")
               .HasMinLen(Descricao, 10, "Descrição", "A descrição deve ter no mínimo 10 caracteres")
               .HasMaxLen(Descricao, 300, "Descrição", "A descrição deve ter no máximo 300 caracteres")
               .HasMinLen(Local, 3, "Local", "O local deve ter no mínimo 3 caracteres")
               .HasMaxLen(Local, 70, "Local", "O local deve ter no máximo 70 caracteres")
               .HasMinLen(Beneficios, 10, "Benefícios", "Os benefícios deve ter no mínimo 10 caractéres")
               .HasMaxLen(Beneficios, 300, "Benefícios", "Os benefícios deve ter no máximo 300 caractéres")
               .IsNotNull(FaixaSalarial, "Faixa salarial", "A faixa salarial não deve ser informada")
               );
        }
    }
}
