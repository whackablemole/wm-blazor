using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WmBlazor.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Member" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "PasswordHash", "PasswordSalt", "RoleId" },
                values: new object[] { "mtownsend", new byte[] { 80, 99, 109, 75, 122, 43, 101, 71, 108, 101, 112, 75, 99, 75, 48, 66, 50, 76, 115, 83, 99, 73, 110, 85, 71, 72, 52, 43, 90, 102, 47, 51, 48, 75, 117, 98, 108, 122, 51, 80, 67, 85, 48, 52, 114, 49, 104, 57, 49, 109, 43, 114, 112, 53, 75, 87, 71, 102, 74, 89, 43, 65, 113, 102, 102, 99, 113, 112, 90, 97, 85, 51, 70, 83, 98, 75, 82, 121, 70, 103, 107, 98, 49, 72, 106, 119, 61, 61 }, new byte[] { 97, 107, 87, 120, 109, 120, 85, 67, 48, 118, 114, 68, 100, 118, 66, 121, 120, 49, 76, 70, 68, 48, 114, 77, 99, 66, 73, 90, 98, 51, 54, 65, 53, 50, 75, 77, 78, 90, 57, 84, 70, 50, 50, 105, 89, 55, 103, 118, 73, 49, 65, 90, 112, 54, 82, 77, 116, 55, 71, 117, 104, 43, 83, 84, 83, 50, 47, 101, 68, 111, 120, 113, 74, 118, 109, 86, 79, 116, 83, 113, 115, 78, 54, 65, 74, 100, 54, 73, 114, 98, 120, 54, 49, 113, 106, 51, 111, 114, 76, 106, 122, 87, 110, 52, 53, 105, 90, 97, 81, 115, 53, 67, 113, 50, 118, 111, 113, 102, 122, 70, 90, 101, 87, 118, 72, 110, 68, 78, 120, 51, 52, 71, 87, 116, 104, 68, 99, 104, 84, 120, 99, 113, 113, 76, 114, 70, 69, 121, 122, 57, 76, 51, 52, 87, 83, 48, 121, 65, 54, 79, 120, 108, 52, 81, 100, 100, 56, 100, 66, 121, 89, 61 }, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
