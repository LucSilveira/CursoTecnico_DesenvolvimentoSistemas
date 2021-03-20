using Carometro.Comum.Enum;
using Carometro.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Queries.Aluno
{
    public class ListarAlunoQuery : IQuery
    {
        public bool? Ativo { get; set; }
        public void Validate()
        {}

        public class ListarQueryResult
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
}
