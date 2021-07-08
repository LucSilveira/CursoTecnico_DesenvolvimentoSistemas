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
using System.Threading.Tasks;

namespace DoLink.Dominio.Handles.Commands
{
    public class AlterarEmpresaHandler : Notifiable, IHandler<AlterarEmpresaCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IEmpresaRepository _empresaRepository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public AlterarEmpresaHandler(IEmpresaRepository _repository)
        {
            _empresaRepository = _repository;
        }

        public ICommandResult Handler(AlterarEmpresaCommand command)
        {
            //Verificando se a requisição não está inserindo um arquivo
            if (command.Arquivo != null)
            {
                //Caso um arquivo esteja sendo anexado, enviamos para o método de 'UploadFile'
                var _imagemArquivo = UploadFiles.Local(command.Arquivo, "Empresas");

                //Atribuindo o caminho de exibição da imagem para o objeto
                command.Imagem = _imagemArquivo;
            }

            command.Validar();

            if (!command.Valid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            Empresa empresa = new Empresa();

            empresa = _empresaRepository.BuscarDadosEmpresa(command.Id).Result;

            if (empresa == null)
                return new GenericCommandResult(false, "Empresa não encontrada", command.Notifications);

            
            empresa.AlterarEmpresa(command.Id, command.Nome, command.Email, command.Telefone, command.CNPJ, command.CEP, command.Regiao, command.Descricao, command.Dominio, command.Imagem);

            var a = empresa.Nome.ToString() + " "
                    + empresa.Email.ToString() + " "
                    + empresa.Regiao.ToString() + " "
                    + empresa.Descricao.ToString() + " "
                    + empresa.Dominio.ToString();

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

            _empresaRepository.AlterarEmpresaRepositorie(empresa.Id, empresa);

            return new GenericCommandResult(true, "Empresa alterada com sucesso", empresa);

        }

    }
}
