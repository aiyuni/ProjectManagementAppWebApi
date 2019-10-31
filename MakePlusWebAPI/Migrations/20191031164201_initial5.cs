using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MakePlusWebAPI.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workloads",
                columns: table => new
                {
                    WorkloadID = table.Column<int>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    month1 = table.Column<int>(nullable: false),
                    month2 = table.Column<int>(nullable: false),
                    month3 = table.Column<int>(nullable: false),
                    month4 = table.Column<int>(nullable: false),
                    month5 = table.Column<int>(nullable: false),
                    month6 = table.Column<int>(nullable: false),
                    projectCompletion = table.Column<int>(nullable: false),
                    projectEndDate = table.Column<DateTime>(nullable: false),
                    isNoneProjectTime = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workloads", x => x.WorkloadID);
                    table.ForeignKey(
                        name: "FK_Workloads_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workloads_ProjectID",
                table: "Workloads",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workloads");
        }
    }
}
