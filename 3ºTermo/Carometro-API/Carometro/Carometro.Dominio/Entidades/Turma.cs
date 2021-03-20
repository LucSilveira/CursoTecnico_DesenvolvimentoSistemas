using Carometro.Comum.Entidades;
using Carometro.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Entidades
{
    public class Turma : Entidade
    {
        public Turma(string titulo, string descricao, DateTime dataIniciacao, DateTime dataConclusao)
        {

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(titulo, 10, "Titulo", "O Titulo da Turma deve conter no mínimo 10 caractéres")
                .HasMaxLen(descricao, 50, "Descricao", "A Descrição da Turma deve conter no máximo 50 caractéres")
                .IsNotNull(dataIniciacao, "Data Iniciação", "Informe uma data de iniciação do curso")
                .IsNotNull(dataConclusao, "Data Conclusão", "Informe uma data de conclusão do curso")
            );

            if (Valid)
            {
                Titulo = titulo;
                Descricao = descricao;
                Semestre = EnSemestre.Primeiro;
                DataIniciacao = dataConclusao;
                DataConclusao = dataConclusao;
            }
        }

        public void AlterarTurma(string titulo, string descricao, DateTime dataIniciacao, DateTime dataConclusao)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(titulo, 10, "Titulo", "O Titulo da Turma deve conter no mínimo 10 caractéres")
                .HasMaxLen(descricao, 50, "Descricao", "A Descrição da Turma deve conter no máximo 50 caractéres")
                .IsNotNull(dataIniciacao, "Data Iniciação", "Informe uma data de iniciação do curso")
                .IsNotNull(dataConclusao, "Data Conclusão", "Informe uma data de conclusão do curso")
            );

            if (Valid)
            {
                Titulo = titulo;
                Descricao = descricao;
                Semestre = EnSemestre.Primeiro;
                DataIniciacao = dataConclusao;
                DataConclusao = dataConclusao;
            }
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public EnSemestre Semestre { get; private set; }
        public DateTime DataIniciacao { get; private set; }
        public DateTime DataConclusao { get; private set; }


        private readonly ICollection<Horario> _horarios;
        public IReadOnlyCollection<Horario> Horarios { get; set; }


        private readonly IList<AlunoTurma> _alunosTurmas;
        public IReadOnlyCollection<AlunoTurma> AlunoTurma { get; set; }


        private readonly IList<ProfessorTurma> _professoresTurmas;
        public IReadOnlyCollection<ProfessorTurma> ProfessorTurma { get; set; }
    }
}
