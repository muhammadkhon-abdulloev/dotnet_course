using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestApi.Migrations
{
    /// <inheritdoc />
    public partial class AdminEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("6d456a04-4e8c-434b-9610-329e882558e4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("a1c60fad-a2e0-44c2-b3e8-4a91eae516d6"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("d2fb0e85-4c76-4442-ad07-03069c72ad40"));

            migrationBuilder.RenameIndex(
                name: "UserIdIndex",
                table: "User",
                newName: "UserIdIndex1");

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "id", "password_hash", "name" },
                values: new object[] { 1, "FUOWnXgFu6p2dPfBLI6Pn8Z/+F5pneWR04mWQ6I+iX8=", "test_admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "age", "name" },
                values: new object[,]
                {
                    { new Guid("21259072-14ed-4d44-be7a-2c6cf62216ff"), 41, "Bob" },
                    { new Guid("a5461b4d-c8e2-4940-9f5b-e1d1a8f63bd3"), 37, "Tom" },
                    { new Guid("d0cc9711-7463-4575-a65c-9fe0b4f3bacc"), 24, "Sam" }
                });

            migrationBuilder.CreateIndex(
                name: "UserIdIndex",
                table: "Admin",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("21259072-14ed-4d44-be7a-2c6cf62216ff"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("a5461b4d-c8e2-4940-9f5b-e1d1a8f63bd3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("d0cc9711-7463-4575-a65c-9fe0b4f3bacc"));

            migrationBuilder.RenameIndex(
                name: "UserIdIndex1",
                table: "User",
                newName: "UserIdIndex");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "age", "name" },
                values: new object[,]
                {
                    { new Guid("6d456a04-4e8c-434b-9610-329e882558e4"), 41, "Bob" },
                    { new Guid("a1c60fad-a2e0-44c2-b3e8-4a91eae516d6"), 37, "Tom" },
                    { new Guid("d2fb0e85-4c76-4442-ad07-03069c72ad40"), 24, "Sam" }
                });
        }
    }
}
