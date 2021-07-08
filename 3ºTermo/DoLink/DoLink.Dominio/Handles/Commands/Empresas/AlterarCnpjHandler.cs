using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Empresas;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Empresas
{
    public class AlterarCnpjHandler : Notifiable, IHandler<AlterarCnpjCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IEmpresaRepository _empresaRepository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public AlterarCnpjHandler(IEmpresaRepository _repository)
        {
            _empresaRepository = _repository;
        }

        public ICommandResult Handler(AlterarCnpjCommand command)
        {
            command.Validar();

            if (!command.Valid)
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);

            var empresa = _empresaRepository.BuscarDadosEmpresa(command.Id).Result;

            if (empresa == null)
                return new GenericCommandResult(false, "Empresa não encontrada", command.Notifications);

            empresa.AlterarCnpj(command.CNPJ);

            _empresaRepository.AlterarEmpresaRepositorie(empresa.Id, empresa);

            return new GenericCommandResult(true, "CNPJ da empresa alterado", empresa);
        }
    }
}
