using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Utils;
using CodeTur.Dominio.Commands.Pacotes;
using CodeTur.Dominio.Domains;
using CodeTur.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    /// <summary>
    /// Classe handle de criação de pacote para gerenciar o command de criar pacote
    /// </summary>
    public class CriarPacoteHandle : IHandlerCommand<CriarPacoteCommand>
    {
        // Injetando o nosso repositório de pacote
        private readonly IPacoteRepository _repository;

        // Definindo que a classe 'CriarPacoteHandle' necessita do 'IPacoteRepository' para existir
        public CriarPacoteHandle(IPacoteRepository _pacoteRepository)
        {
            _repository = _pacoteRepository;
        }

        /// <summary>
        /// Método para validar os processos para criar um pacote
        /// </summary>
        /// <param name="_command">Comando de criação do pacote</param>
        /// <returns>Dados salvos ou erros gerados</returns>
        public ICommandResult Handle(CriarPacoteCommand _command)
        { 
            //1º - Verificando se a requisição não está inserindo um arquivo
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

            //3º - Verificando se o titulo do pacote já não pertence a nossa base de dados
            var _pacoteExistente = _repository.BuscarPacotePorTitulo(_command.Titulo);

                //Caso o email exista, informe ao usuário que o email informado já está em uso
                if (_pacoteExistente != null)
                {
                    return new GenericCommandResult(false, "Titulo do pacote já cadastrado", _command.Notifications);
                }

            //4º - Criando uma nova instância do pacote com os dados informados
            var _pacote = new Pacote(_command.Titulo, _command.Descricao, _command.Imagem, _command.Ativo);

            //5º - Validando os dados inseridos do pacote
            if (_pacote.Invalid)
            {
                return new GenericCommandResult(false, "Dados inválidos", _pacote.Notifications);
            }

            //6º - Salvando pacote na nossa base de dados
            _repository.AdicionarPacote(_pacote);

            //Caso não haja nenhum erro, retornamos a mensagem de sucesso
            return new GenericCommandResult(true, "Pacote criado com sucesso", _pacote);
        }
    }
}
