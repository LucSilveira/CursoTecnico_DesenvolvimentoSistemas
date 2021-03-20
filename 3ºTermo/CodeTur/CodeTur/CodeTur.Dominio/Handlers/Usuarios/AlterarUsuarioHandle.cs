using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Commands.Usuarios;
using CodeTur.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class AlterarUsuarioHandle : Notifiable, IHandlerCommand<AlterarUsuarioCommand>
    {
        // Injetando o nosso repositório de usuário
        private readonly IUsuarioRepository _repository;

        // Definindo que a classe 'AlterarUsuarioHandle' necessita do 'IUsuarioRepository' para existir
        public AlterarUsuarioHandle(IUsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }

        /// <summary>
        /// Método para validar os processos para alterar um usuário
        /// </summary>
        /// <param name="_command">Comando de alteração do usuário</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public ICommandResult Handle(AlterarUsuarioCommand _command)
        {
            //1º - Validando se o command recebido é válido
            _command.Validar();

                //Caso seja inválido, recebemos quando são os valores incorretos identificados por ele
                if (_command.Invalid)
                {
                    return new GenericCommandResult(false, "Informe os dados corretamente", _command.Notifications);
                }

            //2º - Verificando se o email de usuário pertence a nossa base de dados
            var _emailUsuarioExistente = _repository.BuscarUsuarioPorEmail(_command.Email);

                //Caso o email não exista, informe ao usuário que o usuário informado não existe
                if (_emailUsuarioExistente == null)
                {
                    return new GenericCommandResult(false, "Conta de email não encontrada, informe um e-mail cadastrado", _command.Notifications);
                }

            //3º - Verificando se o novo email não está repetido com os armazenados na base de dados
            if(_command.Email != _emailUsuarioExistente.Email)
            {
                //Buscando o email no banco de dados
                var _novoEmailExistente = _repository.BuscarUsuarioPorEmail(_command.Email);

                //Verificando se há usuários utilizando o novo email informado
                if(_novoEmailExistente != null)
                {
                    return new GenericCommandResult(false, "Este e-mail já está vinculado a uma conta, informe outro email", _command.Notifications);
                }
            }

            //4º - Atribuir ao objeto usuário a alteração dos dados do mesmo
            _emailUsuarioExistente.AlterarUsuario(_command.Nome, _command.Email);

            //5º - Verificar se um novo número de telefone foi adicionado
            if (!string.IsNullOrEmpty(_command.Telefone))
            {
                //Caso um novo número de telefone seja informado, alteramos a informação
                _emailUsuarioExistente.AdicionarTelefone(_command.Telefone);
            }

            //6º - Verificando se as alterações não contém erros para salvarmos
            if (_emailUsuarioExistente.Invalid)
            {
                return new GenericCommandResult(false, "Dados inválidos", _command.Notifications);
            }

            //7º - Salvando as informações na base de dados
            _repository.AlterarUsuario(_emailUsuarioExistente);

            //Caso esteja tudo certo, alteramos o usuário com os novos dados
            return new GenericCommandResult(true, "Dados alterados com sucesso", _emailUsuarioExistente);
        }
    }
}
