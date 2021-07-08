using DoLink.Comum.Commands;
using DoLink.Comum.Enum;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Utils;
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
    public class AlterarStatusVagaHandler : Notifiable, IHandler<AlterarStatusVagaCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IVagaRepository _vagaRepossitorio;

        //Instânciando os métodos contidos no repositório
        public readonly IMatchRepository _matchRepositorio;

        //Instânciando os métodos contidos no repositório
        public readonly IProfissionalRepository _profissionalRepossitorio;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public AlterarStatusVagaHandler(IVagaRepository vagaRepossitorio, IMatchRepository match, IProfissionalRepository profissional)
        {
            _vagaRepossitorio = vagaRepossitorio;
            _matchRepositorio = match;
            _profissionalRepossitorio = profissional;
        }

        /// <summary>
        /// Método para alterar o status de uma vaga
        /// </summary>
        /// <param name="command">Status para alterar a vaga</param>
        /// <returns>Vaga com o status alterado</returns>
        public ICommandResult Handler(AlterarStatusVagaCommand command)
        {
            command.Validar();

            if (!command.Valid)
            {
                return new GenericCommandResult(false, "Dados Invalidos!", command.Notifications);
            }

            Vaga vaga = new Vaga();

            vaga = _vagaRepossitorio.BuscarDadosVaga(command.Id).Result;

            if(vaga == null)
            {
                return new GenericCommandResult(false, "Vaga não encontrada", null);
            }

            vaga.AlterarStatus(command.Status);

            if(vaga.Status == EnStatusVaga.Desativado)
            {
                var matchs = _matchRepositorio.ListaDeMatchsVaga(vaga.Id).Result;

                foreach(Match match in matchs)
                {
                    var profissional = _profissionalRepossitorio.BuscarProfissionalEspecifico(match.IdProfissional).Result;

                    _ = SendEmail.EnviarEmail(profissional.Email, profissional.Nome,
                                                   "Alteração de match", "Lamentamos informar que seu match foi excluido",
                                                   "Match cancelado", $"Olá, com muita tristeza informamos que o match na vaga {vaga.Titulo} foi cancelado devido a uma alteração da mesmo, ao que indica essa vaga não está mais disponível"
                                                 );

                    _matchRepositorio.ExcluirMatch(match);
                }
            }

            _vagaRepossitorio.AlterarVagaRepositorie(vaga.Id, vaga);

            return new GenericCommandResult(true, "Status da vaga alterado com sucesso", vaga);
        }
    }
}
