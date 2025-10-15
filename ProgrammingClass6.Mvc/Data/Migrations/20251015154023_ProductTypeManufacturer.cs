using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass6.Mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductTypeManufacturer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "ProductTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_ManufacturerId",
                table: "ProductTypes",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Manufacturers_ManufacturerId",
                table: "ProductTypes",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Manufacturers_ManufacturerId",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_ManufacturerId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "ProductTypes");
        }
    }
}
