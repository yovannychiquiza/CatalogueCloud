using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogueCloud.Migrations
{
    public partial class DatabaseSetup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFreeThisWeek",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFreeThisWeek",
                table: "Courses");
        }
    }
}
