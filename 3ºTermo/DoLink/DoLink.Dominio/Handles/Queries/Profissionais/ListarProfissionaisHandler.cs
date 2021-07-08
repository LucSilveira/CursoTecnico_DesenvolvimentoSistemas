using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Queries;
using DoLink.Dominio.Queries.Profissionais;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoLink.Dominio.Handles.Queries.Profissionais
{
    public class ListarProfissionaisHandler : Notifiable, IHandlerQuery<ListarProfissionalQuery>
    {
        //Instânciando a interface que contém os métodos
        public readonly IProfissionalRepository _repository;

        //Aplicando a injeção de dependência dentro da classe
        public ListarProfissionaisHandler(IProfissionalRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método para listar os profissionais cadastrados
        /// </summary>
        /// <returns>Lista com todos os profissionais</returns>
        public IQueryResult Handler(ListarProfissionalQuery command)
        {
            var _query = _repository.ListarProfissional();

            if(_query == null)
            {
                return new GenericQueryResult(false, "Profissionais não cadastrados", null);
            }

            var profissionais = _query.Result.Select(pfl =>
            {
                return new ListarProfissionaisResult
                {
                    Id = pfl.Id,
                    Nome = pfl.Nome,
                    Email = pfl.Email,
                    Telefone = pfl.Telefone,
                    CEP = pfl.CEP
                };
            });

            //Retornando com sucesso a lista de profissionais cadastrados
            return new GenericQueryResult(true, "Lista de profissionais", profissionais);
        }
    }
}
