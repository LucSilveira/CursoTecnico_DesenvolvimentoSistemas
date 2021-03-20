using Carometro.Comum.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Queries.Aluno
{
    public class BuscarAlunoQuery : Notifiable, IQuery
    {
        public BuscarAlunoQuery(Guid idAluno)
        {
            BuscarId = idAluno;
        }

        public BuscarAlunoQuery(string email)
        {
            BuscarRg = email;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                 .Requires()
                 .IsNotNullOrEmpty(BuscarRg, "Rg", "Informe o rg do aluno")
             );
        }

        public Guid BuscarId { get; set; }
        public string BuscarRg { get; set; }
    }

    public class BuscarAlunoResult
    {
        public Guid Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string FotoAluno { get; set; }
    }
}
