using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Infrastructure.Persistence.Migrations;

public partial class Initial : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Name = table.Column<string>(maxLength: 200, nullable: false),
                CreatedAtUtc = table.Column<DateTime>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Products_Name",
            table: "Products",
            column: "Name");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Products");
    }
}
