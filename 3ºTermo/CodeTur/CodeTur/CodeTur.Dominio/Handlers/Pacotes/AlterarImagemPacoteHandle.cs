using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Utils;
using CodeTur.Dominio.Commands.Pacotes;
using CodeTur.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class AlterarImagemPacoteHandle : IHandlerCommand<AlterarImagemPacoteCommand>
    {
        // Injetando o nosso repositório de pacote
        private readonly IPacoteRepository _repository;

        // Definindo que a classe 'AlterarImagemPacoteHandle' necessita do 'IPacoteRepository' para existir
        public AlterarImagemPacoteHandle(IPacoteRepository _pacoteRepository)
        {
            _repository = _pacoteRepository;
        }

        /// <summary>
        /// Método para validar os processos para alterar um pacote
        /// </summary>
        /// <param name="_command">Comando de alteração do pacote</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public ICommandResult Handle(AlterarImagemPacoteCommand _command)
        {
            //1º Verificando se a requisição não está inserindo um arquivo
            if (_command.Arquivo != null)
            {
                //Caso um arquivo esteja sendo anexado, enviamos para o método de 'UploadFile'
                var _imagemArquivo = UploadFile.Local(_command.Arquivo, "Pacotes");

                //Atribuindo o caminho de exibição da imagem para o objeto
                _command.Imagem = _imagemArquivo;
            }

            //2º - Validando se o command recebido é válido
            _command.Validar();

                //Caso seja inválido, recebemos quando são os valores incorretos identificados por ele
                if (_command.Invalid)
                {
                    return new GenericCommandResult(false, "Informe os dados corretamente", _command.Notifications);
                }

            //3º - Verificando se o pacote existe no sistema
            var _pacoteExistente = _repository.BuscarPacotePorId(_command.IdPacote);

                if (_pacoteExistente == null)
                {
                    return new GenericCommandResult(false, "Pacote não encontrado, verifique o código do pacote", _command.Notifications);
                }

            //4º Verificando se o usuário informou uma nova imagem
            if(_command.Imagem == _pacoteExistente.Imagem)
            {
                return new GenericCommandResult(false, "A imagem não pode ser a mesma, informe uma nova imagem", _command.Imagem);
            }

            //5º - Atribuir ao objeto pacote a alteração dos dados do mesmo
            _pacoteExistente.AlterarImagemPacote(_command.Imagem);

            //6º - Verificando se as alterações não contém erros para salvarmos
            if (_pacoteExistente.Invalid)
            {
                return new GenericCommandResult(false, "Dados inválidos", _pacoteExistente.Notifications);
            }

            //7º - Salvando as alterações no banco de dados
            _repository.AlterarPacote(_pacoteExistente);

            //Caso sucesso
            return new GenericCommandResult(true, "Imagem alterada com sucesso", _pacoteExistente);
        }
    }
}
