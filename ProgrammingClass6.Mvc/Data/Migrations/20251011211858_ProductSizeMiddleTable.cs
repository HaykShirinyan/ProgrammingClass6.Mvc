using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass6.Mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductSizeMiddleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductSizeMiddleTable",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductSizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizeMiddleTable", x => new { x.ProductId, x.ProductSizeId });
                    table.ForeignKey(
                        name: "FK_ProductSizeMiddleTable_ProductSizes_ProductSizeId",
                        column: x => x.ProductSizeId,
                        principalTable: "ProductSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSizeMiddleTable_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizeMiddleTable_ProductSizeId",
                table: "ProductSizeMiddleTable",
                column: "ProductSizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSizeMiddleTable");
        }
    }
}
