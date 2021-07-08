using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Vagas;
using DoLink.Dominio.Repositories;
using DoLink.Dominio.Utils;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Vagas
{
    public class AlterarSkillVagaHandler : Notifiable, IHandler<AlterarSkillsVagaCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IVagaRepository _vagaRepositorio;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public AlterarSkillVagaHandler(IVagaRepository vagaRepossitorio)
        {
            _vagaRepositorio = vagaRepossitorio;
        }

        /// <summary>
        /// Método para alterar as skills necessárias para a vaga
        /// </summary>
        /// <param name="command">Vaga com as skills alterados</param>
        /// <returns>Vaga com as skills alteradas</returns>
        public ICommandResult Handler(AlterarSkillsVagaCommand command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validar();

            //Caso os dados esteja com erro, retornamos uma notificação
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);
            }

            //Procurando o profissional informado no banco de dados
            var vagaExistente = _vagaRepositorio.BuscarDadosVaga(command.Id).Result;

            //Caso a mesmo não exista, retornamos o erro    
            if (vagaExistente == null)
            {
                return new GenericCommandResult(false, "Vaga não encontrada", command.Notifications);
            }

            //Passando o array de skills para ordena-lo
            command.EspecificacoesSkills = OrdenarSkills.OrdenarArray(command.EspecificacoesSkills);

            //Passando as skills para hashear o token de skills
            var hash = HasheandoSkills.HashSkill(command.EspecificacoesSkills);

            //Criando o objeto com os dados informados
            vagaExistente.AlterarSkills(command.EspecificacoesSkills, hash.Item1, hash.Item2);

            //Salvando no banco de dados as novas informações
            _vagaRepositorio.AlterarVagaRepositorie(vagaExistente.Id, vagaExistente);

            //Retornando com sucesso a vaga alterada
            return new GenericCommandResult(true, "Vaga alterada com sucesso", vagaExistente);
        }
    }
}
