using Carometro.Comum.Commands;
using Carometro.Comum.Enum;
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
    public class CadastrarAlunoCommand : Notifiable, ICommand
    {

        public CadastrarAlunoCommand()
        {

        }

        public CadastrarAlunoCommand(string nomeUsuario, string email, string senha, string telefone, string rg, string cpf, string fotoAluno, DateTime dataNascAluno)
        {
            Nome = nomeUsuario;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            Rg = rg;
            Cpf = cpf;
            FotoAluno = fotoAluno;
            DataNascimento = dataNascAluno;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string FotoAluno { get; set; }
        public DateTime DataNascimento { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "NomeUsuario", "O Nome deve ter no mínimo 3 caractéres")
                .HasMaxLen(Nome, 50, "NomeUsuario", "O Nome deve ter no máximo 50 caractéres")
                .IsEmail(Email, "Email", "Informe um Email válido")
                .IsNewFormatCellPhone(Telefone, "Telefone", "Insira um Número de Telefone Válido")
                .HasMinLen(Senha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres")
                .HasMinLen(Rg, 9, "Rg", "O RG deve conter no mínimo 9 caractéres")
                .HasMaxLen(Rg, 9, "Rg", "O RG deve conter no máximo 9 caractéres")
                .HasMinLen(Cpf, 11, "Cpf", "O CPF deve conter 11 caractéres")
                .HasMaxLen(Cpf, 11, "Cpf", "O CPF deve conter 11 caractéres")
            );
        }
    }
}
