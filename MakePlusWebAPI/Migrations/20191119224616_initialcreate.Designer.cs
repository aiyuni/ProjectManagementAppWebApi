﻿// <auto-generated />
using System;
using MakePlusWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MakePlusWebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191119224616_initialcreate")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MakePlusWebAPI.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<string>("Name");

                    b.Property<string>("Row_lst_upd_ts");

                    b.Property<string>("Row_lst_upd_user");

                    b.Property<double>("Salary");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MakePlusWebAPI.Models.EmployeeAssignment", b =>
                {
                    b.Property<int>("PhaseId");

                    b.Property<int>("EmployeeId");

                    b.Property<double>("ActualHours");

                    b.Property<string>("Impact");

                    b.Property<bool>("IsProjectManager");

                    b.Property<string>("Position");

                    b.Property<double>("ProjectedHours");

                    b.Property<string>("Row_lst_upd_ts");

                    b.Property<string>("Row_lst_upd_user");

                    b.Property<double>("SalaryMultiplier");

                    b.HasKey("PhaseId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeAssignments");
                });

            modelBuilder.Entity("MakePlusWebAPI.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("InvoiceAmount");

                    b.Property<string>("InvoiceName");

                    b.Property<DateTime>("InvoiceTime");

                    b.Property<int>("ProjectId");

                    b.Property<string>("Row_lst_upd_ts");

                    b.Property<string>("Row_lst_upd_user");

                    b.HasKey("InvoiceId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("MakePlusWebAPI.Models.Phase", b =>
                {
                    b.Property<int>("PhaseId");

                    b.Property<int>("ActualDurationInWeeks");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Impact");

                    b.Property<bool>("IsRecordDone");

                    b.Property<double>("MaterialActualBudget");

                    b.Property<string>("MaterialImpact");

                    b.Property<double>("MaterialProjectedBudget");

                    b.Property<string>("Name");

                    b.Property<int>("PredictedDurationInWeeks");

                    b.Property<int>("ProjectId");

                    b.Property<string>("Row_lst_upd_ts");

                    b.Property<string>("Row_lst_upd_user");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("PhaseId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Phases");
                });

            modelBuilder.Entity("MakePlusWebAPI.Models.Project", b =>
                {
                    b.Property<int>("ProjectId");

                    b.Property<string>("BusinessCode");

                    b.Property<double>("CostMultiplier");

                    b.Property<string>("EmployeeName");

                    b.Property<bool>("IsFollowUpSurveyComplete");

                    b.Property<bool>("IsFollowUpSurveySent");

                    b.Property<bool>("IsInProgressSurveyComplete");

                    b.Property<bool>("IsInProgressSurveySent");

                    b.Property<bool>("IsProposal");

                    b.Property<double>("MaterialBudget");

                    b.Property<double>("PercentageComplete");

                    b.Property<string>("ProjectDescription");

                    b.Property<DateTime>("ProjectEndDate");

                    b.Property<string>("ProjectName");

                    b.Property<DateTime>("ProjectStartDate");

                    b.Property<string>("Row_lst_upd_ts");

                    b.Property<string>("Row_lst_upd_user");

                    b.Property<double>("SalaryBudget");

                    b.Property<double>("SpentToDate");

                    b.Property<double>("TotalInvoice");

                    b.Property<bool>("isUnderISO13485");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("MakePlusWebAPI.Models.ProjectedWorkload", b =>
                {
                    b.Property<int>("ProjectId");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("Month");

                    b.Property<int>("Year");

                    b.Property<double>("Hours");

                    b.Property<string>("Row_lst_upd_ts");

                    b.Property<string>("Row_lst_upd_user");

                    b.HasKey("ProjectId", "EmployeeId", "Month", "Year");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ProjectedWorkloads");
                });

            modelBuilder.Entity("MakePlusWebAPI.Models.Vacation", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<string>("EmployeeName");

                    b.Property<int>("Month");

                    b.Property<int>("Year");

                    b.Property<double>("Hours");

                    b.Property<string>("Row_lst_upd_ts");

                    b.Property<string>("Row_lst_upd_user");

                    b.HasKey("EmployeeId", "EmployeeName", "Month", "Year");

                    b.ToTable("Vacations");
                });

            modelBuilder.Entity("MakePlusWebAPI.Models.EmployeeAssignment", b =>
                {
                    b.HasOne("MakePlusWebAPI.Models.Employee", "Employee")
                        .WithMany("EmployeeAssignments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MakePlusWebAPI.Models.Phase", "Phase")
                        .WithMany("EmployeeAssignments")
                        .HasForeignKey("PhaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MakePlusWebAPI.Models.Invoice", b =>
                {
                    b.HasOne("MakePlusWebAPI.Models.Project", "Project")
                        .WithMany("Invoice")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MakePlusWebAPI.Models.Phase", b =>
                {
                    b.HasOne("MakePlusWebAPI.Models.Project", "Project")
                        .WithMany("Phase")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MakePlusWebAPI.Models.ProjectedWorkload", b =>
                {
                    b.HasOne("MakePlusWebAPI.Models.Employee", "Employee")
                        .WithMany("ProjectedWorkloads")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MakePlusWebAPI.Models.Project", "Project")
                        .WithMany("ProjectedWorkloads")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MakePlusWebAPI.Models.Vacation", b =>
                {
                    b.HasOne("MakePlusWebAPI.Models.Employee", "Employee")
                        .WithMany("Vacations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
