using CodeTur.Dominio.Domains;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Infra.Data.Contexts
{
    /// <summary>
    /// Classe responsável por configurar a conexão com o banco de dados e os objetos
    /// </summary>
    public class CodeTurContext : DbContext
    {
        public CodeTurContext(DbContextOptions<CodeTurContext> options) : base(options)
        {
        } 

        //Declarando as tabelas do banco de dados
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            #region Mapeamento da tabela de Usuários

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            //Definindo o paramatro de 'Id'
            modelBuilder.Entity<Usuario>().Property(usr => usr.Id);

            //Definindo o parametro de 'Nome'
            modelBuilder.Entity<Usuario>().Property(usr => usr.Nome).HasMaxLength(50);
            modelBuilder.Entity<Usuario>().Property(usr => usr.Nome).HasColumnType("varchar(50)");
            modelBuilder.Entity<Usuario>().Property(usr => usr.Nome).IsRequired();

            //Definindo o parametro de 'Email'
            modelBuilder.Entity<Usuario>().Property(usr => usr.Email).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(usr => usr.Email).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(usr => usr.Email).IsRequired();

            //Definindo o parametro de 'Senha'
            modelBuilder.Entity<Usuario>().Property(usr => usr.Senha).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(usr => usr.Senha).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(usr => usr.Senha).IsRequired();

            //Definindo o parametro de 'Telefone'
            modelBuilder.Entity<Usuario>().Property(usr => usr.Telefone).HasMaxLength(11);
            modelBuilder.Entity<Usuario>().Property(usr => usr.Telefone).HasColumnType("varchar(11)");

            //Definindo o parametro de 'DataCriacao'
            modelBuilder.Entity<Usuario>().Property(usr => usr.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");

            //Definindo o parametro de 'DataAlteracao'
            modelBuilder.Entity<Usuario>().Property(usr => usr.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");

            //Definindo o parametro de relação com os comentários
            modelBuilder.Entity<Usuario>().HasMany(cmt => cmt.Comentarios).WithOne(usr => usr.Usuario)
                            .HasForeignKey(fk => fk.IdUsuario);
            #endregion


            #region Mapeamento da tabela de Pacote

            modelBuilder.Entity<Pacote>().ToTable("Pacotes");

            //Definindo o paramatro de 'Id'
            modelBuilder.Entity<Pacote>().Property(x => x.Id);

            //Definindo o paramatro de 'Titulo'
            modelBuilder.Entity<Pacote>().Property(pct => pct.Titulo).HasMaxLength(120);
            modelBuilder.Entity<Pacote>().Property(pct => pct.Titulo).HasColumnType("varchar(120)");
            modelBuilder.Entity<Pacote>().Property(pct => pct.Titulo).IsRequired();

            //Definindo o paramatro de 'Descricao'
            modelBuilder.Entity<Pacote>().Property(pct => pct.Descricao).HasColumnType("Text");
            modelBuilder.Entity<Pacote>().Property(pct => pct.Descricao).IsRequired();

            //Definindo o paramatro de 'Imagem'
            modelBuilder.Entity<Pacote>().Property(pct => pct.Imagem).HasMaxLength(250);
            modelBuilder.Entity<Pacote>().Property(pct => pct.Imagem).HasColumnType("varchar(250)");
            modelBuilder.Entity<Pacote>().Property(pct => pct.Imagem).IsRequired();

            //Definindo o paramatro de 'Status'
            modelBuilder.Entity<Pacote>().Property(pct => pct.Ativo).HasColumnType("bit");

            //Definindo o paramatro de 'DataCriacao'
            modelBuilder.Entity<Pacote>().Property(pct => pct.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Pacote>().Property(pct => pct.DataCriacao).HasDefaultValueSql("GetDate()");

            //Definindo o paramatro de 'DataAlteracao'
            modelBuilder.Entity<Pacote>().Property(pct => pct.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Pacote>().Property(pct => pct.DataAlteracao).HasDefaultValueSql("GetDate()");

            //Definindo o parametro de relação com os comentários
            modelBuilder.Entity<Pacote>().HasMany(cmt => cmt.Comentarios).WithOne(pct => pct.Pacote)
                            .HasForeignKey(fk => fk.IdPacote);

            #endregion

            
            #region Mapeamento da tabela de Comentario
            modelBuilder.Entity<Comentario>().ToTable("Comentarios");

            //Definindo o paramatro de 'Id'
            modelBuilder.Entity<Comentario>().Property(cmt => cmt.Id);

            //Definindo o paramatro de 'Texto'
            modelBuilder.Entity<Comentario>().Property(cmt => cmt.Texto).HasMaxLength(500);
            modelBuilder.Entity<Comentario>().Property(cmt => cmt.Texto).HasColumnType("varchar(500)");
            modelBuilder.Entity<Comentario>().Property(cmt => cmt.Texto).IsRequired();

            //Definindo o paramatro de 'Sentimento'
            modelBuilder.Entity<Comentario>().Property(cmt => cmt.Sentimento).HasMaxLength(40);
            modelBuilder.Entity<Comentario>().Property(cmt => cmt.Sentimento).HasColumnType("varchar(40)");
            modelBuilder.Entity<Comentario>().Property(cmt => cmt.Sentimento).IsRequired();

            //Definindo o paramatro de 'Status'
            modelBuilder.Entity<Comentario>().Property(cmt => cmt.Status).HasColumnType("int");

            //Definindo o paramatro de 'DataCriacao'
            modelBuilder.Entity<Comentario>().Property(cmt => cmt.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Comentario>().Property(cmt => cmt.DataCriacao).HasDefaultValueSql("GetDate()");

            //Definindo o paramatro de 'DataAlteracao'
            modelBuilder.Entity<Comentario>().Property(cmt => cmt.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Comentario>().Property(cmt => cmt.DataAlteracao).HasDefaultValueSql("GetDate()");
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
