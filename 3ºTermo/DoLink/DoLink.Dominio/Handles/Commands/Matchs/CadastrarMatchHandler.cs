using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Matchs;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Matchs
{
    public class CadastrarMatchHandler : Notifiable, IHandler<CadastrarMatchCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IMatchRepository _repository;

        //Instânciando os métodos contidos no repositório
        public readonly IVagaRepository _vagaRepository;

        //Instânciando os métodos contidos no repositório
        public readonly IProfissionalRepository _profissionalRepository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public CadastrarMatchHandler(IMatchRepository repository, IVagaRepository vagaRepository, IProfissionalRepository profissionalRepository)
        {
            _repository = repository;
            _vagaRepository = vagaRepository;
            _profissionalRepository = profissionalRepository;
        }

        public ICommandResult Handler(CadastrarMatchCommand command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validar();

            //Caso os dados estejam inválidos retornamos o erro
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);
            }

            //Buscando no banco de dados se o match informado já não existe
            var matchExistente = _repository.BuscarMatch(command.IdProfissional, command.IdVaga).Result;

            //Caso o mesmo já exista informamos o erro
            if (matchExistente != null)
            {
                return new GenericCommandResult(false, "Match já confirmado!", command.Notifications);
            }

            //Buscando os dados da vaga para tratativa dos níveis de preferência
            var vaga = _vagaRepository.BuscarDadosVaga(command.IdVaga).Result;

            //Buscando os dados do profissional para tratativa dos níveis de preferência
            var profissional = _profissionalRepository.BuscarProfissionalEspecifico(command.IdProfissional).Result;

            //Verificando o nivel de acesso
            int acesso = _repository.VerificarNivelPreferencia(profissional, vaga);

            //Criando o objeto com os dados informados
            var match = new Match(command.IdVaga, command.IdProfissional, acesso);

            //Caso os dados estejam corretos, inserimos o novo match no banco de dados
            if (match.Valid)
            {
                _repository.CadastrarMatch(match);
            }

            //Retornando com sucesso os dados do novo match cadastrado
            return new GenericCommandResult(true, "Match efetuado com sucesso", match);
        }
    }
}
