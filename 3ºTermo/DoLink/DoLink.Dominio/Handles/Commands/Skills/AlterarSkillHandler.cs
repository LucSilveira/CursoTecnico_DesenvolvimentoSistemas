using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Utils;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Skill;
using DoLink.Dominio.Commands.Skills;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Skills
{
    public class AlterarSkillHandler : Notifiable, IHandler<AlterarSkillCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly ISkillRepository _repository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public AlterarSkillHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método para alterar os dados de uma skill existente
        /// </summary>
        /// <param name="command">Dados a serem processados</param>
        /// <returns>Skill com os novos dados atualizados</returns>
        public ICommandResult Handler(AlterarSkillCommand command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validar();

            //Caso os dados esteja com erro, retornamos uma notificação
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);
            }

            //Procurando a skill informada no banco de dados
            var skillExistente = _repository.BuscarSkillEspecifica(command.Id).Result;

            //Caso a mesmo não exista, retornamos o erro
            if(skillExistente == null)
            {
                return new GenericCommandResult(false, "Skill não encontrada", command.Notifications);
            }

            //Procurando o novo nome no banco de dados
            var skillName = _repository.BuscarSkill(command.Nome).Result;

            //Caso o nome já esteja em uso, retornamos o erro
            if(skillName != null)
            {
                return new GenericCommandResult(false, "Skill já cadastrada", command.Notifications);
            }

            //Alteramos o objeto com os novos dados
            skillExistente.AlterarSkill(command.Nome);

            //Atualizamos os dados no banco de dados
            _repository.AlterarSkill(skillExistente);

            //Retornando com sucesso os dados atualizados
            return new GenericCommandResult(true, "Skill alterada com sucesso", skillExistente);
        }
    }
}
