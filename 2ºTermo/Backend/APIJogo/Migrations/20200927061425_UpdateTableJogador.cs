using Microsoft.EntityFrameworkCore.Migrations;

namespace APIJogo.Migrations
{
    public partial class UpdateTableJogador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JogosJogador_Jogador_IdJogador",
                table: "JogosJogador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jogador",
                table: "Jogador");

            migrationBuilder.RenameTable(
                name: "Jogador",
                newName: "Jogadores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jogadores",
                table: "Jogadores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JogosJogador_Jogadores_IdJogador",
                table: "JogosJogador",
                column: "IdJogador",
                principalTable: "Jogadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JogosJogador_Jogadores_IdJogador",
                table: "JogosJogador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jogadores",
                table: "Jogadores");

            migrationBuilder.RenameTable(
                name: "Jogadores",
                newName: "Jogador");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jogador",
                table: "Jogador",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JogosJogador_Jogador_IdJogador",
                table: "JogosJogador",
                column: "IdJogador",
                principalTable: "Jogador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
