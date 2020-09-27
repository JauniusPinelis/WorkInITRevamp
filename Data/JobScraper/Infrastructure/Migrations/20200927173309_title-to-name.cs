using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class titletoname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "JobUrls");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "JobUrls",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "JobUrls");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "JobUrls",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
