using DoLink.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Empresas
{
    public class AlterarDescricaoEmpresaCommand : Notifiable, ICommand
    {
        public AlterarDescricaoEmpresaCommand(string id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id", "O Id deve ser válido")
                .HasMinLen(Descricao, 10, "Descrição", "A descrição deve ter no mínimo 10 caractéres")
                .HasMaxLen(Descricao, 300, "Descrição", "A descrição deve ter no máximo 300 caractéres")
            );
        }

        public string Id { get; set; }
        public string Descricao { get; set; }
    }
}
