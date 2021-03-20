using Carometro.Comum.Commands;
using Carometro.Comum.Utils;
using Carometro.Dominio.Commands.Aluno;
using Carometro.Dominio.Entidades;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.Alunos
{
    public class CadastrarAlunoHandler
    {

        private readonly IAlunoRepositorio _alunoRepositorio;

        public CadastrarAlunoHandler(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }


        public ICommandResult Handler(CadastrarAlunoCommand command)
        {

            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            var alunoExiste = _alunoRepositorio.BuscarPorEmail(command.Email);

            if (alunoExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado", null);

            command.Senha = Senha.CriptografarSenha(command.Senha);

            var aluno = new Aluno(command.Nome, command.Telefone, command.Email, command.Rg, command.Rg, command.Cpf, command.DataNascimento, command.FotoAluno);

            if (aluno.Valid)
                _alunoRepositorio.Cadastrar(aluno);

            _ = SendEmailGrid.EnviarEmail(aluno.Email, aluno.NomeUsuario,
                                            "Criação de conta na plataforma carometro", "Seu cadastro foi realizado",
                                            "Seu cadastro foi realizado", "Olá, é um grande prazer receber você na nossa plataforma Carometro, para acessar nossa plataforma basta inserir seu email de contrato para os pametros de email e senha"
                                          );

            return new GenericCommandResult(true, "Usuário criado com sucesso!", aluno);

        }

    }
}
