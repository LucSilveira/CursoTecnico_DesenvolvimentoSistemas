using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Commands.Skill
{
    public class ExcluirSkillHandler : Notifiable, IHandler<ExcluirSkillCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly ISkillRepository _repository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public ExcluirSkillHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método para excluir uma skill existente no banco de dados
        /// </summary>
        /// <param name="command">dados a serem processados para localizar a skill desejada</param>
        /// <returns>Dados a cerca da skill excluida</returns>
        public ICommandResult Handler(ExcluirSkillCommand command)
        {
            //Chamando o método para validar os parametros
            command.Validar();

            //Caso os parametros estejam com erro, retornamos a notificação
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);
            }

            //Consultando se a skill procurada existe no banco de dados
            var skillExistente = _repository.BuscarSkillEspecifica(command.Id).Result;

            //Caso a skill não exista retornamos o erro
            if (skillExistente == null)
            {
                return new GenericCommandResult(false, "Skill não encontrada", command.Notifications);
            }

            //Passando para o banco de dados o objeto que será excluido
            _repository.DeletarSkill(skillExistente);

            //Retornamos com sucesso os dados da skill deletada
            return new GenericCommandResult(true, "Skill deletada com sucesso", skillExistente);
        }
    }
}
