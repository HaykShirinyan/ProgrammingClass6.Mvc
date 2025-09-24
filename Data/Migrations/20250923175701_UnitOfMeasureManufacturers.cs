using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass6.Mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class UnitOfMeasureManufacturers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufactureId",
                table: "UnitOfMeasures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManufactureId",
                table: "ProductTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaufactureId",
                table: "ProductTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasures_ManufactureId",
                table: "UnitOfMeasures",
                column: "ManufactureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_ManufactureId",
                table: "ProductTypes",
                column: "ManufactureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Manufactures_ManufactureId",
                table: "ProductTypes",
                column: "ManufactureId",
                principalTable: "Manufactures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOfMeasures_Manufactures_ManufactureId",
                table: "UnitOfMeasures",
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

            migrationBuilder.DropForeignKey(
                name: "FK_UnitOfMeasures_Manufactures_ManufactureId",
                table: "UnitOfMeasures");

            migrationBuilder.DropIndex(
                name: "IX_UnitOfMeasures_ManufactureId",
                table: "UnitOfMeasures");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_ManufactureId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "ManufactureId",
                table: "UnitOfMeasures");

            migrationBuilder.DropColumn(
                name: "ManufactureId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "MaufactureId",
                table: "ProductTypes");
        }
    }
}
