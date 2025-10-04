using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass6.Mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class UnitOfMeasureIdFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                table: "ProductTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_UnitOfMeasureId",
                table: "ProductTypes",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_UnitOfMeasures_UnitOfMeasureId",
                table: "ProductTypes",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_UnitOfMeasures_UnitOfMeasureId",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_UnitOfMeasureId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "ProductTypes");
        }
    }
}
