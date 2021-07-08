using DoLink.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Profissionais
{
    public class AlterarSkillsProfissionalCommand : Notifiable, ICommand
    {
        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(Id, Guid.Empty, "Id do profissional", "Id do profissional inválido")
            );
        }

        public string Id { get; set; }
        public DoLink.Dominio.Entidades.Skill[] SkillsProfissional { get; set; }
    }
}
