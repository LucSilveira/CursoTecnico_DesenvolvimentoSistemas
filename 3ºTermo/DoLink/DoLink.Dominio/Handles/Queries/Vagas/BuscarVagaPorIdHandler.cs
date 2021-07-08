using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Queries;
using DoLink.Dominio.Queries.Vagas;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Queries.Vagas
{
    public class BuscarVagaPorIdHandler : Notifiable, IHandlerQuery<BuscarVagaPorIdQuery>
    {
        public readonly IVagaRepository _vagaRepository;

        public BuscarVagaPorIdHandler(IVagaRepository _repository)
        {
            _vagaRepository = _repository;
        }

        public IQueryResult Handler(BuscarVagaPorIdQuery command)
        {
            command.Validate();

            var VagaExiste = _vagaRepository.BuscarDadosVaga(command.Id).Result;

            if (VagaExiste == null)
                return new GenericQueryResult(false, "Vaga não encontrada", null);

            var VagaResult = new BuscarVagaResult
            {
                Id = VagaExiste.Id,
                Titulo = VagaExiste.Titulo,
                Descricao = VagaExiste.Descricao,
                Status = VagaExiste.Status.ToString(),
                FaixaSalarial = VagaExiste.FaixaSalarial.ToString(),
                Beneficios = VagaExiste.Beneficios,
                Local = VagaExiste.Local,
                DataVencimento = VagaExiste.DataVencimento
            };

            return new GenericQueryResult(true, "Vagas encontradas", VagaResult);
        }
    }
}
