using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Tags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Html",
                table: "JobUrls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PortalName",
                table: "JobUrls",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobUrlTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobUrlId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobUrlTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobUrlTags_Tags_JobUrlId",
                        column: x => x.JobUrlId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobUrlTags_JobUrls_TagId",
                        column: x => x.TagId,
                        principalTable: "JobUrls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobUrlTags_JobUrlId",
                table: "JobUrlTags",
                column: "JobUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUrlTags_TagId",
                table: "JobUrlTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobUrlTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropColumn(
                name: "Html",
                table: "JobUrls");

            migrationBuilder.DropColumn(
                name: "PortalName",
                table: "JobUrls");
        }
    }
}
