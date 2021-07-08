using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Utils;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Conta
{
    public class AlterarSenhaHandler : Notifiable, IHandler<AlterarSenhaCommand>
    {
        //Instânciando os métodos contidos no repositório de profissional
        private readonly IProfissionalRepository _profissionalRepository;

        //Instânciando os métodos contidos no repositório de empresa
        private readonly IEmpresaRepository _empresaRepository;

        //Instânciando os métodos contidos no repositório de administrador
        private readonly IAdminRepository _adminRepository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public AlterarSenhaHandler(IProfissionalRepository _profissional, IEmpresaRepository _empresa, IAdminRepository _admin)
        {
            _adminRepository = _admin;
            _profissionalRepository = _profissional;
            _empresaRepository = _empresa;
        }

        public ICommandResult Handler(AlterarSenhaCommand command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validar();

            //Caso os dados esteja com erro, retornamos uma notificação
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);
            }

            if (command.NovaSenha != command.Confirmacao)
            {
                return new GenericCommandResult(false, "A confirmação de senha está errada", null);
            }

            //Verificando se o email informada não pertence a um profissional
            var profissionalExistente = _profissionalRepository.BuscarEmailProfissional(command.Email).Result;

            //Conferindo o email seja um email de profissional
            if (profissionalExistente != null)
            {
                //Verificando se a senha informada não confere com a pertencente no banco de dados
                if (SenhaUtils.ValidarSenha(command.NovaSenha, profissionalExistente.Senha))
                {
                    return new GenericCommandResult(false, "A nova senha deve ser diferente da cadastrada", command.Notifications);
                }

                //Encriptografando a senha informada
                command.NovaSenha = SenhaUtils.CriptografarSenha(command.NovaSenha);

                //Criando o objeto com os dados informados
                profissionalExistente.AlterarSenha(command.NovaSenha);

                //Salvando no banco de dados as novas informações
                _profissionalRepository.AlterarProfissional(profissionalExistente);

                //Enviando um email para confirmação de alteração de senha
                _ = SendEmail.EnviarEmail(profissionalExistente.Email, profissionalExistente.Nome,
                      "Confirmação de alteração de senha", "Senha alterada com sucesso!", "Conforme a solicitação da alteração de senha, confirmamos que sua senha foi alterada com sucesso, faça o login na plataforma inserindo os novos dados, gratos!", null);

                //Retornando sucesso caso os dados conferem no banco
                return new GenericCommandResult(true, "Senha alterada com sucesso", profissionalExistente);
            }

            //Verificando se o email informada não pertence a uma empresa
            var empresaExistente = _empresaRepository.BuscarPorEmail(command.Email).Result;

            //Conferindo se o email seja um email de uma empresa
            if (empresaExistente != null)
            {
                //Verificando se a senha informada não confere com a pertencente no banco de dados
                if (SenhaUtils.ValidarSenha(command.NovaSenha, empresaExistente.Senha))
                {
                    return new GenericCommandResult(false, "Senha inválida", command.Notifications);
                }

                //Encriptografando a senha informada
                command.NovaSenha = SenhaUtils.CriptografarSenha(command.NovaSenha);

                //Criando o objeto com os dados informados
                empresaExistente.AlterarSenha(command.NovaSenha);

                //Salvando no banco de dados as novas informações
                _empresaRepository.AlterarEmpresaRepositorie(empresaExistente.Id, empresaExistente);

                //Enviando um email para confirmação de alteração de senha
                _ = SendEmail.EnviarEmail(empresaExistente.Email, empresaExistente.Nome,
                      "Confirmação de alteração de senha", "Senha alterada com sucesso!", "Conforme a solicitação da alteração de senha, confirmamos que sua senha foi alterada com sucesso, faça o login na plataforma inserindo os novos dados, gratos!", null);

                //Retornando sucesso caso os dados conferem no banco
                return new GenericCommandResult(true, "Senha alterada com sucesso", empresaExistente);
            }

            //Verificando se o email informada não pertence a um admin
            var adminExistente = _adminRepository.BuscarAdmin(command.Email).Result;

            //Conferindo se o email seja um email de um admin
            if (adminExistente != null)
            {
                //Verificando se a senha informada não confere com a pertencente no banco de dados
                if (SenhaUtils.ValidarSenha(command.NovaSenha, adminExistente.Senha))
                {
                    return new GenericCommandResult(false, "Senha inválida", command.Notifications);
                }

                //Encriptografando a senha informada
                command.NovaSenha = SenhaUtils.CriptografarSenha(command.NovaSenha);

                //Criando o objeto com os dados informados
                adminExistente.AlterarSenha(command.NovaSenha);

                //Encriptografando a senha informada
                command.NovaSenha = SenhaUtils.CriptografarSenha(command.NovaSenha);

                //Salvando no banco de dados as novas informações
                _adminRepository.AlterarSenhaAdmin(adminExistente);

                //Retornando sucesso caso os dados conferem no banco
                return new GenericCommandResult(true, "Senha alterada com sucesso", adminExistente);
            }

            //Retornando erro caso o usuário não encontrado
            return new GenericCommandResult(false, "Email não encontrado", null);
        }
    }
}
