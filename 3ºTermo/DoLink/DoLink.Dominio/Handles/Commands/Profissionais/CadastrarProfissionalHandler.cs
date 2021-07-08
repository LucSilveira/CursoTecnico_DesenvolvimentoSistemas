using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Utils;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Profissionais;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using Newtonsoft.Json;
using System.Linq;

namespace DoLink.Dominio.Handles.Commands.Profissionais
{
    public class CadastrarProfissionalHandler : Notifiable, IHandler<CadastrarProfissionalCommand>
    {

        //Instânciando os métodos contidos no repositório
        public readonly IProfissionalRepository _repository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public CadastrarProfissionalHandler(IProfissionalRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handler(CadastrarProfissionalCommand command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validar();


            //Caso os dados estejam inválidos retornamos o erro
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);
            }

            //Buscando no banco de dados se o profissional informado já não existe
            var profissionalExistente = _repository.BuscarEmailProfissional(command.Email).Result;

            //Caso o mesmo já exista informamos o erro
            if (profissionalExistente != null)
            {
                return new GenericCommandResult(false, "Email já está em uso", command.Notifications);
            }

            //Encriptografando senha informada
            command.Senha = SenhaUtils.CriptografarSenha(command.Senha);

            //Criando o objeto com os dados informados
            var profissional = new Profissional(command.Nome, command.Email, command.Senha, command.Telefone);

            var a = profissional.Nome.ToString() + " "
                    + profissional.Email.ToString() + " "
                    + profissional.Senha.ToString() + " "
                    + profissional.Telefone.ToString();
            
            var resultado = new ContentModerator().Moderar(a.ToLower());

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

            //Caso os dados estejam corretos, inserimos o novo profissional no banco de dados
            if (profissional.Valid)
            {
                _repository.CadastrarProfissional(profissional);
            }

            //Enviando email de confirmação de criação na plataforma
            _ = SendEmail.EnviarEmail(profissional.Email, profissional.Nome,
                                           "Criação de conta na plataforma", "Seu cadastro foi realizado",
                                           "Seu cadastro foi realizado com sucesso", "Olá, é um grande prazer receber você na nossa plataforma DoLink, para acessar nossa plataforma basta inserir seu email de contato para os parametros de email e senha"
                                         );

            //Retornando com sucesso os dados da nova skill cadastrada
            return new GenericCommandResult(true, "Profissional cadastrado com sucesso", profissional);
        }
    }
}
