using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenceDatabase.Migrations
{
    public partial class addTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteredAt",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "OrderNumbers",
                columns: table => new
                {
                    Year = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNumbers", x => x.Year);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Iva = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => new { x.Year, x.Month });
                });

            migrationBuilder.InsertData(
                table: "OrderNumbers",
                columns: new[] { "Year", "Value" },
                values: new object[] { 2022, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderNumbers");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropColumn(
                name: "RegisteredAt",
                table: "Orders");
        }
    }
}
