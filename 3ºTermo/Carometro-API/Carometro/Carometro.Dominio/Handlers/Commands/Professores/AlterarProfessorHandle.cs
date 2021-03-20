using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.Professor;
using Carometro.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.Professores
{
    public class AlterarProfessorHandle : Notifiable, IHandler<AlterarProfessorCommand>
    {
        private readonly IProfessorRepositorio _professorRepositorio;

        public AlterarProfessorHandle(IProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }

        public ICommandResult Handler(AlterarProfessorCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            var professorExiste = _professorRepositorio.BuscarProfessorPorId(command.Id);

            if (professorExiste == null)
                return new GenericCommandResult(false, "Professor não encontrado", null);

            if(command.Email != professorExiste.Email)
            {
                var novoEmailExistente = _professorRepositorio.BuscarProfessorPorEmail(command.Email);

                if(novoEmailExistente != null)
                    return new GenericCommandResult(false, "Este e-mail já está vinculado a uma conta, informe outro email", command.Notifications);
            }

            professorExiste.AlterarProfessor(command.Nome, command.Email, command.Telefone, command.FotoProfessor);

            if (professorExiste.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", professorExiste.Notifications);

            _professorRepositorio.AlterarProfessor(professorExiste);

            return new GenericCommandResult(true, "Dados alterador com sucesso", professorExiste);
        }
    }
}
