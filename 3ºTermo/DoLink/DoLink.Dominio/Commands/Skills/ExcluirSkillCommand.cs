using DoLink.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Skill
{
    public class ExcluirSkillCommand : Notifiable, ICommand
    {
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id da skill", "Id da skill inválida") 
            );
        }

        public string Id { get; set; }
    }
}
