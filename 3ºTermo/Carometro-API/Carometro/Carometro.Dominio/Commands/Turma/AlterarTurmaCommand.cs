using Carometro.Comum.Commands;
using Carometro.Comum.Enum;
using Carometro.Dominio.Commands.Horario;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.Turma
{
    public class AlterarTurmaCommand : Notifiable, ICommand
    {
        public AlterarTurmaCommand(string titulo, string descricao, EnSemestre semestre, DateTime dataIniciacao, DateTime dataConclusao)
        {
            Titulo = titulo;
            Descricao = descricao;
            Semestre = semestre;
            DataIniciacao = dataIniciacao;
            DataConclusao = dataConclusao;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(Id, Guid.Empty, "Id de identificação", "O id do horário deve ser especificado")
               .HasMinLen(Titulo, 10, "Titulo", "O Titulo da Turma deve conter no mínimo 10 caractéres")
               .HasMaxLen(Descricao, 50, "Descricao", "A Descrição da Turma deve conter no máximo 50 caractéres")
               .IsNotNull(DataIniciacao, "Data Iniciação", "Informe uma data de iniciação do curso")
               .IsNotNull(DataConclusao, "Data Conclusão", "Informe uma data de conclusão do curso")
           );
        }

        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public EnSemestre Semestre { get; set; }
        public DateTime DataIniciacao { get; set; }
        public DateTime DataConclusao { get; set; }
        public ICollection<AlterarHorarioCommand> Horarios { get; set; }
    }
}
