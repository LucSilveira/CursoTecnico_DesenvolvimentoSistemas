using DoLink.Comum.Entidades;
using DoLink.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Entidades
{
    public class Administrador : Usuario
    {

        public Administrador()
        {
            TipoPerfil = EnTipoPerfil.Administrador;
            Telefone = null;
        }
        
        public void AlterarSenha(string senha)
        {
            AddNotifications(new Contract()
               .Requires()
               .HasMinLen(senha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres!")
            );

            if (Valid)
            {
                Senha = senha;
            }
        }
    }
}
