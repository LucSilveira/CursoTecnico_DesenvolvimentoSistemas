using Carometro.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Queries.Horario
{
    public class ListarHorarioQuery : IQuery
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }

    public class ListarHorarioResult
    {
        public Guid Id { get; set; }
        public string DiaSemana { get; set; }
        public int HoraInicio { get; set; }
        public int HoraTermino { get; set; }
    }
}
