using Carometro.Comum.Queries;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Queries.Admins
{
    public class ListarAdminQuery : Notifiable, IQuery
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }

    public class ListaAdminResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
