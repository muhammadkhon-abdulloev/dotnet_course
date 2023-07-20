using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                name: "admin",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("cb41ac92-7eb7-4466-adc8-f664aa523e97")),
                    name = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "admin",
                columns: new[] { "id", "password_hash", "username" },
                values: new object[] { 1, "FUOWnXgFu6p2dPfBLI6Pn8Z/+F5pneWR04mWQ6I+iX8=", "test_admin" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "age", "name" },
                values: new object[,]
                {
                    { new Guid("4a0e5748-fde0-4886-91c4-ec36b6eb3a5b"), 37, "Tom" },
                    { new Guid("6e3b1f1a-c8e8-403a-b368-c7b602d1a603"), 41, "Bob" },
                    { new Guid("f16011bb-f448-47f3-8c5a-1e6fc0a636fb"), 24, "Sam" }
                });

            migrationBuilder.CreateIndex(
                name: "AdminIdIndex",
                table: "admin",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserIdIndex",
                table: "user",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
