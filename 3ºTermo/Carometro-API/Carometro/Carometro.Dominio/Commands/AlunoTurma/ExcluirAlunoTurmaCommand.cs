using Carometro.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.AlunoTurma
{
    public class ExcluirAlunoTurmaCommand : Notifiable, ICommand
    {
        public ExcluirAlunoTurmaCommand(Guid id)
        {
            Id = id;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id do aluno turma", "Informe o ID do aluno turma vinculado")
            );
        }

        public Guid Id { get; set; }
    }
}
