using DoLink.Comum.Commands;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Profissionais
{
    public class AlterarCpfProfissionalCommand : Notifiable, ICommand
    {
        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(Id, Guid.Empty, "Id do profissional", "Id do profissional inválido")
               .IsCpf(CPF, "CPF", "Informe um CPF válido")
            );
        }

        public string Id { get; set; }
        public string CPF { get; set; }
    }
}
