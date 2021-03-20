using Carometro.Comum.Entidades;
using Carometro.Comum.Enum;
using Flunt.Br.Extensions;
using Flunt.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Carometro.Dominio.Entidades
{
    public class Professor : Usuario
    {
        public Professor(string nomeUsuario, string email, string senha, string telefone, string fotoProfessor)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nomeUsuario, 3, "NomeProfessor", "O Nome do Professor deve conter no mínimo 3 caractéres")
                .IsEmail(email, "Email", "Informe um Email válido")
                .HasMinLen(senha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres")
                .IsNewFormatCellPhone(telefone, "Telefone", "Insira um Número de Telefone Válido")
                .IsNotNullOrEmpty(fotoProfessor, "Foto do professor", "Informe uma imagem para o professor")
            );

            if (Valid)
            {
                NomeUsuario = nomeUsuario;
                Email = email;
                Senha = senha;
                Telefone = telefone;
                FotoProfessor = fotoProfessor;
                TipoUsuario = EnTipoUsuario.Professor;
                DataCriacao = DateTime.Now;
                DataAlteracao = DateTime.Now;
                TipoUsuario = EnTipoUsuario.Professor;
            }
        }

        public void AlterarProfessor(string nomeUsuario, string email, string telefone, string fotoProfessor)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nomeUsuario, 3, "NomeProfessor", "O Nome do Professor deve conter no mínimo 3 caractéres")
                .IsEmail(email, "Email", "Informe um Email válido")
                .IsNewFormatCellPhone(telefone, "Telefone", "Insira um Número de Telefone Válido")
                .IsNotNullOrEmpty(fotoProfessor, "Foto do professor", "Informe uma imagem para o professor")
            );

            if (Valid)
            {
                NomeUsuario = nomeUsuario;
                Email = email;
                Telefone = telefone;
                FotoProfessor = fotoProfessor;
                TipoUsuario = EnTipoUsuario.Professor;
                DataCriacao = DataCriacao;
                DataAlteracao = DateTime.Now;
            }
        }

        public void Alterarsenha(string senha)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(senha, 6, "Senha", "A senha deve possuir no mínimo 6 caracteres")
                .HasMaxLen(senha, 80, "Senha", "A senha deve possuir no máximo 80 caracteres")
            );

            if (Valid)
            {
                Senha = senha;
            }
        }

        [NotMapped]
        [JsonIgnore]
        public IFormFile Arquivo { get; set; }
        public string FotoProfessor { get; set; }


        private readonly IList<ProfessorTurma> _professoresTurmas;
        public IReadOnlyCollection<ProfessorTurma> ProfessorTurma { get; set; }
    }
}
