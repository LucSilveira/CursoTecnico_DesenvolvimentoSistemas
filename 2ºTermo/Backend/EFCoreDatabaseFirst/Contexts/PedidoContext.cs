using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EFCoreDatabaseFirst.Domains;

namespace EFCoreDatabaseFirst.Contexts
{
    public partial class PedidoContext : DbContext
    {
        public PedidoContext()
        {
        }

        public PedidoContext(DbContextOptions<PedidoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<PedidosItens> PedidosItens { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=Db_Senai_Pedidos_Dev;User ID=sa;Password=sa132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PedidosItens>(entity =>
            {
                entity.HasIndex(e => e.IdPedido);

                entity.HasIndex(e => e.IdProduto);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidosItens)
                    .HasForeignKey(d => d.IdPedido);

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.PedidosItens)
                    .HasForeignKey(d => d.IdProduto);
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
