using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Delivery.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sender_city = table.Column<string>(type: "text", nullable: false),
                    sender_address = table.Column<string>(type: "text", nullable: false),
                    receiver_city = table.Column<string>(type: "text", nullable: false),
                    receiver_address = table.Column<string>(type: "text", nullable: false),
                    cargo_weight = table.Column<double>(type: "numeric", nullable: false),
                    pickup_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "order",
                columns: new[] { "id", "cargo_weight", "pickup_date", "receiver_address", "receiver_city", "sender_address", "sender_city" },
                values: new object[] { 1, 1.3500000000000001, new DateOnly(2023, 7, 23), "Malaya Ordynka, 9", "Moscow", "Raheem Jalil, 12", "Khujand" });

            migrationBuilder.CreateIndex(
                name: "OrderIdIndex",
                table: "order",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order");
        }
    }
}
