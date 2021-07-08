using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Utils;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Empresas;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Empresas
{
    public class AlterarDescricaoEmpresaHandler : Notifiable, IHandler<AlterarDescricaoEmpresaCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IEmpresaRepository _empresaRepository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public AlterarDescricaoEmpresaHandler(IEmpresaRepository _repository)
        {
            _empresaRepository = _repository;
        }

        public ICommandResult Handler(AlterarDescricaoEmpresaCommand command)
        {
            command.Validar();

            if (!command.Valid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            var empresa = _empresaRepository.BuscarDadosEmpresa(command.Id).Result;

            if (empresa == null)
                return new GenericCommandResult(false, "Empresa não encontrada", command.Notifications);

            empresa.AlterarDescricao(command.Descricao);

            //Validação na moderação de conteudo
            var resultado = new ContentModerator().Moderar(command.Descricao.ToString().ToLower());

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
