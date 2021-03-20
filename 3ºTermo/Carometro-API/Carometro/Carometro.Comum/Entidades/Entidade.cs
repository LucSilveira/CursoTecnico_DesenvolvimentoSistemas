using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Comum.Entidades
{
    public abstract class Entidade : Notifiable
    {
        public Guid Id { get; set; }
    }
}
