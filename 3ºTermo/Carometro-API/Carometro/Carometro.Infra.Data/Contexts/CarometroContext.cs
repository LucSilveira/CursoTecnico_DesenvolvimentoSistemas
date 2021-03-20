using Carometro.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Infra.Data.Contexts
{
    public class CarometroContext : DbContext
    {

        public CarometroContext(DbContextOptions<CarometroContext> options) : base(options)
        {
                
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<AlunoTurma> AlunosTurmas { get; set; }
        public DbSet<ProfessorTurma> ProfessoresTurmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Mapeamento da Tabela - Admin

            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Admin>().Property(x => x.Id);

            //Nome
            modelBuilder.Entity<Admin>().Property(x => x.NomeUsuario).HasMaxLength(50);
            modelBuilder.Entity<Admin>().Property(x => x.NomeUsuario).HasColumnType("varchar(50)");
            modelBuilder.Entity<Admin>().Property(x => x.NomeUsuario).IsRequired();

            //Email
            modelBuilder.Entity<Admin>().Property(x => x.Email).HasMaxLength(60);
            modelBuilder.Entity<Admin>().Property(x => x.Email).HasColumnType("varchar(60)");
            modelBuilder.Entity<Admin>().Property(x => x.Email).IsRequired();

            //Senha
            modelBuilder.Entity<Admin>().Property(x => x.Senha).HasMaxLength(60);
            modelBuilder.Entity<Admin>().Property(x => x.Senha).HasColumnType("varchar(60)");
            modelBuilder.Entity<Admin>().Property(x => x.Senha).IsRequired();

            //Telefone
            modelBuilder.Entity<Admin>().Property(x => x.Telefone).HasMaxLength(11);
            modelBuilder.Entity<Admin>().Property(x => x.Telefone).HasColumnType("varchar(11)");

            //Data da Criação
            modelBuilder.Entity<Admin>().Property(d => d.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Admin>().Property(d => d.DataCriacao).HasDefaultValueSql("GetDate()");

            //Data de Alteração
            modelBuilder.Entity<Admin>().Property(d => d.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Admin>().Property(d => d.DataAlteracao).HasDefaultValueSql("GetDate()");
            #endregion


            #region Mapeamento da Tabela - Aluno

            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Aluno>().Property(x => x.Id);

            //Nome
            modelBuilder.Entity<Aluno>().Property(x => x.NomeUsuario).HasMaxLength(50);
            modelBuilder.Entity<Aluno>().Property(x => x.NomeUsuario).HasColumnType("varchar(50)");
            modelBuilder.Entity<Aluno>().Property(x => x.NomeUsuario).IsRequired();

            //Email
            modelBuilder.Entity<Aluno>().Property(x => x.Email).HasMaxLength(60);
            modelBuilder.Entity<Aluno>().Property(x => x.Email).HasColumnType("varchar(60)");
            modelBuilder.Entity<Aluno>().Property(x => x.Email).IsRequired();

            //Senha
            modelBuilder.Entity<Aluno>().Property(x => x.Senha).HasMaxLength(60);
            modelBuilder.Entity<Aluno>().Property(x => x.Senha).HasColumnType("varchar(60)");
            modelBuilder.Entity<Aluno>().Property(x => x.Senha).IsRequired();

            //Telefone
            modelBuilder.Entity<Aluno>().Property(x => x.Telefone).HasMaxLength(11);
            modelBuilder.Entity<Aluno>().Property(x => x.Telefone).HasColumnType("varchar(11)");

            //RG
            modelBuilder.Entity<Aluno>().Property(x => x.Rg).HasMaxLength(9);
            modelBuilder.Entity<Aluno>().Property(x => x.Rg).HasColumnType("varchar(9)");
            modelBuilder.Entity<Aluno>().Property(x => x.Rg).IsRequired();

            //CPF
            modelBuilder.Entity<Aluno>().Property(x => x.Cpf).HasMaxLength(11);
            modelBuilder.Entity<Aluno>().Property(x => x.Cpf).HasColumnType("varchar(11)");
            modelBuilder.Entity<Aluno>().Property(x => x.Cpf).IsRequired();

            //FotoAluno
            modelBuilder.Entity<Aluno>().Property(x => x.FotoAluno).HasMaxLength(255);
            modelBuilder.Entity<Aluno>().Property(x => x.FotoAluno).HasColumnType("varchar(255)");
            modelBuilder.Entity<Aluno>().Property(x => x.FotoAluno).IsRequired();

            //DataNascAluno
            modelBuilder.Entity<Aluno>().Property(d => d.DataNascAluno).HasColumnType("DateTime");
            modelBuilder.Entity<Aluno>().Property(d => d.DataNascAluno).HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Aluno>().Property(x => x.DataNascAluno).IsRequired();

            //Data da Criação
            modelBuilder.Entity<Aluno>().Property(d => d.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Aluno>().Property(d => d.DataCriacao).HasDefaultValueSql("GetDate()");

            //Data de Alteração
            modelBuilder.Entity<Aluno>().Property(d => d.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Aluno>().Property(d => d.DataAlteracao).HasDefaultValueSql("GetDate()");

            //Relacionamento com a tabela de AlunoTurma
            modelBuilder.Entity<Aluno>().HasMany(x => x.AlunoTurma).WithOne(t => t.Aluno).HasForeignKey(fk => fk.IdAluno);
            #endregion


            #region Mapeamento da Tabela - Professor

            modelBuilder.Entity<Professor>().ToTable("Professor");
            modelBuilder.Entity<Professor>().Property(x => x.Id);

            //Nome
            modelBuilder.Entity<Professor>().Property(x => x.NomeUsuario).HasMaxLength(50);
            modelBuilder.Entity<Professor>().Property(x => x.NomeUsuario).HasColumnType("varchar(50)");
            modelBuilder.Entity<Professor>().Property(x => x.NomeUsuario).IsRequired();

            //Email
            modelBuilder.Entity<Professor>().Property(x => x.Email).HasMaxLength(60);
            modelBuilder.Entity<Professor>().Property(x => x.Email).HasColumnType("varchar(60)");
            modelBuilder.Entity<Professor>().Property(x => x.Email).IsRequired();

            //Senha
            modelBuilder.Entity<Professor>().Property(x => x.Senha).HasMaxLength(60);
            modelBuilder.Entity<Professor>().Property(x => x.Senha).HasColumnType("varchar(60)");
            modelBuilder.Entity<Professor>().Property(x => x.Senha).IsRequired();

            //Telefone
            modelBuilder.Entity<Professor>().Property(x => x.Telefone).HasMaxLength(11);
            modelBuilder.Entity<Professor>().Property(x => x.Telefone).HasColumnType("varchar(11)");

            //FotoProfessor
            modelBuilder.Entity<Professor>().Property(x => x.FotoProfessor).HasMaxLength(255);
            modelBuilder.Entity<Professor>().Property(x => x.FotoProfessor).HasColumnType("varchar(255)");
            modelBuilder.Entity<Professor>().Property(x => x.FotoProfessor).IsRequired();

            //Data da Criação
            modelBuilder.Entity<Professor>().Property(d => d.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Professor>().Property(d => d.DataCriacao).HasDefaultValueSql("GetDate()");

            //Data de Alteração
            modelBuilder.Entity<Professor>().Property(d => d.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Professor>().Property(d => d.DataAlteracao).HasDefaultValueSql("GetDate()");

            //Relacionamento com a tabela de ProfessorTurma
            modelBuilder.Entity<Professor>().HasMany(x => x.ProfessorTurma).WithOne(t => t.Professor).HasForeignKey(fk => fk.IdProfessor);

            #endregion

            #region Mapeamento da Tabela - Turmas

            modelBuilder.Entity<Turma>().ToTable("Turma");
            modelBuilder.Entity<Turma>().Property(x => x.Id);

            //Titulo
            modelBuilder.Entity<Turma>().Property(x => x.Titulo).HasMaxLength(50);
            modelBuilder.Entity<Turma>().Property(x => x.Titulo).HasColumnType("varchar(50)");
            modelBuilder.Entity<Turma>().Property(x => x.Titulo).IsRequired();

            //Descricao
            modelBuilder.Entity<Turma>().Property(x => x.Descricao).HasMaxLength(255);
            modelBuilder.Entity<Turma>().Property(x => x.Descricao).HasColumnType("varchar(255)");
            modelBuilder.Entity<Turma>().Property(x => x.Descricao).IsRequired();

            //DataIniciacao
            modelBuilder.Entity<Turma>().Property(d => d.DataIniciacao).HasColumnType("DateTime");
            modelBuilder.Entity<Turma>().Property(d => d.DataIniciacao).IsRequired();

            //DataConclusao
            modelBuilder.Entity<Turma>().Property(d => d.DataConclusao).HasColumnType("DateTime");
            modelBuilder.Entity<Turma>().Property(d => d.DataConclusao).IsRequired();

            //Relacionamento com a tabela de Turmas
            modelBuilder.Entity<Turma>().HasMany(x => x.Horarios).WithOne(t => t.Turma).HasForeignKey(fk => fk.IdTurma);

            //Relacionamento com a tabela de AlunoTurma
            modelBuilder.Entity<Turma>().HasMany(x => x.AlunoTurma).WithOne(t => t.Turma).HasForeignKey(fk => fk.IdTurma);

            //Relacionamento com a tabela de ProfessorTurma
            modelBuilder.Entity<Turma>().HasMany(x => x.ProfessorTurma).WithOne(t => t.Turma).HasForeignKey(fk => fk.IdTurma);
            #endregion


            #region Mapeamento da Tabela - Horários

            modelBuilder.Entity<Horario>().ToTable("Horario");
            modelBuilder.Entity<Horario>().Property(x => x.Id);

            //HoraInicio
            modelBuilder.Entity<Horario>().Property(x => x.HoraInicio).HasColumnType("int");
            modelBuilder.Entity<Horario>().Property(x => x.HoraInicio).IsRequired();

            //HoraTermino
            modelBuilder.Entity<Horario>().Property(x => x.HoraTermino).HasColumnType("int");
            modelBuilder.Entity<Horario>().Property(x => x.HoraTermino).IsRequired();
            #endregion


            #region Mapeamento da Tabela - AlunoTurma

            modelBuilder.Entity<AlunoTurma>().ToTable("AlunoTurma");
            modelBuilder.Entity<AlunoTurma>().Property(x => x.Id);

            //AnotacaoProfessor
            modelBuilder.Entity<AlunoTurma>().Property(x => x.AnotacaoProfessor).HasColumnType("varchar(255)");
            modelBuilder.Entity<AlunoTurma>().Property(x => x.AnotacaoProfessor).HasDefaultValueSql(null);
            #endregion


            #region Mapeamento da Tabela - ProfessorTurma

            modelBuilder.Entity<ProfessorTurma>().ToTable("ProfessorTurma");
            modelBuilder.Entity<ProfessorTurma>().Property(x => x.Id);
            #endregion

            base.OnModelCreating(modelBuilder);
        }


    }
}
