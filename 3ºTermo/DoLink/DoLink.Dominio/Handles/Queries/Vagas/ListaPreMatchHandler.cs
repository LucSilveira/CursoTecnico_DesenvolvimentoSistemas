using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Queries;
using DoLink.Dominio.Queries.Profissionais;
using DoLink.Dominio.Queries.Vagas;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoLink.Dominio.Handles.Queries.Vagas
{
    public class ListaPreMatchHandler : Notifiable, IHandlerQuery<ListaPreMatchQuery>
    {
        public readonly IVagaRepository _vagaRepository;

        public readonly IProfissionalRepository _profissionalRepository;

        public ListaPreMatchHandler(IVagaRepository _repository, IProfissionalRepository repository)
        {
            _vagaRepository = _repository;
            _profissionalRepository = repository;
        }

        public IQueryResult Handler(ListaPreMatchQuery command)
        {
            var profissional = _profissionalRepository.BuscarProfissionalEspecifico(command.IdProfissional).Result;

            var _query = _vagaRepository.Prematch(profissional).Result;

            if (_query == null)
            {
                return new GenericQueryResult(false, "Vagas não encontrada", null);
            }

            var vagas = _query.Select(vg =>
            {
                return new ListPreMatchResult
                {
                    Id = vg.Id,
                    Titulo = vg.Titulo,
                    Descricao = vg.Descricao,
                    FaixaSalarial = vg.FaixaSalarial,
                    DadosProfissional = new BuscarProfissionalResult
                    {
                        Id = profissional.Id,
                        Nome = profissional.Nome,
                        Email = profissional.Email
                    },
                    skill = vg.EspecificacaoSkill
                };
            });

            return new GenericQueryResult(true, "Vagas para pré-match", vagas);
        }
    }
}
