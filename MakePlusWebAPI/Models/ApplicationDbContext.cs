using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MakePlusWebAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<EmployeeAssignment> EmployeeAssignments { get; set; }
        public DbSet<ProjectedWorkload> ProjectedWorkloads { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

        // public DbSet<EmployeeAssignment> EmployeeAssignments { get; set; }

        //Fluent API follows the Fluent Interface design pattern.  EF does it with ModelBuilder class. https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeAssignment>().HasKey(ea => new {ea.PhaseId, ea.EmployeeId});
            modelBuilder.Entity<EmployeeAssignment>().HasOne(ea => ea.Phase).WithMany(e => e.EmployeeAssignments)
                .HasForeignKey(ea => ea.PhaseId);
            modelBuilder.Entity<EmployeeAssignment>().HasOne(ea => ea.Employee).WithMany(e => e.EmployeeAssignments)
                .HasForeignKey(ea => ea.EmployeeId);
            //  modelBuilder.Entity<EmployeeAssignment>().HasOne(ea => ea.).WithMany(bc => Phase);

            modelBuilder.Entity<ProjectedWorkload>().HasKey(pw => new {pw.ProjectId, pw.EmployeeId, pw.Month, pw.Year});
            modelBuilder.Entity<ProjectedWorkload>().HasOne(pw => pw.Project).WithMany(p => p.ProjectedWorkloads)
                .HasForeignKey(pw => pw.ProjectId);
            modelBuilder.Entity<ProjectedWorkload>().HasOne(pw => pw.Employee).WithMany(p => p.ProjectedWorkloads)
                .HasForeignKey(pw => pw.EmployeeId);

            modelBuilder.Entity<Project>().HasKey(p => p.ProjectId);
            modelBuilder.Entity<Employee>().HasKey(p => p.EmployeeId);
            modelBuilder.Entity<Phase>().HasKey(p => p.PhaseId);
            modelBuilder.Entity<Invoice>().HasKey(i => i.InvoiceId);
            modelBuilder.Entity<Vacation>().HasKey(v => new { v.EmployeeId, v.EmployeeName, v.Month, v.Year });
            modelBuilder.Entity<Vacation>().HasOne(v => v.Employee).WithMany(p => p.Vacations)
                .HasForeignKey(v => v.EmployeeId);



        }
    }

}
