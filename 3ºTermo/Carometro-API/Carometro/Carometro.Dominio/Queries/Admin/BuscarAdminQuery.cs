using Carometro.Comum.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Queries.Admins
{
    public class BuscarAdminQuery : Notifiable, IQuery
    {
        public BuscarAdminQuery(Guid id)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(Id, Guid.Empty, "IdUsuario", "Id do usuário inválido")
            );
        }

        public Guid Id { get; set; }
    }

    public class BuscarAdminResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
