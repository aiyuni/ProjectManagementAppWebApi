using Microsoft.EntityFrameworkCore.Migrations;

namespace MakePlusWebAPI.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessCode",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isUnderISO13485",
                table: "Projects",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessCode",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "isUnderISO13485",
                table: "Projects");
        }
    }
}
