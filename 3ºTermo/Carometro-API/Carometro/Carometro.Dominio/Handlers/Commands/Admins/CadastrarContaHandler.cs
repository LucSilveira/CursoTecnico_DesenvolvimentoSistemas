using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Utils;
using Carometro.Dominio.Commands.Admin;
using Carometro.Dominio.Entidades;
using Carometro.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Commands.Admins
{
    public class CadastrarContaHandler : Notifiable, IHandler<CadastrarContaCommand>
    {

        private readonly IAdminRepositorio _adminRepositorio;
        public CadastrarContaHandler(IAdminRepositorio adminRepositorio)
        {
            _adminRepositorio = adminRepositorio;
        }

        public ICommandResult Handler(CadastrarContaCommand command)
        {
            //Verifica se o comando recebido é válido.
            command.Validar();

            //Verifica se os dados são válidos.
            if (command.Invalid)
                return new GenericCommandResult(false, "Dados Inválidos", command.Notifications);

            //Variável de apoio para validação de email.
            var usuarioExiste = _adminRepositorio.BuscarPorEmail(command.Email);

            //Verifica se o email do usuário já foi cadastrado no banco.
            if (usuarioExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado", null);

            command.Senha = Senha.CriptografarSenha(command.Senha);

            //Salvar no banco
            var admin = new Admin(command.Nome, command.Email, command.Senha, command.Telefone);

            if (admin.Valid)
                _adminRepositorio.Cadastrar(admin);

            _ = SendEmailGrid.EnviarEmail(admin.Email, admin.NomeUsuario,
                                           "Criação de conta na plataforma carometro", "Seu cadastro foi realizado",
                                           "Seu cadastro foi realizado", "Olá, é um grande prazer receber você na nossa plataforma Carometro, para acessar nossa plataforma basta inserir seu email de contrato para os pametros de email e senha"
                                         );

            return new GenericCommandResult(true, "Usuário criado com sucesso!", admin);
        }
    }
}
