using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class imagedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "JobUrls",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logourl",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "JobUrls");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Logourl",
                table: "Companies");
        }
    }
}
