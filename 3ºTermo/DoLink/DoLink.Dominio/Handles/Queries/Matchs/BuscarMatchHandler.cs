using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Queries;
using DoLink.Dominio.Queries.Empresas;
using DoLink.Dominio.Queries.Matchs;
using DoLink.Dominio.Queries.Profissionais;
using DoLink.Dominio.Queries.Vagas;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoLink.Dominio.Handles.Queries.Matchs
{
    public class BuscarMatchHandler : Notifiable, IHandlerQuery<BuscarMatchQuery>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IMatchRepository _repository;

        //Instânciando os métodos contidos no repositório
        public readonly IVagaRepository _vagaRepository;

        //Instânciando os métodos contidos no repositório
        public readonly IProfissionalRepository _profissionalRepository;

        //Instânciando os métodos contidos no repositório
        public readonly IEmpresaRepository _empresaRepository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public BuscarMatchHandler(IMatchRepository repository, IVagaRepository vagaRepository, IProfissionalRepository profissionalRepository, IEmpresaRepository empresaRepository)
        {
            _repository = repository;
            _vagaRepository = vagaRepository;
            _profissionalRepository = profissionalRepository;
            _empresaRepository = empresaRepository;
        }

        public IQueryResult Handler(BuscarMatchQuery command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new GenericQueryResult(false, "Dados inválidos", command.Notifications);
            }

            var vagaExistente = _vagaRepository.BuscarDadosVaga(command.Id).Result;

            if(vagaExistente != null)
            {
                var listMatch = _repository.ListaDeMatchsVaga(command.Id).Result;

                if(listMatch == null)
                {
                    return new GenericQueryResult(false, "Nenhum match encontrado", command.Notifications);
                }

                var matchVagaResult = listMatch.Select(mtc =>
                {
                    var profissional = _profissionalRepository.BuscarProfissionalEspecifico(mtc.IdProfissional).Result;

                    var empresa = _empresaRepository.BuscarDadosEmpresa(vagaExistente.IdEmpresa).Result;

                    return new BuscarMatchResult
                    {
                        Id = mtc.Id,
                        DadosEmpresa = new BuscarEmpersaResult
                        {
                            Id = empresa.Id,
                            Nome = empresa.Nome,
                            Dominio = empresa.Dominio
                        },
                        DadosVaga = new BuscarVagaResult
                        {
                            Id = vagaExistente.Id,
                            Titulo = vagaExistente.Titulo,
                            Descricao = vagaExistente.Descricao,
                            Local = vagaExistente.Local
                        },
                        DadosProfissional = new BuscarProfissionalResult
                        {
                            Id = profissional.Id,
                            Nome = profissional.Nome,
                            Email = profissional.Email,
                            Telefone = profissional.Telefone
                        },
                        NivelAcesso = mtc.NivelAcesso
                    };
                });             

                return new GenericQueryResult(true, "Dados do match", matchVagaResult);
            }

            var profissionalExistente = _profissionalRepository.BuscarProfissionalEspecifico(command.Id).Result;

            if(profissionalExistente == null)
            {
                return new GenericQueryResult(false, "Profissional não encontrado", null);
            }

            var _listaMatch = _repository.ListaDeMatchsProfissional(command.Id).Result;

            if (_listaMatch == null)
            {
                return new GenericQueryResult(false, "Nenhum match encontrado", command.Notifications);
            }

            var matchProfissionalResult = _listaMatch.Select(mtc =>
            {
                var vaga = _vagaRepository.BuscarDadosVaga(mtc.IdVaga).Result;

                var empresa = _empresaRepository.BuscarDadosEmpresa(vaga.IdEmpresa).Result;

                return new BuscarMatchResult
                {
                    Id = mtc.Id,
                    DadosEmpresa = new BuscarEmpersaResult
                    {
                        Id = empresa.Id,
                        Nome = empresa.Nome,
                        Dominio = empresa.Dominio
                    },
                    DadosVaga = new BuscarVagaResult
                    {
                        Id = vaga.Id,
                        Titulo = vaga.Titulo,
                        Descricao = vaga.Descricao,
                        Local = vaga.Local
                    },
                    DadosProfissional = new BuscarProfissionalResult
                    {
                        Id = profissionalExistente.Id,
                        Nome = profissionalExistente.Nome,
                        Email = profissionalExistente.Email,
                        Telefone = profissionalExistente.Telefone
                    }
                };
            });

            return new GenericQueryResult(true, "Dados do match", matchProfissionalResult);
        }
    }
}
