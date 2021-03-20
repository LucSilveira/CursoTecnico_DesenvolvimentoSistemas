using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.Horario;
using Carometro.Dominio.Commands.Turma;
using Carometro.Dominio.Entidades;
using Carometro.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.Turmas
{
    public class CadastrarTurmaHandler : Notifiable, IHandler<CadastrarTurmaCommand>
    {
        private readonly ITurmaRepositorio _repositorio;

        private readonly IHorarioRepositorio _repositorioHorario;

        public CadastrarTurmaHandler(ITurmaRepositorio repositorioTurma, IHorarioRepositorio repositorioHorario)
        {
            _repositorio = repositorioTurma;
            _repositorioHorario = repositorioHorario;
        }

        public ICommandResult Handler(CadastrarTurmaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            var turma = new Turma(command.Titulo, command.Descricao, command.DataIniciacao, command.DataConclusao);

            if (turma.Valid)
                _repositorio.AdicionarTurma(turma);

            foreach (var horario in command.Horarios)
            {
                Horario horarios = new Horario(turma.Id, horario.DiaSemana, horario.HoraInicio, horario.HoraTermino);

                if (horarios.Valid)
                    _repositorioHorario.AdicionarHorario(horarios);
            }

            return new GenericCommandResult(true, "Turma cadastrada com sucesso", turma);
        }
    }
}
