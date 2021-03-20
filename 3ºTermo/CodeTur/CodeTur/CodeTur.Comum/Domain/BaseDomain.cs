using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Domain
{
    //Base de referência para nossas Entidades (Domains), disponiblizando atributos padrões
    //para todas as entidades que a herdarem;
    public abstract class BaseDomain : Notifiable
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }

    }
}
