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
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Manufactures_MaufactureId",
                table: "ProductTypes");

            migrationBuilder.RenameColumn(
                name: "MaufactureId",
                table: "ProductTypes",
                newName: "ManufactureId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTypes_MaufactureId",
                table: "ProductTypes",
                newName: "IX_ProductTypes_ManufactureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Manufactures_ManufactureId",
                table: "ProductTypes",
                column: "ManufactureId",
                principalTable: "Manufactures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Manufactures_ManufactureId",
                table: "ProductTypes");

            migrationBuilder.RenameColumn(
                name: "ManufactureId",
                table: "ProductTypes",
                newName: "MaufactureId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTypes_ManufactureId",
                table: "ProductTypes",
                newName: "IX_ProductTypes_MaufactureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Manufactures_MaufactureId",
                table: "ProductTypes",
                column: "MaufactureId",
                principalTable: "Manufactures",
                principalColumn: "Id");
        }
    }
}
