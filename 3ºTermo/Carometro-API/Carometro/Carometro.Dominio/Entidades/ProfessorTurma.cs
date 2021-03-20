using Carometro.Comum.Entidades;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Entidades
{
    public class ProfessorTurma : Entidade
    {
        public ProfessorTurma(Guid idTurma, Guid idProfessor)
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(idProfessor, Guid.Empty, "Id Professor", "Informe o ID do professor vinculado")
                .AreNotEquals(idTurma, Guid.Empty, "Id Turma", "Informe o ID da turma vinculada")
            );

            if (Valid)
            {
                IdTurma = idTurma;
                IdProfessor = idProfessor;
            }
        }

        public void AlterarrofessorTurma(Guid idTurma, Guid idProfessor)
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(idProfessor, Guid.Empty, "Id Professor", "Informe o ID do professor vinculado")
                .AreNotEquals(idTurma, Guid.Empty, "Id Turma", "Informe o ID da turma vinculada")
            );

            if (Valid)
            {
                IdTurma = idTurma;
                IdProfessor = idProfessor;
            }
        }

        public Guid IdTurma { get; set; }
        public virtual Professor Professor { get; private set; }

        public Guid IdProfessor { get; set; }
        public virtual Turma Turma { get; private set; }
    }
}
