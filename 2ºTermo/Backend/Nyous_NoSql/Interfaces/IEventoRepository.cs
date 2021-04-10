using Nyous_NoSql.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyous_NoSql.Interfaces
{
    public interface IEventoRepository
    {
        List<EventoDomain> ListarEventos();
        EventoDomain BuscarPorId(string id);
        void AdicionarEvento(EventoDomain evento);
        void AtualizarEvento(string id, EventoDomain evento);
        void RemoverEvento(string id);
    }
}
