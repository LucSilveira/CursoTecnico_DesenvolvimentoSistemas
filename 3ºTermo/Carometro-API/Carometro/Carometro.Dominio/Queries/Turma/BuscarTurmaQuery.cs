using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Horario;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Queries.Turma
{
    public class BuscarTurmaQuery : Notifiable, IQuery
    {
        public BuscarTurmaQuery(Guid idTurma)
        {
            IdTurma = idTurma;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                 .Requires()
                 .AreNotEquals(IdTurma, Guid.Empty, "Id Turma", "Informe o ID da turma procurada")
             );
        }

        public Guid IdTurma { get; set; }
    }

    public class BuscarTurmaResult
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Semestre { get; set; }
        public DateTime DataIniciacao { get; set; }
        public DateTime DataConclusao { get; set; }
        public IEnumerable<ListarHorarioResult> Horarios { get; set; }
    }
}
