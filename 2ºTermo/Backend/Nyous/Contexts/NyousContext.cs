using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Nyous.Domains;

namespace Nyous.Contexts
{
    public partial class NyousContext : DbContext
    {
        public NyousContext()
        {
        }

        public NyousContext(DbContextOptions<NyousContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acesso> Acesso { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Convite> Convite { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Localizacao> Localizacao { get; set; }
        public virtual DbSet<Presenca> Presenca { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog= Nyous; User Id=sa; password=sa132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acesso>(entity =>
            {
                entity.HasKey(e => e.IdAcesso)
                    .HasName("PK__Acesso__CDF01DA1AEC06C1A");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A1092537D26");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Convite>(entity =>
            {
                entity.HasKey(e => e.IdConvite)
                    .HasName("PK__Convite__318FC5547948B07C");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Convite)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK__Convite__IdEvent__32E0915F");

                entity.HasOne(d => d.IdUsuarioConvidadoNavigation)
                    .WithMany(p => p.ConviteIdUsuarioConvidadoNavigation)
                    .HasForeignKey(d => d.IdUsuarioConvidado)
                    .HasConstraintName("FK__Convite__IdUsuar__34C8D9D1");

                entity.HasOne(d => d.IdUsuarioEmissorNavigation)
                    .WithMany(p => p.ConviteIdUsuarioEmissorNavigation)
                    .HasForeignKey(d => d.IdUsuarioEmissor)
                    .HasConstraintName("FK__Convite__IdUsuar__33D4B598");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__Evento__034EFC045A96F7CE");

                entity.Property(e => e.AcessoRestrito)
                    .HasMaxLength(1)
                    .IsFixedLength()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DataEvento).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Evento__IdCatego__2F10007B");

                entity.HasOne(d => d.IdLocalizacaoNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdLocalizacao)
                    .HasConstraintName("FK__Evento__IdLocali__2E1BDC42");
            });

            modelBuilder.Entity<Localizacao>(entity =>
            {
                entity.HasKey(e => e.IdLocalizacao)
                    .HasName("PK__Localiza__C96A5BF67A05D9A1");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Presenca>(entity =>
            {
                entity.HasKey(e => e.IdPresenca)
                    .HasName("PK__Presenca__50FB6F5DC85A0CDA");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Presenca)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK__Presenca__IdEven__38996AB5");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Presenca)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Presenca__IdUsua__398D8EEE");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF975C5B7BB3");

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAcessoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdAcesso)
                    .HasConstraintName("FK__Usuario__IdAcess__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
