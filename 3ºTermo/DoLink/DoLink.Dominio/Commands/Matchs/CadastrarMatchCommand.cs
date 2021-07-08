using DoLink.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Matchs
{
    public class CadastrarMatchCommand : Notifiable, ICommand
    {
        public CadastrarMatchCommand(string idVaga, string idProfissional)
        {
            IdVaga = idVaga;
            IdProfissional = idProfissional;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdVaga, Guid.Empty, "Id da vaga", "Id da vaga não específicada")
                .AreNotEquals(IdProfissional, Guid.Empty, "Id do profissional", "Id do profissional não específicado")
            );
        }

        public string IdVaga { get; set; }
        public string IdProfissional { get; set; }
    }
}
