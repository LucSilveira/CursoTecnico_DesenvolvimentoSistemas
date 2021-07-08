using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Utils;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Profissionais;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Profissionais
{
    public class AlterarProfissionalHandler : Notifiable, IHandler<AlterarProfissionalCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IProfissionalRepository _repository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public AlterarProfissionalHandler(IProfissionalRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método para alterar os dados de um profissional cadastrado
        /// </summary>
        /// <param name="command">Todos os dados que serão alterados dentro do profissional</param>
        /// <returns>Profissional com os dados alterados</returns>
        public ICommandResult Handler(AlterarProfissionalCommand command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validar();

            //Caso os dados esteja com erro, retornamos uma notificação
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);
            }

            //Procurando o profissional informado no banco de dados
            var profissionalExistente = _repository.BuscarProfissionalEspecifico(command.Id).Result;

            //Caso a mesmo não exista, retornamos o erro    
            if (profissionalExistente == null)
            {
                return new GenericCommandResult(false, "Conta não encontrada", command.Notifications);
            }

            //Verificando se o email informada não é diferente do cadastrado
            if (command.Email != profissionalExistente.Email)
            {
                //Caso seja, buscamos no banco de dados se o mesmo já não está em uso
                var emailProfissional = _repository.BuscarEmailProfissional(command.Email).Result;

                //Caso o novo email esteja em uso, retornamos o erro
                if (emailProfissional != null)
                {
                    return new GenericCommandResult(false, "Email já está em uso", null);
                }
            }

            //Criando o objeto com os dados informados
            profissionalExistente.AlterarProfissional(command.Nome, command.Email, command.Telefone, command.CPF, command.CEP, command.SobreMim, command.Linkedin, command.Repositorio, command.FaixaSalarial);

            var a = profissionalExistente.Nome.ToString() + " "
                    + profissionalExistente.Email.ToString() + " "
                    + profissionalExistente.SobreMim.ToString();

            //Validação na moderação de conteudo
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

            //Salvando no banco de dados as novas informações
            _repository.AlterarProfissional(profissionalExistente);

            //Retornando com sucesso o profissional alterado
            return new GenericCommandResult(true, "Profissional alterado com sucesso", profissionalExistente);
        }
    }
}