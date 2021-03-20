using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Commands.Usuarios;
using CodeTur.Dominio.Domains;
using CodeTur.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class AdicionarTelefoneHandle : Notifiable, IHandlerCommand<AdicionarTelefoneCommand>
    {
        // Injetando o nosso repositório de usuário
        private readonly IUsuarioRepository _repository;

        // Definindo que a classe 'AdicionarTelefoneHandle' necessita do 'IUsuarioRepository' para existir
        public AdicionarTelefoneHandle(IUsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }

        /// <summary>
        /// Método para validar os processos para adicionar o telefone de usuário
        /// </summary>
        /// <param name="_command">Comando de autenticação do usuário</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public ICommandResult Handle(AdicionarTelefoneCommand _command)
        {
            //1º - Validando se o command recebido é válido
            _command.Validar();

                //Caso seja inválido, recebemos quando são os valores incorretos identificados por ele
                if (_command.Invalid)
                {
                    return new GenericCommandResult(false, "Informe os dados corretamente", _command.Notifications);
                }

            //2º - Validando se o usuário existe
            Usuario _usuarioExistente = _repository.BuscarUsuarioPorId(_command.IdUsuario);

                //Caso o usuário não exista, informamos a mensagem de erro
                if(_usuarioExistente == null)
                {
                    return new GenericCommandResult(false, "Usuário não encontrado", _command.Notifications);
                }

            //3º - Verificando se o usuário procurado não possui um telefone cadastrado
            if(_usuarioExistente.Telefone != null)
            {
                return new GenericCommandResult(false, "Usuário já possui um telefone cadastrado", _usuarioExistente);
            }

            //4º - Alterando usuário
            _usuarioExistente.AdicionarTelefone(_command.Telefone);

            //5º - Salvando as alterações no banco de dados
            _repository.AlterarUsuario(_usuarioExistente);

            //Caso não haja erro, adicionamos o telefone ao usuário
            return new GenericCommandResult(true, "Telefone adicionado com sucesso", _usuarioExistente);
        }
    }
}
