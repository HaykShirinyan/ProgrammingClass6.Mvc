using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcomWebsite.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserCredentialsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCredential",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    CardNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CardHolder = table.Column<string>(type: "TEXT", nullable: false),
                    CardDate = table.Column<string>(type: "TEXT", nullable: false),
                    CardCvc = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCredential", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCredential");
        }
    }
}
