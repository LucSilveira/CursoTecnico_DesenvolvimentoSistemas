using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Utils;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Skill;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using DoLink.Dominio.Utils;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Skills
{
    public class CadastrarSkillHandler : Notifiable, IHandler<CadastrarSkillCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly ISkillRepository _repository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public CadastrarSkillHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método para cadasrar uma nova skill
        /// </summary>
        /// <param name="command">Dados a serem inseridos</param>
        /// <returns>Nova skill cadastrada</returns>
        public ICommandResult Handler(CadastrarSkillCommand command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validar();

            //Caso os dados estejam inválidos retornamos o erro
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);
            }

            //Buscando no banco de dados se a skill informada já não existe
            var _skillExistente = _repository.BuscarSkill(command.Nome).Result;

            //Caso a mesma já exista informamos o erro
            if(_skillExistente != null)
            {
                return new GenericCommandResult(false, "Skill já cadastrada!", command.Notifications);
            }

            //Pegando o hash para setar na skill
            var hash = CreateHash.HashSkill();

            //Criando o objeto com os dados informados
            var skill = new Skill(command.Nome, hash);

            //Caso os dados estejam corretos, inserimos a nova skill no banco de dados
            if (skill.Valid)
            {
                _repository.CadastrarSkill(skill);
            }

            //Retornando com sucesso os dados da nova skill cadastrada
            return new GenericCommandResult(true, "Skill cadastrada com sucesso", skill);
        }
    }
}
