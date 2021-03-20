using Carometro.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Queries.Professor
{
    public class ListarProfessorQuery : IQuery
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }

    public class ListarProfessorResult
    {
        public Guid Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string FotoProfessor { get; set; }
    }
}
