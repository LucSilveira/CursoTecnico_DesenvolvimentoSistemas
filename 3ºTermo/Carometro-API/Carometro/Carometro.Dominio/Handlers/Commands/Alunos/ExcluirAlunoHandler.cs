using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.Aluno;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.Alunos
{
    public class ExcluirAlunoHandler : IHandler<ExcluirAlunoCommand>
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public ExcluirAlunoHandler(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public ICommandResult Handler(ExcluirAlunoCommand command)
        {
            command.Validar();

            //Caso seja inválido, recebemos quando são os valores incorretos identificados por ele
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Informe um id correto", command.Notifications);
            }

            var alunoExiste = _alunoRepositorio.BuscarPorId(command.Id);

            if (alunoExiste == null)
                return new GenericCommandResult(false, "Aluno não encontrado", null);

            _alunoRepositorio.Excluir(alunoExiste);

            return new GenericCommandResult(true, "Aluno excluído com sucesso", alunoExiste);
        }
    }
}
