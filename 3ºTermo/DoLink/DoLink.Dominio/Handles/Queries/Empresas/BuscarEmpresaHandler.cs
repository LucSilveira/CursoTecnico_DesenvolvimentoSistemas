using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Queries;
using DoLink.Dominio.Queries.Empresas;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Queries.Empresas
{
    public class BuscarEmpresaHandler : Notifiable, IHandlerQuery<BuscarEmpresaQuery>
    {
        public readonly IEmpresaRepository _empresaRepository;

        public BuscarEmpresaHandler (IEmpresaRepository _repositorio)
        {
            _empresaRepository = _repositorio;
        }

        public IQueryResult Handler(BuscarEmpresaQuery command)
        {
            command.Validate();

            if(command.Valid)
            {
                if(command.Invalid)
                {
                    return new GenericQueryResult(false, "Dados Inválidos!", command.Notifications);
                }

                var empresaCnpjExiste = _empresaRepository.BuscarEmpresaPorCpnj(command.Empresa).Result;

                if(empresaCnpjExiste == null)
                {
                    return new GenericQueryResult(false, "Nenhuma empresa foi encontrada", null);
                }

                var empresaEmailResult = new BuscarEmpersaResult
                {
                    Id = empresaCnpjExiste.Id,
                    Nome = empresaCnpjExiste.Nome,
                    Email = empresaCnpjExiste.Email,
                    Senha = empresaCnpjExiste.Senha,
                    Telefone = empresaCnpjExiste.Telefone,
                    CNPJ = empresaCnpjExiste.CNPJ,
                    CEP = empresaCnpjExiste.CEP,
                    Regiao = empresaCnpjExiste.Regiao,
                    Descricao = empresaCnpjExiste.Descricao,
                    Dominio = empresaCnpjExiste.Dominio

                };

                return new GenericQueryResult(true, "Empresas encontradas", empresaEmailResult);
            }

            var empresaIdExiste = _empresaRepository.BuscarDadosEmpresa(command.Empresa.ToString()).Result;

            if(empresaIdExiste == null)
            {
                return new GenericQueryResult(false, "Nenhuma empresa foi encontrada", null);
            }

            var empresaIdResult = new BuscarEmpersaResult
            {
                Id = empresaIdExiste.Id,
                Nome = empresaIdExiste.Nome,
                Email = empresaIdExiste.Email,
                Senha = empresaIdExiste.Senha,
                Telefone = empresaIdExiste.Telefone,
                CNPJ = empresaIdExiste.CNPJ,
                CEP = empresaIdExiste.CEP,
                Regiao = empresaIdExiste.Regiao,
                Descricao = empresaIdExiste.Descricao,
                Dominio = empresaIdExiste.Dominio,
                Imagem = empresaIdExiste.Imagem
            };

            return new GenericQueryResult(true, "Empresas Encontradas", empresaIdResult);

        }
    }
}
