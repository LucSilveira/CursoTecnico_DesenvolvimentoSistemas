using APIJogo.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJogo.Contexts
{
    public class JogosContext : DbContext
    {
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<JogosJogadores> JogosJogador { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder _optionsBuilder)
        {
            if(!_optionsBuilder.IsConfigured)
            {
                _optionsBuilder.UseSqlServer(@"Data Source=.\SqlExpress;Initial Catalog=Jogos;User Id=sa;Password=sa132");
            }

            base.OnConfiguring(_optionsBuilder);
        }
    }
}
