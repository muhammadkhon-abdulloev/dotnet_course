using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "age", "name" },
                values: new object[,]
                {
                    { new Guid("6d456a04-4e8c-434b-9610-329e882558e4"), 41, "Bob" },
                    { new Guid("a1c60fad-a2e0-44c2-b3e8-4a91eae516d6"), 37, "Tom" },
                    { new Guid("d2fb0e85-4c76-4442-ad07-03069c72ad40"), 24, "Sam" }
                });

            migrationBuilder.CreateIndex(
                name: "UserIdIndex",
                table: "User",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
