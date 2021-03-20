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
    public class CadastrarTurmaCommand : Notifiable, ICommand
    {
        public CadastrarTurmaCommand(string descricao, EnSemestre semestre, DateTime dataIniciacao, DateTime dataConclusao, ICollection<CadastrarHorarioCommand> horarios)
        {
            Descricao = descricao;
            Semestre = semestre;
            DataIniciacao = dataIniciacao;
            DataConclusao = dataConclusao;
            Horarios = horarios;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .HasMinLen(Titulo, 10, "Titulo", "O Titulo da Turma deve conter no mínimo 10 caractéres")
               .HasMaxLen(Descricao, 50, "Descricao", "A Descrição da Turma deve conter no máximo 50 caractéres")
               .IsNotNull(DataIniciacao, "Data Iniciação", "Informe uma data de iniciação do curso")
               .IsNotNull(DataConclusao, "Data Conclusão", "Informe uma data de conclusão do curso")
           );
        }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public EnSemestre Semestre { get; set; }
        public DateTime DataIniciacao { get; set; }
        public DateTime DataConclusao { get; set; }
        public ICollection<CadastrarHorarioCommand> Horarios { get; set; }
    }
}
