using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Queries;
using DoLink.Dominio.Queries.Empresa;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoLink.Dominio.Handles.Queries.Empresas
{
    public class ListarEmpresaHandler : Notifiable, IHandlerQuery<ListarEmpresaQuery>
    {
        public readonly IEmpresaRepository _repository;

        public ListarEmpresaHandler(IEmpresaRepository repository)
        {
            _repository = repository;
        }
        public IQueryResult Handler(ListarEmpresaQuery command)
        {
            var _query = _repository.ListarEmpresa().Result;

            if (_query == null)
                return new GenericQueryResult(false, "Nenhuma empresa encotrada", null);

            var empresas = _query.Select(x =>
            {
                return new ListarEmpresaResult()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Email = x.Email,
                    Senha = x.Senha,
                    Telefone = x.Telefone,
                    CNPJ = x.CNPJ,
                    CEP = x.CEP,
                    Regiao = x.Regiao,
                    Descricao = x.Descricao,
                    Dominio = x.Dominio,
                    Imagem = x.Imagem
                };
            });

            return new GenericQueryResult(true, "Empresas encontradas", empresas);
        }
    }
}
    