using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Empresa;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands
{
    public class ExcluirEmpresaHandler : Notifiable, IHandler<ExcluirEmpresaCommand>
    {
        public readonly IEmpresaRepository _repositorie;

        public readonly IVagaRepository _vagaRepository;

        public readonly IMatchRepository _matchRepository;

        public ExcluirEmpresaHandler(IEmpresaRepository repositorie, IVagaRepository vaga, IMatchRepository match)
        {
            _repositorie = repositorie;
            _vagaRepository = vaga;
            _matchRepository = match;
        }

        public ICommandResult Handler(ExcluirEmpresaCommand command)
        {
            command.Validar();

            if(command.Invalid)
            {
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);
            }

            var empresa = _repositorie.BuscarDadosEmpresa(command.Id).Result;

            if(empresa == null)
            {
                return new GenericCommandResult(false, "Nenhuma empresa foi encontrada", null);
            }

            var vagasEmpresa = _vagaRepository.ListarVagaEmpresa(empresa.Id).Result;

            foreach(Vaga vaga in vagasEmpresa)
            {
                var matchs = _matchRepository.ListaDeMatchsVaga(vaga.Id).Result;

                foreach(Match match in matchs)
                {
                    _matchRepository.ExcluirMatch(match);
                }

                _vagaRepository.ExcluirVaga(vaga);
            }

            _repositorie.ExcluirEmpresa(empresa);

            return new GenericCommandResult(true, "Empresa excluida com sucesso", empresa);
        }
    }
}
