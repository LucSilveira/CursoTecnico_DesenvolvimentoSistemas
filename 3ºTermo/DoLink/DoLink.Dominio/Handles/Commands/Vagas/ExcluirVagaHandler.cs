using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Utils;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Vaga;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Vagas
{
    public class ExcluirVagaHandler : Notifiable, IHandler<ExcluirVagaCommand>
    {
        public readonly IVagaRepository _vagaRepository;

        public readonly IMatchRepository _matchRepository;

        public readonly IProfissionalRepository _profissionalRepossitorio;

        public ExcluirVagaHandler(IVagaRepository _repository, IMatchRepository match, IProfissionalRepository profissional)
        {
            _vagaRepository = _repository;
            _matchRepository = match;
            _profissionalRepossitorio = profissional;
        }

        public ICommandResult Handler(ExcluirVagaCommand command)
        {
            command.Validar();

            if(!command.Valid)
            {
                return new GenericCommandResult(false, "Dados Inválidos", command.Notifications); 
            }

            var vaga = _vagaRepository.BuscarDadosVaga(command.Id).Result;

            if(vaga == null)
            {
                return new GenericCommandResult(false, "Nenhuma vaga encontrada", null);
            }

            var matchs = _matchRepository.ListaDeMatchsVaga(vaga.Id).Result;

            foreach(Match match in matchs)
            {
                var profissional = _profissionalRepossitorio.BuscarProfissionalEspecifico(match.IdProfissional).Result;

                _ = SendEmail.EnviarEmail(profissional.Email, profissional.Nome,
                                               "Alteração de match", "Lamentamos informar que seu match foi excluido",
                                               "Match cancelado", $"Olá, com muita tristeza informamos que o match na vaga {vaga.Titulo} foi cancelado devido a uma alteração da mesmo, ao que indica essa vaga não está mais disponível"
                                             );

                _matchRepository.ExcluirMatch(match);
            }

            _vagaRepository.ExcluirVaga(vaga);

            return new GenericCommandResult(true, "Vaga excluída com sucesso", vaga);
        }
    }
}
