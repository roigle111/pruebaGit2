using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenceDatabase.Migrations
{
    public partial class addWarehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "WarewhouseProducts",
                columns: table => new
                {
                    WarewhouseProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    WarehousrId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarewhouseProducts", x => x.WarewhouseProductId);
                    table.ForeignKey(
                        name: "FK_WarewhouseProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarewhouseProducts_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "WarehouseId", "Name" },
                values: new object[] { 1, "Sector AA" });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "WarehouseId", "Name" },
                values: new object[] { 2, "Sector BB" });

            migrationBuilder.CreateIndex(
                name: "IX_WarewhouseProducts_ProductId",
                table: "WarewhouseProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WarewhouseProducts_WarehouseId",
                table: "WarewhouseProducts",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarewhouseProducts");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
