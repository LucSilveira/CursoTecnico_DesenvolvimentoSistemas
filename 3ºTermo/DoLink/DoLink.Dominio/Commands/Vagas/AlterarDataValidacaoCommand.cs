using DoLink.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Vagas
{
    public class AlterarDataValidacaoCommand : Notifiable, ICommand
    {
        public DateTime DataVencimento { get; set; }
        public string Id { get; set; }

        public AlterarDataValidacaoCommand(DateTime dataVencimento)
        {
            DataVencimento = dataVencimento;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
              .Requires()
              .IsNotNull(DataVencimento, "Data Vencimento", "A data vencimento deve ser informada")
              );
        }
    }
}
