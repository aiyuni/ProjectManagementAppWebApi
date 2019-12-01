using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MakePlusWebAPI.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Salary = table.Column<double>(nullable: false),
                    Row_lst_upd_ts = table.Column<string>(nullable: true),
                    Row_lst_upd_user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectDescription = table.Column<string>(nullable: true),
                    ProjectStartDate = table.Column<DateTime>(nullable: false),
                    ProjectEndDate = table.Column<DateTime>(nullable: false),
                    PercentageComplete = table.Column<double>(nullable: false),
                    SalaryBudget = table.Column<double>(nullable: false),
                    TotalInvoice = table.Column<double>(nullable: false),
                    MaterialBudget = table.Column<double>(nullable: false),
                    SpentToDate = table.Column<double>(nullable: false),
                    recordStoredCompleted = table.Column<double>(nullable: false),
                    IsInProgressSurveySent = table.Column<bool>(nullable: false),
                    IsInProgressSurveyComplete = table.Column<bool>(nullable: false),
                    IsFollowUpSurveySent = table.Column<bool>(nullable: false),
                    IsFollowUpSurveyComplete = table.Column<bool>(nullable: false),
                    IsProposal = table.Column<bool>(nullable: false),
                    isUnderISO13485 = table.Column<bool>(nullable: false),
                    BusinessCode = table.Column<string>(nullable: true),
                    CostMultiplier = table.Column<double>(nullable: false),
                    EmployeeName = table.Column<string>(nullable: true),
                    Row_lst_upd_ts = table.Column<string>(nullable: true),
                    Row_lst_upd_user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    EmployeeName = table.Column<string>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Hours = table.Column<double>(nullable: false),
                    Row_lst_upd_ts = table.Column<string>(nullable: true),
                    Row_lst_upd_user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => new { x.EmployeeId, x.EmployeeName, x.Month, x.Year });
                    table.ForeignKey(
                        name: "FK_Vacations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    InvoiceName = table.Column<string>(nullable: true),
                    InvoiceTime = table.Column<DateTime>(nullable: false),
                    InvoiceAmount = table.Column<double>(nullable: false),
                    Row_lst_upd_ts = table.Column<string>(nullable: true),
                    Row_lst_upd_user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    PhaseId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsRecordDone = table.Column<bool>(nullable: false),
                    PredictedDurationInWeeks = table.Column<int>(nullable: false),
                    ActualDurationInWeeks = table.Column<int>(nullable: false),
                    Impact = table.Column<string>(nullable: true),
                    MaterialProjectedBudget = table.Column<double>(nullable: false),
                    MaterialActualBudget = table.Column<double>(nullable: false),
                    MaterialImpact = table.Column<string>(nullable: true),
                    Row_lst_upd_ts = table.Column<string>(nullable: true),
                    Row_lst_upd_user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.PhaseId);
                    table.ForeignKey(
                        name: "FK_Phases_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectedWorkloads",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Hours = table.Column<double>(nullable: false),
                    Row_lst_upd_ts = table.Column<string>(nullable: true),
                    Row_lst_upd_user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectedWorkloads", x => new { x.ProjectId, x.EmployeeId, x.Month, x.Year });
                    table.ForeignKey(
                        name: "FK_ProjectedWorkloads_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectedWorkloads_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAssignments",
                columns: table => new
                {
                    PhaseId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    SalaryMultiplier = table.Column<double>(nullable: false),
                    ProjectedHours = table.Column<double>(nullable: false),
                    ActualHours = table.Column<double>(nullable: false),
                    Impact = table.Column<string>(nullable: true),
                    IsProjectManager = table.Column<bool>(nullable: false),
                    Row_lst_upd_ts = table.Column<string>(nullable: true),
                    Row_lst_upd_user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAssignments", x => new { x.PhaseId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeeAssignments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAssignments_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "PhaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAssignments_EmployeeId",
                table: "EmployeeAssignments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Phases_ProjectId",
                table: "Phases",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectedWorkloads_EmployeeId",
                table: "ProjectedWorkloads",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAssignments");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ProjectedWorkloads");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
