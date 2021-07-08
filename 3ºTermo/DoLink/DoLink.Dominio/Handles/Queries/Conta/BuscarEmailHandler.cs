using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Queries;
using DoLink.Dominio.Queries.Conta;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Queries.Conta
{
    public class BuscarEmailHandler : Notifiable, IHandlerQuery<BuscarEmailQuery>
    {
        //Instânciando os métodos contidos no repositório de profissional
        private readonly IProfissionalRepository _profissionalRepository;

        //Instânciando os métodos contidos no repositório de empresa
        private readonly IEmpresaRepository _empresaRepository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public BuscarEmailHandler(IProfissionalRepository _profissional, IEmpresaRepository _empresa)
        {
            _profissionalRepository = _profissional;
            _empresaRepository = _empresa;
        }

        public IQueryResult Handler(BuscarEmailQuery command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validate();

            //Caso os dados estejam inválidos retornamos o erro
            if (command.Invalid)
            {
                return new GenericQueryResult(false, "Dados Inválidos!", command.Notifications);
            }

            //Verificando se o email informada não pertence a um profissional
            var profissionalExistente = _profissionalRepository.BuscarEmailProfissional(command.Email).Result;

            //Conferindo o email seja um email de profissional
            if (profissionalExistente != null)
            {
                //Retornando sucesso caso os dados conferem no banco
                return new GenericQueryResult(true, "Dados do profissional", profissionalExistente);
            }

            //Verificando se o email informada não pertence a uma empresa
            var empresaExistente = _empresaRepository.BuscarPorEmail(command.Email).Result;

            //Conferindo se o email seja um email de uma empresa
            if (empresaExistente != null)
            {
                //Retornando sucesso caso os dados conferem no banco
                return new GenericQueryResult(true, "Logado com sucesso", empresaExistente);
            }

            //Retornando erro caso o usuário não encontrado
            return new GenericQueryResult(false, "Email não encontrado", null);
        }
    }
}
