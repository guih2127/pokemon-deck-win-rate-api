using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonDeckWinRateAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstPokemonExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondPokemonExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Win = table.Column<bool>(type: "bit", nullable: false),
                    FirstTurn = table.Column<bool>(type: "bit", nullable: false),
                    UsedDeckId = table.Column<int>(type: "int", nullable: false),
                    OpponentDeckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matchs_Decks_OpponentDeckId",
                        column: x => x.OpponentDeckId,
                        principalTable: "Decks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_Decks_UsedDeckId",
                        column: x => x.UsedDeckId,
                        principalTable: "Decks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_OpponentDeckId",
                table: "Matchs",
                column: "OpponentDeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_UsedDeckId",
                table: "Matchs",
                column: "UsedDeckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matchs");

            migrationBuilder.DropTable(
                name: "Decks");
        }
    }
}
