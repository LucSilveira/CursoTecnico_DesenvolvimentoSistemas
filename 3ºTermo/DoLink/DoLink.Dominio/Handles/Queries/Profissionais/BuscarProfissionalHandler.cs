using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Queries;
using DoLink.Dominio.Queries.Profissionais;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Queries.Profissionais
{
    public class BuscarProfissionalHandler : Notifiable, IHandlerQuery<BuscarProfissionalQuery>
    {
        //Instânciando a interface que contém os métodos
        public readonly IProfissionalRepository _repository;

        //Aplicando a injeção de dependência dentro da classe
        public BuscarProfissionalHandler(IProfissionalRepository repository)
        {
            _repository = repository;
        }

        public IQueryResult Handler(BuscarProfissionalQuery command)
        {
            //Validando dados informados
            command.Validate();

            //Verificando se a buscar por uma skill não através do seu nome
            if (command.Valid)
            {
                //Verificando se o nome corresponde as especifícações
                if (command.Invalid)
                {
                    return new GenericQueryResult(false, "Dados inválidos", command.Notifications);
                }

                //Consultando se o profissional está cadastrado no banco de dados
                var profissionalCpfExistente = _repository.BuscarProfissional(command.Profissional).Result;

                //Caso não exista retornamos a mensagem de erro
                if (profissionalCpfExistente == null)
                {
                    return new GenericQueryResult(false, "Profissional não encontrado", null);
                }

                //Criamos a mascará para mostrar apenas os dados necessários
                var profissionalCpfResult = new BuscarProfissionalResult
                {
                    Id = profissionalCpfExistente.Id,
                    Nome = profissionalCpfExistente.Nome,
                    Email = profissionalCpfExistente.Email,
                    Telefone = profissionalCpfExistente.Telefone,
                    CEP = profissionalCpfExistente.CEP,
                    CPF = profissionalCpfExistente.CPF,
                    FaixaSalarial = profissionalCpfExistente.FaixaSalarial,
                    SobreMim = profissionalCpfExistente.SobreMim,
                    Linkedin = profissionalCpfExistente.Linkedin,
                    Repositorio = profissionalCpfExistente.Repositorio,
                    Curriculo = profissionalCpfExistente.CurriculoProfissional,
                    Skills = profissionalCpfExistente.SkillsProfissional
                };

                //Retornamos o profissional procurado com sucesso
                return new GenericQueryResult(true, "Dados do profissional", profissionalCpfResult);
            }

            //Consultando se o profissional está cadastrado no banco de dados
            var profissionalExistente = _repository.BuscarProfissionalEspecifico(command.Profissional).Result;

            //Caso não exista retornamos a mensagem de erro
            if (profissionalExistente == null)
            {
                return new GenericQueryResult(false, "Profissional não encontrado", null);
            }

            //Criamos a mascará para mostrar apenas os dados necessários
            var profissionalIdResult = new BuscarProfissionalResult
            {
                Id = profissionalExistente.Id,
                Nome = profissionalExistente.Nome,
                Email = profissionalExistente.Email,
                Telefone = profissionalExistente.Telefone,
                CEP = profissionalExistente.CEP,
                CPF = profissionalExistente.CPF,
                FaixaSalarial = profissionalExistente.FaixaSalarial,
                SobreMim = profissionalExistente.SobreMim,
                Linkedin = profissionalExistente.Linkedin,
                Repositorio = profissionalExistente.Repositorio,
                Curriculo = profissionalExistente.CurriculoProfissional,
                Skills = profissionalExistente.SkillsProfissional
            };

            //Retornamos o profissional procurado com sucesso
            return new GenericQueryResult(true, "Dados do profissional", profissionalIdResult);
        }
    }
}
