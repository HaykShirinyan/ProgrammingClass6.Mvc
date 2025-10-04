using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass6.Mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameNameOfUnitOfMeasureId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UnitOfMeasures",
                newName: "UnitOfMeasureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitOfMeasureId",
                table: "UnitOfMeasures",
                newName: "Id");
        }
    }
}
