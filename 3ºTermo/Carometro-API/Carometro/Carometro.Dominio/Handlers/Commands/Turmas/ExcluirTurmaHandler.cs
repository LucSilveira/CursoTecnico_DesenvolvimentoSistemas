using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.Turma;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.Turmas
{
    public class ExcluirTurmaHandler : IHandler<ExcluirTurmaCommand>
    {
        private readonly ITurmaRepositorio _repositorio;

        public ExcluirTurmaHandler(ITurmaRepositorio repositorioTurma)
        {
            _repositorio = repositorioTurma;
        }

        public ICommandResult Handler(ExcluirTurmaCommand command)
        {
            command.Validar();

            //Caso seja inválido, recebemos quando são os valores incorretos identificados por ele
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Informe um id correto", command.Notifications);
            }

            var turmaProcurada = _repositorio.BuscarTurmaPorId(command.Id);

            if (turmaProcurada == null)
                return new GenericCommandResult(false, "Turma não encontrada", null);

            _repositorio.ExcluirTurma(turmaProcurada);

            return new GenericCommandResult(true, "Turma excluida com sucesso", turmaProcurada);
        }
    }
}
