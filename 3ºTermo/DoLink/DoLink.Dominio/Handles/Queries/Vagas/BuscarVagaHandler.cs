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
    public class BuscarVagaHandler : Notifiable, IHandlerQuery<BuscarVagaQuery>
    {
        public readonly IVagaRepository _vagaRepository;

        public BuscarVagaHandler(IVagaRepository _repository)
        {
            _vagaRepository = _repository;
        }

        public IQueryResult Handler(BuscarVagaQuery command)
        {
            command.Validate();

            var vagaExistente = _vagaRepository.BuscarPorTitulo(command.Titulo).Result;

            if (vagaExistente == null)
            {
                return new GenericQueryResult(false, "Vaga não encontrada", null);
            }

            var vagaTituloResult = vagaExistente.Select(vg =>
            {
                return new BuscarVagaResult
                {
                    Id = vg.Id,
                    Titulo = vg.Titulo,
                    Descricao = vg.Descricao,
                    Status = vg.Status.ToString(),
                    FaixaSalarial = vg.FaixaSalarial.ToString(),
                    Beneficios = vg.Beneficios,
                    Local = vg.Local,
                    DataVencimento = vg.DataVencimento
                };
            });

            return new GenericQueryResult(true, "Vagas encontradas", vagaTituloResult);
        }
    }
}
