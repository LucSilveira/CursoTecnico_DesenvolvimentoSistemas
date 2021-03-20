using Carometro.Comum.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Queries.Professor
{
    public class BuscarProfessorQuery : Notifiable, IQuery
    {
        public BuscarProfessorQuery(Guid idProfessor)
        {
            BuscarId = idProfessor;
        }

        public BuscarProfessorQuery(string email)
        {
            BuscarEmail = email;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                 .Requires()
                 .IsEmail(BuscarEmail, "Email", "O email informado está inválido")
             );
        }

        public Guid BuscarId { get; set; }
        public string BuscarEmail { get; set; }
    }

    public class BuscarProfessorResult
    {
        public Guid Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string FotoProfessor { get; set; }
    }
}
