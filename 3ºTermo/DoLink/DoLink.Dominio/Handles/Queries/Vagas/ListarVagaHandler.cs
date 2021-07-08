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
    public class ListarVagaHandler : Notifiable, IHandlerQuery<ListarVagaQuery>
    {
        public readonly IVagaRepository _vagaRepository;

        public ListarVagaHandler(IVagaRepository _repository)
        {
            _vagaRepository = _repository;
        }

        public IQueryResult Handler(ListarVagaQuery command)
        {
            var _query = _vagaRepository.ListarVaga();

            if (_query == null)
                return new GenericQueryResult(false, "Nehuma vaga encotrada", null);

            var vaga = _query.Result.Select(x =>
            {
                return new ListarVagaResult()
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Empresa = x.IdEmpresa,
                    Descricao = x.Descricao,
                    Status = x.Status.ToString(),
                    FaixaSalarial = x.FaixaSalarial.ToString(),
                    Beneficios = x.Beneficios,
                    Local = x.Local,
                    DataVencimento = x.DataVencimento
                };
            });

            return new GenericQueryResult(true, "Vagas encontradas", vaga);
        }
    }
}
