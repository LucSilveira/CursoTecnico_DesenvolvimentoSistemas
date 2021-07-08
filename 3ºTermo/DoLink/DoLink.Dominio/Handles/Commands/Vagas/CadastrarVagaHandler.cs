using DoLink.Comum.Commands;
using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Utils;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Vaga;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using DoLink.Dominio.Utils;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Vagas
{
    public class CadastrarVagaHandler : Notifiable, IHandler<CadastrarVagaCommand>
    {
        //Instânciando os métodos contidos no repositório
        public readonly IVagaRepository _vagaRepository;

        //Instânciando os métodos contidos no repositório
        public readonly IEmpresaRepository _empresaRepository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public CadastrarVagaHandler(IVagaRepository _repository, IEmpresaRepository repository)
        {
            _vagaRepository = _repository;
            _empresaRepository = repository;
        }

        public ICommandResult Handler(CadastrarVagaCommand command)
        {
            //Chamando o método para validar os parametros recebidos
            command.Validar();

            //Caso os dados estejam inválidos retornamos o erro
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Dados Inválidos!", command.Notifications);
            }

            var empresa = _empresaRepository.BuscarDadosEmpresa(command.IdEmpresa).Result;

            if(empresa == null)
            {
                return new GenericCommandResult(false, "Empresa não encontrada!", command.Notifications);
            }

            command.EspecificacoesSkills = OrdenarSkills.OrdenarArray(command.EspecificacoesSkills);

            var hash = HasheandoSkills.HashSkill(command.EspecificacoesSkills);

            var vaga = new Vaga(command.IdEmpresa, command.Titulo, command.Descricao, command.Local,command.FaixaSalarial, command.Beneficios, command.DataVencimento, command.EspecificacoesSkills, hash.Item1, hash.Item2);

            var a = vaga.Titulo.ToString() + " "
                + vaga.Descricao.ToString() + " "
                + vaga.Local.ToString() + " "
                + vaga.Beneficios.ToString();

            //Validação na moderação de conteudo
            var resultado = new ContentModerator().Moderar(a.ToLower());

            if (resultado != null)
            {
                var palavras = resultado.Select(
                    r =>
                    {
                        return new
                        {
                            palavra = r.Term
                        };
                    }
                    ).ToArray();
                return new GenericCommandResult(false, "Palavras inadequadas", palavras);
            }

            if (vaga.Valid)
                _vagaRepository.CadastrarVaga(vaga);

            return new GenericCommandResult(true, "Vaga cadastrada com sucesso", vaga);
        }
    }
}
