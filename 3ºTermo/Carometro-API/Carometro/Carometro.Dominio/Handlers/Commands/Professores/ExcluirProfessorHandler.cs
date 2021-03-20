using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.Professor;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.Professores
{
    public class ExcluirProfessorHandler : IHandler<ExcluirProfessorCommand>
    {
        private readonly IProfessorRepositorio _professorRepositorio;

        public ExcluirProfessorHandler(IProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }

        public ICommandResult Handler(ExcluirProfessorCommand command)
        {
            command.Validar();

            //Caso seja inválido, recebemos quando são os valores incorretos identificados por ele
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Informe um id correto", command.Notifications);
            }

            var professorExiste = _professorRepositorio.BuscarProfessorPorId(command.Id);

            if (professorExiste == null)
                return new GenericCommandResult(false, "Professor não encontrado", null);

            _professorRepositorio.ExcluirProfessor(professorExiste);

            return new GenericCommandResult(true, "Professor excluído com sucesso", professorExiste);
        }
    }
}
