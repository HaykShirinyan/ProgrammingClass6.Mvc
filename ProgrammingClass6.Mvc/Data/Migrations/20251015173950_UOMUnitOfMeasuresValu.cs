using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass6.Mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class UOMUnitOfMeasuresValu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureValueId",
                table: "UnitOfMeasures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasures_UnitOfMeasureValueId",
                table: "UnitOfMeasures",
                column: "UnitOfMeasureValueId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOfMeasures_UnitOfMeasureValues_UnitOfMeasureValueId",
                table: "UnitOfMeasures",
                column: "UnitOfMeasureValueId",
                principalTable: "UnitOfMeasureValues",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitOfMeasures_UnitOfMeasureValues_UnitOfMeasureValueId",
                table: "UnitOfMeasures");

            migrationBuilder.DropIndex(
                name: "IX_UnitOfMeasures_UnitOfMeasureValueId",
                table: "UnitOfMeasures");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureValueId",
                table: "UnitOfMeasures");
        }
    }
}
