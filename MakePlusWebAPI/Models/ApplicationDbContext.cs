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

        public DbSet<Workload> Workloads { get; set; }

       // public DbSet<EmployeeAssignment> EmployeeAssignments { get; set; }

        //Fluent API follows the Fluent Interface design pattern.  EF does it with ModelBuilder class. https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeAssignment>().HasKey(ea => new {ea.PhaseId, ea.EmployeeId});
          //  modelBuilder.Entity<EmployeeAssignment>().HasOne(ea => ea.).WithMany(bc => Phase);
            modelBuilder.Entity<Project>().HasKey(p => p.ProjectId);

            modelBuilder.Entity<Employee>().HasKey(p => p.EmployeeId);

            modelBuilder.Entity<Workload>().HasKey(p => p.WorkloadID);

        }
    }

}
