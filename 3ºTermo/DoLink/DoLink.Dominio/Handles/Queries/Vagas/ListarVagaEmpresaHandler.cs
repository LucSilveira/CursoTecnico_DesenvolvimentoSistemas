using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Queries;
using DoLink.Dominio.Queries.Vagas;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoLink.Dominio.Handles.Queries.Vagas
{
    public class ListarVagaEmpresaHandler : Notifiable, IHandlerQuery<ListarVagaEmpresaQuery>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IVagaRepository _vagaRepository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public ListarVagaEmpresaHandler(IVagaRepository _repository)
        {
            _vagaRepository = _repository;
        }

        public IQueryResult Handler(ListarVagaEmpresaQuery command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validate();

            //Caso os dados estejam inválidos retornamos o erro
            if (command.Invalid)
            {
                return new GenericQueryResult(false, "Dados Inválidos!", command.Notifications);
            }

            var _query = _vagaRepository.ListarVagaEmpresa(command.Id).Result;

            if(_query == null)
            {
                return new GenericQueryResult(true, "Nenhuma vaga foi encontrada", null);
            }

            var vagasEmpresa = _query.Select(vg =>
            {
                return new ListarVagaEmpresaResult
                {
                    Id = vg.Id,
                    Titulo = vg.Titulo,
                    Descricao = vg.Descricao,
                    Local = vg.Local,
                    Status = vg.Status.ToString(),
                    FaixaSalarial = vg.FaixaSalarial.ToString(),
                    Beneficios = vg.Beneficios,
                    DataVencimento = vg.DataVencimento
                };
            });

            //Retornando com sucesso a lista de vagas da empresa cadastrados
            return new GenericQueryResult(true, "Lista das vagas da empresa", vagasEmpresa);
        }
    }
}
