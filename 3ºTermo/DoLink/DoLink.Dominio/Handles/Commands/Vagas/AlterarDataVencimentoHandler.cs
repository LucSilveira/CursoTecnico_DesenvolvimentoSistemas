using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Vagas;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Vagas
{
    public class AlterarDataVencimentoHandler : Notifiable, IHandler<AlterarDataValidacaoCommand>
    {
        public readonly IVagaRepository _vagaRepository;

        public AlterarDataVencimentoHandler(IVagaRepository vagaRepository)
        {
            _vagaRepository = vagaRepository;
        }

        public ICommandResult Handler(AlterarDataValidacaoCommand command)
        {
            command.Validar();

            if(command.Invalid)
            {
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);
            }

            Vaga vaga = new Vaga();
            vaga = _vagaRepository.BuscarDadosVaga(command.Id).Result;

            if(vaga == null)
            {
                return new GenericCommandResult(false, "Vaga não encontrada", null);
            }
            vaga.AlterarDataVencimento(command.DataVencimento);
            _vagaRepository.AlterarVagaRepositorie(vaga.Id, vaga);


            return new GenericCommandResult(true, "Data de vencimento alterada com sucesso", vaga);
        }
    }
}
