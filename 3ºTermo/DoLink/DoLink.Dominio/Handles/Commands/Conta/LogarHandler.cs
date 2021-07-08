using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Utils;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Conta;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Conta
{
    public class LogarHandler : Notifiable, IHandler<LogarCommand>
    {
        //Instânciando os métodos contidos no repositório de profissional
        private readonly IProfissionalRepository _profissionalRepository;

        //Instânciando os métodos contidos no repositório de empresa
        private readonly IEmpresaRepository _empresaRepository;

        //Instânciando os métodos contidos no repositório de administrador
        private readonly IAdminRepository _adminRepository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public LogarHandler(IProfissionalRepository _profissional, IEmpresaRepository _empresa, IAdminRepository _admin)
        {
            _adminRepository = _admin;
            _profissionalRepository = _profissional;
            _empresaRepository = _empresa;
        }

        /// <summary>
        /// Método para autenticar os usuários da aplicação
        /// </summary>
        /// <param name="command">Dados informados para realizar o login</param>
        /// <returns>Código de autenticação</returns>
        public ICommandResult Handler(LogarCommand command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validar();

            //Caso os dados estejam inválidos retornamos o erro
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);
            }

            //Verificando se o email informada não pertence a um profissional
            var profissionalExistente = _profissionalRepository.BuscarEmailProfissional(command.Email).Result;

            //Conferindo o email seja um email de profissional
            if(profissionalExistente != null)
            {
                //Verificando se a senha informada não confere com a pertencente no banco de dados
                if (!SenhaUtils.ValidarSenha(command.Senha, profissionalExistente.Senha))
                {
                    return new GenericCommandResult(false, "Senha inválida", command.Notifications);
                }

                //Retornando sucesso caso os dados conferem no banco
                return new GenericCommandResult(true, "Profissional logado com sucesso!", profissionalExistente);
            }

            //Verificando se o email informada não pertence a uma empresa
            var empresaExistente = _empresaRepository.BuscarPorEmail(command.Email).Result;
            
            //Conferindo se o email seja um email de uma empresa
            if(empresaExistente != null)
            {
                //Verificando se a senha informada não confere com a pertencente no banco de dados
                if(!SenhaUtils.ValidarSenha(command.Senha, empresaExistente.Senha))
                {
                    return new GenericCommandResult(false, "Senha inválida", command.Notifications);
                }

                //Retornando sucesso caso os dados conferem no banco
                return new GenericCommandResult(true, "Logado com sucesso", empresaExistente);
            }

            //Verificando se o email não pertence a conta de administrador
            Administrador adminExistente = _adminRepository.BuscarAdmin(command.Email).Result;

            //Conferindo se o email não é do administrador
            if(adminExistente != null)
            {
                //Verificando se a senha informada não confere com a pertencente no banco de dados
                if (!SenhaUtils.ValidarSenha(command.Senha, adminExistente.Senha))
                {
                    return new GenericCommandResult(false, "Senha inválida", command.Notifications);
                }

                //Retornando sucesso caso os dados conferem no banco
                return new GenericCommandResult(true, "Logado com sucesso", adminExistente);
            }

            //Retornando erro caso o usuário não encontrado
            return new GenericCommandResult(false, "Email não encontrado", null);
        }
    }
}
