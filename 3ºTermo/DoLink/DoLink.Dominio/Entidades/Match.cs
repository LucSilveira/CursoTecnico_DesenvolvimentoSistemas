using DoLink.Comum.Entidades;
using DoLink.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Entidades
{
    public class Match : Entidade
    {
        public Match()
        {
            Status = EnStatusMatch.Ativo;
        }

        public Match(string idVaga, string idProfissional, int nivelAcesso)
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(idVaga, Guid.Empty, "Id da vaga", "Id da vaga não específicada")
                .AreNotEquals(idProfissional, Guid.Empty, "Id do profissional", "Id do profissional não específicado")
            );

            if (Valid)
            {
                IdVaga = idVaga;
                IdProfissional = idProfissional;
                NivelAcesso = nivelAcesso;
            }
        }

        public void AlterarStatus(EnStatusMatch status)
        {
            if(status == EnStatusMatch.Ativo)
            {
                Status = EnStatusMatch.Desativado;
            }
            else
            {
                Status = EnStatusMatch.Ativo;
            }
        }

        public string IdVaga { get; set; }
        public string IdProfissional { get; set; }
        public EnStatusMatch Status { get; set; }
        public int NivelAcesso { get; set; }
    }
}
