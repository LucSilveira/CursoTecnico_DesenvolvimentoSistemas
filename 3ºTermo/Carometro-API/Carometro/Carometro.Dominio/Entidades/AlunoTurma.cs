using Carometro.Comum.Entidades;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Entidades
{
    public class AlunoTurma : Entidade
    {
        public AlunoTurma(Guid idAluno, Guid idTurma, string anotacaoProfessor)
        {
            AddNotifications(new Contract()
                .Requires()
                //.HasMinLen(anotacaoProfessor, 10, "AnotacaoProfessor", "A Anotação do Professor deve conter no mínimo 10 caractéres")
                .AreNotEquals(idAluno, Guid.Empty, "Id Aluno", "Informe o ID do aluno vinculado")
                .AreNotEquals(idTurma, Guid.Empty, "Id Turma", "Informe o ID da turma vinculada")
            );

            if (Valid)
            {
                AnotacaoProfessor = anotacaoProfessor;
                IdAluno = idAluno;
                IdTurma = idTurma;
            }
        }

        public void AlterarAlunoTurma(Guid idAluno, Guid idTurma, string anotacaoProfessor)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(anotacaoProfessor, 10, "AnotacaoProfessor", "A Anotação do Professor deve conter no mínimo 10 caractéres")
                .AreNotEquals(idAluno, Guid.Empty, "Id Aluno", "Informe o ID do aluno vinculado")
                .AreNotEquals(idTurma, Guid.Empty, "Id Turma", "Informe o ID da turma vinculada")
            );

            if (Valid)
            {
                AnotacaoProfessor = anotacaoProfessor;
                IdAluno = idAluno;
                IdTurma = idTurma;
            }
        }

        public Guid IdAluno { get; set; }
        public virtual Aluno Aluno { get; private set; }

        public Guid IdTurma { get; set; }
        public virtual Turma Turma { get; private set; }

        public string AnotacaoProfessor { get; private set; }

    }
}
