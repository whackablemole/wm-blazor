using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WmBlazor.Server.Migrations
{
    public partial class AddGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceGb = table.Column<decimal>(type: "decimal(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "Name", "PriceGb" },
                values: new object[,]
                {
                    { 1, "A city-building game by Colossal Order.", "Cities Skylines", 22.99m },
                    { 2, "A space exploration game by System Era Softworks", "Astroneer", 23.79m },
                    { 3, "A combat flight simulator by BANDAI NAMCO Studios Inc.", "Ace Combat 7: Skies Unknown", 49.99m },
                    { 4, "A racing simulator by Kunos Simulazoni", "Assetto Corsa Competizione", 34.99m },
                    { 5, "A golf simulator by EA Sports. Eeeeewww", "PGA Tour 2K21", 49.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
