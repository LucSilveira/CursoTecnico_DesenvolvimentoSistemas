using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Utils;
using Carometro.Dominio.Commands.Professor;
using Carometro.Dominio.Entidades;
using Carometro.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.Professores
{
    public class CadastrarProfessorHandler : Notifiable, IHandler<CadastrarProfessorCommand>
    {
        private readonly IProfessorRepositorio _professorRepositorio;

        public CadastrarProfessorHandler(IProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }

        public ICommandResult Handler(CadastrarProfessorCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            var professorExiste = _professorRepositorio.BuscarProfessorPorEmail(command.Email);

            if (professorExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado", null);

            command.Senha = Senha.CriptografarSenha(command.Senha);

            var professor = new Professor(command.Nome, command.Email, command.Email, command.Telefone, command.FotoProfessor);

            if (professor.Valid)
                _professorRepositorio.AdicionarProfessor(professor);

            _ = SendEmailGrid.EnviarEmail(professor.Email, professor.NomeUsuario, 
                                            "Criação de conta na plataforma carometro", "Seu cadastro foi realizado",
                                            "Seu cadastro foi realizado", "Olá, é um grande prazer receber você na nossa plataforma Carometro, para acessar nossa plataforma basta inserir seu email de contrato para os pametros de email e senha"
                                          );

            return new GenericCommandResult(true, "Professor cadastrado com sucesso", professor);
        }
    }
}
