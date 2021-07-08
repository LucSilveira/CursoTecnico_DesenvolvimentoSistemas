using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Utils;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Conta;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Conta
{
    public class EsqueciMinhaSenhaHandler : Notifiable, IHandler<EsqueciMinhaSenhaCommand>
    {
        //Instânciando os métodos contidos no repositório de profissional
        private readonly IProfissionalRepository _profissionalRepository;

        //Instânciando os métodos contidos no repositório de empresa
        private readonly IEmpresaRepository _empresaRepository;

        //Instânciando os métodos contidos no repositório de admin
        private readonly IAdminRepository _adminRepository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public EsqueciMinhaSenhaHandler(IProfissionalRepository _profissional, IEmpresaRepository _empresa, IAdminRepository admin)
        {
            _adminRepository = admin;
            _profissionalRepository = _profissional;
            _empresaRepository = _empresa;
        }

        /// <summary>
        /// Método para resetar a senha de um usuário
        /// </summary>
        /// <param name="command">Email para encaminharmos uma nova senha</param>
        /// <returns>Nova senha gerada</returns>
        public ICommandResult Handler(EsqueciMinhaSenhaCommand command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validar();

            //Caso os dados esteja com erro, retornamos uma notificação
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);
            }

            //Gerando nova senha para o usuário
            var _novaSenha = SenhaUtils.GerarNovaSenha();

            //Encriptografando a nova senha gerada
            var _novaSenhaEncriptografada = SenhaUtils.CriptografarSenha(_novaSenha);

            //Verificando se o email informada não pertence a um profissional
            var profissionalExistente = _profissionalRepository.BuscarEmailProfissional(command.Email).Result;

            //Conferindo o email seja um email de profissional
            if (profissionalExistente != null)
            {
                //Criando o objeto com os dados informados
                profissionalExistente.AlterarSenha(_novaSenhaEncriptografada);

                //Salvando no banco de dados as novas informações
                _profissionalRepository.AlterarProfissional(profissionalExistente);

                _ = SendEmail.EnviarEmail(profissionalExistente.Email, profissionalExistente.Nome,
                        "Confirmação de nova senha", "Senha alterada com sucesso!", $"Conforme a solicitação da alteração de senha, nos da plataforma DoLink disponibizamos uma nova senha para você, faça o login na plataforma inserindo os novos dados e sinta-se a vontade para altera-lá quando precisar, muito obrigado!<br><br>Sua nova senha é: ", _novaSenha);

                //Retornando com sucesso o profissional alterado
                return new GenericCommandResult(true, "Nova senha gerada com sucesso, consulte seu email para conferir as informações", profissionalExistente);
            }

            // Verificando se o email informada não pertence a uma empresa
            var empresaExistente = _empresaRepository.BuscarPorEmail(command.Email).Result;

            //Conferindo se o email seja um email de uma empresa
            if (empresaExistente != null)
            {
                //Criando o objeto com os dados informados
                empresaExistente.AlterarSenha(_novaSenhaEncriptografada);

                //Salvando no banco de dados as novas informações
                _empresaRepository.AlterarEmpresaRepositorie(empresaExistente.Id, empresaExistente);

                //Enviando email de confirmação de alteração da senha
                _ = SendEmail.EnviarEmail(empresaExistente.Email, empresaExistente.Nome,
                        "Confirmação de nova senha", "Senha alterada com sucesso!", $"Conforme a solicitação da alteração de senha, nos da plataforma DoLink disponibizamos uma nova senha para você, faça o login na plataforma inserindo os novos dados e sinta-se a vontade para altera-lá quando precisar, muito obrigado!<br><br>Sua nova senha é: ", _novaSenha);

                //Retornando com sucesso a empresa alterada
                return new GenericCommandResult(true, "Nova senha gerada com sucesso, consulte seu email para conferir as informações", empresaExistente);
            }

            // Verificando se o email informada não pertence a um admin
            var adminExistente = _adminRepository.BuscarAdmin(command.Email).Result;

            //Conferindo se o email seja um email de um admin
            if (adminExistente != null)
            {
                //Criando o objeto com os dados informados
                adminExistente.AlterarSenha(_novaSenhaEncriptografada);

                //Salvando no banco de dados as novas informações
                _adminRepository.AlterarSenhaAdmin(adminExistente);

                //Retornando com sucesso o admin alterado
                return new GenericCommandResult(true, "Nova senha gerada com sucesso", adminExistente);
            }

            //Retornando erro caso o usuário não encontrado
            return new GenericCommandResult(false, "Email não encontrado", null);
        }
    }
}
