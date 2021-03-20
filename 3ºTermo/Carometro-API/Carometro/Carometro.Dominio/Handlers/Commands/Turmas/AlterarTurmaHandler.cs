using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.Turma;
using Carometro.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.Turmas
{
    public class AlterarTurmaHandler : Notifiable, IHandler<AlterarTurmaCommand>
    {
        private readonly ITurmaRepositorio _repositorio;

        private readonly IHorarioRepositorio _repositorioHorario;

        public AlterarTurmaHandler(ITurmaRepositorio repositorioTurma, IHorarioRepositorio repositorioHorario)
        {
            _repositorio = repositorioTurma;
            _repositorioHorario = repositorioHorario;
        }


        public ICommandResult Handler(AlterarTurmaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            var turmaExistente = _repositorio.BuscarTurmaPorId(command.Id);

            if (turmaExistente == null)
                return new GenericCommandResult(false, "Turma não encontrada", null);

            turmaExistente.AlterarTurma(command.Titulo, command.Descricao, command.DataIniciacao, command.DataConclusao);

            if (turmaExistente.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", turmaExistente.Notifications);

            _repositorio.AlterarTurma(turmaExistente);

            foreach (var horario in command.Horarios)
            {
                var horarioExistente = _repositorioHorario.BuscarHorariPorId(horario.Id);

                if (horarioExistente == null)
                    return new GenericCommandResult(false, "Horário da turma não encontrado", null);

                horarioExistente.AlterarHorario(turmaExistente.Id, horario.DiaSemana, horario.HoraInicio, horario.HoraTermino);

                if (horarioExistente.Invalid)
                    return new GenericCommandResult(false, "Dados do horário inválido", horarioExistente.Notifications);

                _repositorioHorario.AlterarHorario(horarioExistente);
            }

            return new GenericCommandResult(true, "Dados altearados com sucesso", turmaExistente);
        }
    }
}
