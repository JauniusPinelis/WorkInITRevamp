using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class MinMaxSalaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalaryMax",
                table: "JobUrls",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalaryMin",
                table: "JobUrls",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaryMax",
                table: "JobUrls");

            migrationBuilder.DropColumn(
                name: "SalaryMin",
                table: "JobUrls");
        }
    }
}
