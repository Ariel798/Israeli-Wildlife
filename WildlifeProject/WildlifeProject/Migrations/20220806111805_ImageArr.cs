using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WildlifeProject.Migrations
{
    public partial class ImageArr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Animals",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Animals");
        }
    }
}
