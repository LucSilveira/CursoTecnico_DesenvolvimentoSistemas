using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Utils;
using Carometro.Dominio.Commands.Aluno;
using Carometro.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.Alunos
{
    public class AlterarAlunoHandler : Notifiable, IHandler<AlterarAlunoCommand>
    {

        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlterarAlunoHandler(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public ICommandResult Handler(AlterarAlunoCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos", command.Notifications);

            var aluno = _alunoRepositorio.BuscarPorId(command.Id);

            if (aluno == null)
                return new GenericCommandResult(false, "Aluno Não Encontrado", command.Notifications);

            if(command.Email != aluno.Email)
            {
                var emailNovoExistente = _alunoRepositorio.BuscarPorEmail(command.Email);

                if(emailNovoExistente != null)
                    return new GenericCommandResult(false, "Este e-mail já está vinculado a uma conta, informe outro email", command.Notifications);
            }

            aluno.AlterarAluno(command.Nome, command.Telefone, command.Email, command.Rg, command.Cpf, command.DataNascimento, command.FotoAluno);

            if (aluno.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", aluno.Notifications);

            _alunoRepositorio.Alterar(aluno);

            return new GenericCommandResult(true, "Aluno Alterado!", aluno);
        }
    }
}
