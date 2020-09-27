using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIJogo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogador",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    DataLancamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JogosJogador",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdJogador = table.Column<Guid>(nullable: false),
                    IdJogo = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogosJogador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JogosJogador_Jogador_IdJogador",
                        column: x => x.IdJogador,
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogosJogador_Jogos_IdJogo",
                        column: x => x.IdJogo,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JogosJogador_IdJogador",
                table: "JogosJogador",
                column: "IdJogador");

            migrationBuilder.CreateIndex(
                name: "IX_JogosJogador_IdJogo",
                table: "JogosJogador",
                column: "IdJogo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JogosJogador");

            migrationBuilder.DropTable(
                name: "Jogador");

            migrationBuilder.DropTable(
                name: "Jogos");
        }
    }
}
