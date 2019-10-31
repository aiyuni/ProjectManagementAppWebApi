using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MakePlusWebAPI.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workloads",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    month1 = table.Column<int>(nullable: false),
                    month2 = table.Column<int>(nullable: false),
                    month3 = table.Column<int>(nullable: false),
                    month4 = table.Column<int>(nullable: false),
                    month5 = table.Column<int>(nullable: false),
                    month6 = table.Column<int>(nullable: false),
                    projectCompletion = table.Column<int>(nullable: false),
                    projectEndDate = table.Column<DateTime>(nullable: false),
                    isNonePorjectTime = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workloads", x => new { x.ProjectID, x.EmployeeID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workloads");
        }
    }
}
