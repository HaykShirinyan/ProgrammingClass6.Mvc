using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass6.Mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductSizeMiddleTableNewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizeMiddleTable_ProductSizes_ProductSizeId",
                table: "ProductSizeMiddleTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizeMiddleTable_Products_ProductId",
                table: "ProductSizeMiddleTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSizeMiddleTable",
                table: "ProductSizeMiddleTable");

            migrationBuilder.RenameTable(
                name: "ProductSizeMiddleTable",
                newName: "ProductSizeMiddleTables");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSizeMiddleTable_ProductSizeId",
                table: "ProductSizeMiddleTables",
                newName: "IX_ProductSizeMiddleTables_ProductSizeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSizeMiddleTables",
                table: "ProductSizeMiddleTables",
                columns: new[] { "ProductId", "ProductSizeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizeMiddleTables_ProductSizes_ProductSizeId",
                table: "ProductSizeMiddleTables",
                column: "ProductSizeId",
                principalTable: "ProductSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizeMiddleTables_Products_ProductId",
                table: "ProductSizeMiddleTables",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizeMiddleTables_ProductSizes_ProductSizeId",
                table: "ProductSizeMiddleTables");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizeMiddleTables_Products_ProductId",
                table: "ProductSizeMiddleTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSizeMiddleTables",
                table: "ProductSizeMiddleTables");

            migrationBuilder.RenameTable(
                name: "ProductSizeMiddleTables",
                newName: "ProductSizeMiddleTable");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSizeMiddleTables_ProductSizeId",
                table: "ProductSizeMiddleTable",
                newName: "IX_ProductSizeMiddleTable_ProductSizeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSizeMiddleTable",
                table: "ProductSizeMiddleTable",
                columns: new[] { "ProductId", "ProductSizeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizeMiddleTable_ProductSizes_ProductSizeId",
                table: "ProductSizeMiddleTable",
                column: "ProductSizeId",
                principalTable: "ProductSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizeMiddleTable_Products_ProductId",
                table: "ProductSizeMiddleTable",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
