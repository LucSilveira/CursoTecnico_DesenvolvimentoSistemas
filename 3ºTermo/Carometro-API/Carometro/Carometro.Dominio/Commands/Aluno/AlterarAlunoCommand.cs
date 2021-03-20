using Carometro.Comum.Commands;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.Aluno
{
    public class AlterarAlunoCommand : Notifiable, ICommand
    {
        public AlterarAlunoCommand(Guid id, string nomeUsuario, string telefone, string email, string rg, string cpf, DateTime dataNascAluno, string fotoAluno)
        {
            Id = id;
            Nome = nomeUsuario;
            Email = email;
            Telefone = telefone;
            Rg = rg;
            Cpf = cpf;
            DataNascimento = dataNascAluno;
            FotoAluno = fotoAluno;
        }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "NomeUsuario", "O Nome do Aluno deve ter no mínimo 3 caractéres")
                .IsNewFormatCellPhone(Telefone, "Telefone", "Insira um Número de Telefone Válido")
                .IsEmail(Email, "Email", "Informe um Email válido")
                .HasMinLen(Rg, 9, "Rg", "O RG deve conter 9 caractéres")
                .HasMaxLen(Rg, 9, "Rg", "O RG deve conter 9 caractéres")
                .HasMinLen(Cpf, 11, "Cpf", "O CPF deve conter 11 caractéres")
                .HasMaxLen(Cpf, 11, "Cpf", "O CPF deve conter 11 caractéres")
                .IsNotNullOrEmpty(FotoAluno, "Foto do aluno", "Informe uma imagem para o aluno")
                .AreNotEquals(Id, Guid.Empty, "Id do aluno", "Informe o id do aluno")
            );
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string FotoAluno { get; set; }
    }
}
