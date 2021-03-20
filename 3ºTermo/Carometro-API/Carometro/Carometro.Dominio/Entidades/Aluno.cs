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
    public class Aluno : Usuario
    {
        public Aluno(string nomeUsuario, string telefone, string email, string senha, string rg, string cpf, DateTime dataNascAluno, string fotoAluno)
        {

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nomeUsuario, 3, "NomeUsuario", "O Nome do Aluno deve ter no mínimo 3 caractéres")
                .IsNewFormatCellPhone(telefone, "Telefone", "Insira um Número de Telefone Válido")
                .IsEmail(email, "Email", "Informe um Email válido")
                .HasMinLen(senha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres")
                .HasMinLen(rg, 9, "Rg", "O RG deve conter 9 caractéres")
                .HasMaxLen(rg, 9, "Rg", "O RG deve conter 9 caractéres")
                .HasMinLen(cpf, 11, "Cpf", "O CPF deve conter 11 caractéres")
                .HasMaxLen(cpf, 11, "Cpf", "O CPF deve conter 11 caractéres")
                .IsNotNullOrEmpty(fotoAluno, "Foto do aluno", "Informe uma imagem para o aluno")
            );

            if (Valid)
            {
                NomeUsuario = nomeUsuario;
                Email = email;
                Senha = senha;
                Telefone = telefone;
                TipoUsuario = EnTipoUsuario.Aluno;
                Rg = rg;
                Cpf = cpf;
                DataNascAluno = dataNascAluno;
                FotoAluno = fotoAluno;
                DataCriacao = DateTime.Now;
                DataAlteracao = DateTime.Now;
            }
        }

        public void AlterarAluno(string nomeUsuario, string telefone, string email, string rg, string cpf, DateTime dataNascAluno, string fotoAluno)
        {

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nomeUsuario, 3, "NomeUsuario", "O Nome do Aluno deve ter no mínimo 3 caractéres")
                .IsNewFormatCellPhone(telefone, "Telefone", "Insira um Número de Telefone Válido")
                .IsEmail(email, "Email", "Informe um Email válido")
                .HasMinLen(rg, 9, "Rg", "O RG deve conter 9 caractéres")
                .HasMaxLen(rg, 9, "Rg", "O RG deve conter 9 caractéres")
                .HasMinLen(cpf, 11, "Cpf", "O CPF deve conter 11 caractéres")
                .HasMaxLen(cpf, 11, "Cpf", "O CPF deve conter 11 caractéres")
                .IsNotNullOrEmpty(fotoAluno, "Foto do aluno", "Informe uma imagem para o aluno")
            );

            if (Valid)
            {
                NomeUsuario = nomeUsuario;
                Email = email;
                Telefone = telefone;
                TipoUsuario = EnTipoUsuario.Aluno;
                Rg = rg;
                Cpf = cpf;
                DataNascAluno = dataNascAluno;
                FotoAluno = fotoAluno;
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

        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascAluno { get; private set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile Arquivo { get; set; }
        public string FotoAluno { get; private set; }


        private readonly IList<AlunoTurma> _alunosTurmas;
        public IReadOnlyCollection<AlunoTurma> AlunoTurma { get; set; }
    }
}
