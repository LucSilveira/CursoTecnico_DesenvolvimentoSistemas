using Carometro.Comum.Entidades;
using Carometro.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carometro.Dominio.Entidades
{
    public class Horario : Entidade
    {
        public Horario(Guid idTurma, EnDiaSemana diaSemana, int horaInicio, int horaTermino)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(horaInicio, "Hora de início", "A hora de iniciação do curso deve ser inserida")
                .IsNotNull(horaTermino, "Hora de término", "A hora de término do curso deve ser inserida")
                .IsNotNull(diaSemana, "Dia da semana", "O dia da semana deve ser inserido")
                .AreNotEquals(idTurma, Guid.Empty, "Id Turma", "Informe o ID da turma vinculada")
            );

            if (Valid)
            {
                IdTurma = idTurma;
                DiaSemana = diaSemana;
                HoraInicio = horaInicio;
                HoraTermino = horaTermino;
            }
        }

        public void AlterarHorario(Guid idTurma, EnDiaSemana diaSemana, int horaInicio, int horaTermino)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(horaInicio, "Hora de início", "A hora de iniciação do curso deve ser inserida")
                .IsNotNull(horaTermino, "Hora de término", "A hora de término do curso deve ser inserida")
                .IsNotNull(diaSemana, "Dia da semana", "O dia da semana deve ser inserido")
                .AreNotEquals(idTurma, Guid.Empty, "Id Turma", "Informe o ID da turma vinculada")
            );

            if (Valid)
            {
                IdTurma = idTurma;
                DiaSemana = diaSemana;
                HoraInicio = horaInicio;
                HoraTermino = horaTermino;
            }
        }

        public Guid IdTurma { get; private set; }
        public virtual Turma Turma { get; private set; }

        public EnDiaSemana DiaSemana { get; private set; }
        public int HoraInicio { get; private set; }
        public int HoraTermino { get; private set; }
    }
}
