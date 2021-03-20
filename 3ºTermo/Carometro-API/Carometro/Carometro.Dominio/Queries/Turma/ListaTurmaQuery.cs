using Carometro.Comum.Queries;
using Carometro.Dominio.Entidades;
using Carometro.Dominio.Queries.Horario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Queries.Turma
{
    public class ListaTurmaQuery : IQuery
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }

    public class ListarTurmaResult
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Semestre { get; set; }
        public IEnumerable<ListarHorarioResult> Horarios { get; set; }
    }
}
