using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Utils;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Vaga;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System.Linq;

namespace DoLink.Dominio.Handles.Commands.Vagas
{
    public class AlterarVagaHandler : Notifiable, IHandler<AlterarVagaCommand>
    {
        public readonly IVagaRepository _vagaRepossitorio;

        public AlterarVagaHandler(IVagaRepository _repositorio)
        {
            _vagaRepossitorio = _repositorio;
        }

        public ICommandResult Handler(AlterarVagaCommand command)
        {
            command.Validar();

            if (!command.Valid)
            {
                return new GenericCommandResult(false, "Dados Invalidos!", command.Notifications);
            }

            Vaga vaga = new Vaga();

            vaga = _vagaRepossitorio.BuscarDadosVaga(command.Id).Result;

            if (vaga == null)
            {
                return new GenericCommandResult(false, "Vaga não encontrada", null);
            }

            //string titulo, string descricao, int status, string local
            var vagaAlterada = vaga.AlterarVaga(command.Titulo, command.Descricao, command.Local, command.FaixaSalarial, command.Beneficios, command.DataVencimento);

            var a = vagaAlterada.Titulo.ToString() + " "
                + vagaAlterada.Descricao.ToString() + " "
                + vagaAlterada.Local.ToString() + " "
                + vagaAlterada.Beneficios.ToString();

            //Validação na moderação de conteudo
            var resultado = new ContentModerator().Moderar(a.ToLower());

            if (resultado != null)
            {
                var palavras = resultado.Select(
                    r =>
                    {
                        return new
                        {
                            palavra = r.Term
                        };
                    }
                    ).ToArray();
                return new GenericCommandResult(false, "palavras inadequadas", palavras);
            }

            _vagaRepossitorio.AlterarVagaRepositorie(vaga.Id, vaga);

            return new GenericCommandResult(true, "Vaga alterada com sucesso", vaga);
        }
    }
}
