using DoLink.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Skills
{
    public class AlterarSkillCommand : Notifiable, ICommand
    {
        public AlterarSkillCommand(string nome, string id)
        {
            Id = id;
            Nome = nome;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id da skill", "Id da skill inválida")
                .IsNotNullOrEmpty(Nome, "Nome", "Informe o nome da habilidade")
            );
        }

        public string Id { get; set; }
        public string Nome { get; set; }
    }
}
