using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WmBlazor.Server.Migrations
{
    public partial class CreateTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "mtownsend");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameTag",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTag", x => new { x.GamesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_GameTag_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "System Era Softworks is a small development studio led by veteran game developers headquartered in Seattle, Washington. We are currently working on our first game, Astroneer.");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A city-building game by Colossal Order");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "A cute little space exploration game");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Flight" },
                    { 2, true, "Jet" },
                    { 3, true, "Military" },
                    { 4, true, "War" },
                    { 5, true, "Shooter" },
                    { 6, true, "Arcade" },
                    { 7, true, "City Builder" },
                    { 8, true, "Simulation" },
                    { 9, true, "Building" },
                    { 10, true, "Sports" },
                    { 11, true, "Local Multiplayer" },
                    { 12, true, "Multiplayer" },
                    { 13, true, "Open World" },
                    { 14, true, "Racing" },
                    { 15, true, "Automobile Sim" },
                    { 16, true, "VR" },
                    { 17, true, "Golf" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameTag_TagsId",
                table: "GameTag",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameTag");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.UpdateData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "System Era Softworks are an indie developer famous for Astroneer");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A city-building game by Colossal Order.");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "System Era Softworks is a small development studio led by veteran game developers headquartered in Seattle, Washington. We are currently working on our first game, Astroneer.");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "PasswordHash", "PasswordSalt", "RoleId" },
                values: new object[] { "mtownsend", new byte[] { 80, 99, 109, 75, 122, 43, 101, 71, 108, 101, 112, 75, 99, 75, 48, 66, 50, 76, 115, 83, 99, 73, 110, 85, 71, 72, 52, 43, 90, 102, 47, 51, 48, 75, 117, 98, 108, 122, 51, 80, 67, 85, 48, 52, 114, 49, 104, 57, 49, 109, 43, 114, 112, 53, 75, 87, 71, 102, 74, 89, 43, 65, 113, 102, 102, 99, 113, 112, 90, 97, 85, 51, 70, 83, 98, 75, 82, 121, 70, 103, 107, 98, 49, 72, 106, 119, 61, 61 }, new byte[] { 97, 107, 87, 120, 109, 120, 85, 67, 48, 118, 114, 68, 100, 118, 66, 121, 120, 49, 76, 70, 68, 48, 114, 77, 99, 66, 73, 90, 98, 51, 54, 65, 53, 50, 75, 77, 78, 90, 57, 84, 70, 50, 50, 105, 89, 55, 103, 118, 73, 49, 65, 90, 112, 54, 82, 77, 116, 55, 71, 117, 104, 43, 83, 84, 83, 50, 47, 101, 68, 111, 120, 113, 74, 118, 109, 86, 79, 116, 83, 113, 115, 78, 54, 65, 74, 100, 54, 73, 114, 98, 120, 54, 49, 113, 106, 51, 111, 114, 76, 106, 122, 87, 110, 52, 53, 105, 90, 97, 81, 115, 53, 67, 113, 50, 118, 111, 113, 102, 122, 70, 90, 101, 87, 118, 72, 110, 68, 78, 120, 51, 52, 71, 87, 116, 104, 68, 99, 104, 84, 120, 99, 113, 113, 76, 114, 70, 69, 121, 122, 57, 76, 51, 52, 87, 83, 48, 121, 65, 54, 79, 120, 108, 52, 81, 100, 100, 56, 100, 66, 121, 89, 61 }, 2 });
        }
    }
}
