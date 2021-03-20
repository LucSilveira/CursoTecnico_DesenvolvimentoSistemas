using Carometro.Comum.Commands;
using Carometro.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.Horario
{
    public class CadastrarHorarioCommand : Notifiable, ICommand
    {
        public CadastrarHorarioCommand(EnDiaSemana diaSemana, int horaInicio, int horaTermino)
        {
            DiaSemana = diaSemana;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotNull(HoraInicio, "Hora de início", "A hora de iniciação do curso deve ser inserida")
               .IsNotNull(HoraTermino, "Hora de término", "A hora de término do curso deve ser inserida")
               .IsNotNull(DiaSemana, "Dia da semana", "O dia da semana deve ser inserido")
           );
        }

        public EnDiaSemana DiaSemana { get; set; }
        public int HoraInicio { get; set; }
        public int HoraTermino { get; set; }
    }
}
