using DoLink.Comum.Enum;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Queries;
using DoLink.Dominio.Queries.Vagas;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoLink.Dominio.Handles.Queries.Vagas
{
    public class ListarVagaStatusHandler : Notifiable, IHandlerQuery<ListaVagaStatusQuery>
    {
        public readonly IVagaRepository _vagaRepository;

        public ListarVagaStatusHandler(IVagaRepository _repository)
        {
            _vagaRepository = _repository;
        }

        public IQueryResult Handler(ListaVagaStatusQuery command)
        {
            var _query = _vagaRepository.ListarVagaPorStatus(EnStatusVaga.Padrao).Result;

            if (_query == null)
                return new GenericQueryResult(false, "Nehuma vaga encontrada", null);

            var vagas = _query.Select(x =>
            {
                return new ListarVagaResult()
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Descricao = x.Descricao,
                    Local = x.Local,
                    FaixaSalarial = x.FaixaSalarial.ToString(),
                    Beneficios = x.Beneficios,
                    DataVencimento = x.DataVencimento
                };
            });

            return new GenericQueryResult(true, "Vagas encontradas", vagas);
        }
    }
}
