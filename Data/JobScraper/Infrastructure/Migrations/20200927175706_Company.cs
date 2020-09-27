using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "JobUrls");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "JobUrls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "JobUrls",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobUrls_CompanyId",
                table: "JobUrls",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobUrls_Companies_CompanyId",
                table: "JobUrls",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobUrls_Companies_CompanyId",
                table: "JobUrls");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_JobUrls_CompanyId",
                table: "JobUrls");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "JobUrls");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "JobUrls");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "JobUrls",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
