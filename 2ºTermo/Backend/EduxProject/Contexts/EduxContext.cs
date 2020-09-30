using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EduxProject.Domains;

namespace EduxProject.Contexts
{
    public partial class EduxContext : DbContext
    {
        public EduxContext()
        {
        }

        public EduxContext(DbContextOptions<EduxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlunosTurmas> AlunosTurmas { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Curtidas> Curtidas { get; set; }
        public virtual DbSet<Dicas> Dicas { get; set; }
        public virtual DbSet<Instituicoes> Instituicoes { get; set; }
        public virtual DbSet<Objetivos> Objetivos { get; set; }
        public virtual DbSet<ObjetivosAlunos> ObjetivosAlunos { get; set; }
        public virtual DbSet<Perfils> Perfils { get; set; }
        public virtual DbSet<ProfessoresTurmas> ProfessoresTurmas { get; set; }
        public virtual DbSet<Turmas> Turmas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Edux;User ID=sa;Password=sa132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunosTurmas>(entity =>
            {
                entity.Property(e => e.Matricula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.AlunosTurmas)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__AlunosTur__IdTur__5165187F");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AlunosTurmas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__AlunosTur__IdUsu__5070F446");
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__Cursos__IdInstit__398D8EEE");
            });

            modelBuilder.Entity<Curtidas>(entity =>
            {
                entity.HasOne(d => d.IdDicaNavigation)
                    .WithMany(p => p.Curtidas)
                    .HasForeignKey(d => d.IdDica)
                    .HasConstraintName("FK__Curtidas__IdDica__4CA06362");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Curtidas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Curtidas__IdUsua__4D94879B");
            });

            modelBuilder.Entity<Dicas>(entity =>
            {
                entity.Property(e => e.Imagem)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Texto)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Dicas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Dicas__IdUsuario__49C3F6B7");
            });

            modelBuilder.Entity<Instituicoes>(entity =>
            {
                entity.Property(e => e.Bairro)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Objetivos>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Objetivos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Objetivos__IdCat__412EB0B6");
            });

            modelBuilder.Entity<ObjetivosAlunos>(entity =>
            {
                entity.Property(e => e.DataAlcancado).HasColumnType("datetime");

                entity.Property(e => e.Nota).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdAlunoTurmaNavigation)
                    .WithMany(p => p.ObjetivosAlunos)
                    .HasForeignKey(d => d.IdAlunoTurma)
                    .HasConstraintName("FK__Objetivos__IdAlu__59FA5E80");

                entity.HasOne(d => d.IdObjetivoNavigation)
                    .WithMany(p => p.ObjetivosAlunos)
                    .HasForeignKey(d => d.IdObjetivo)
                    .HasConstraintName("FK__Objetivos__IdObj__5AEE82B9");
            });

            modelBuilder.Entity<Perfils>(entity =>
            {
                entity.Property(e => e.Permissao)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfessoresTurmas>(entity =>
            {
                entity.Property(e => e.Matricula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.ProfessoresTurmas)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__Professor__IdTur__5535A963");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ProfessoresTurmas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Professor__IdUsu__5441852A");
            });

            modelBuilder.Entity<Turmas>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Turmas)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__Turmas__IdCurso__3C69FB99");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataUltimoAcesso).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK__Usuarios__IdPerf__46E78A0C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
