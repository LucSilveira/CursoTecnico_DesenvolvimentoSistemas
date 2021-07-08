using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Utils;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Empresa;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoLink.Dominio.Handles.Commands
{
    public class CadastrarEmpresaHandler : Notifiable, IHandler<CadastrarEmpresaCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IEmpresaRepository _empresaRepository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public CadastrarEmpresaHandler(IEmpresaRepository _repository)
        {
            _empresaRepository = _repository;
        }

        public ICommandResult Handler(CadastrarEmpresaCommand command)
        {
            //Verifica se o comando recebido é válido.
            command.Validar();

            //Verifica se os dados são válidos.
            if (!command.Valid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            command.Senha = SenhaUtils.CriptografarSenha(command.Senha);

            //string nome, string email, string senha, string telefone, string cNPJ, string cEP, string regiao, string descricao, string dominio
            Empresa _empresa = new Empresa(command.Nome, command.Email, command.Senha, command.Telefone);
            
            //Verificando se no banco de dados o email informado já está em uso
            var empresaExiste = _empresaRepository.BuscarPorEmail(command.Email).Result;

            if (empresaExiste != null)
                return new GenericCommandResult(false, "Email já está em uso", command.Notifications);
            var a = _empresa.Nome.ToString() + " "
                    + _empresa.Email.ToString() + " "
                    + _empresa.Nome.ToString() + " ";

            //Validação na moderação de conteudo
            var resultado = new ContentModerator().Moderar(a.ToLower());
            //ModeradorTermos
            //var resultadotermos = new ContentModerator().ModeradorTermos(a.ToLower());
            
            //if(resultadotermos != null)
            //{
            //    var palavraInadequadas = resultado + " "+ resultadotermos;
            //}

            if (resultado != null)
            {
                var palavras = resultado.Select(
                    r =>
                    {
                        return new
                        {
                            palavra = r.Term
                        };
                    }
                    ).ToArray();
                return new GenericCommandResult(false, "palavras inadequadas", palavras);
            }

            if (_empresa.Valid)
                _empresaRepository.CadastrarEmpresa(_empresa);

            _ = SendEmail.EnviarEmail(_empresa.Email, _empresa.Nome,
                                           "Criação de conta na plataforma", "Seu cadastro foi realizado",
                                           "Seu cadastro foi realizado com sucesso", "Olá, é um grande prazer receber você na nossa plataforma DoLink, para acessar nossa plataforma basta inserir seu email de contato para os parametros de email e senha"
                                         );

            return new GenericCommandResult(true, "Empresa cadastrada com sucesso", _empresa);
        }
    }
}
