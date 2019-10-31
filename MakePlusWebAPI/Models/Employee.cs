using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MakePlusWebAPI.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }

        public string Name { get; set; }
        public double Salary { get; set; }

        public IList<EmployeeAssignment> EmployeeAssignments { get; set; }

        //public IList<Workload> Workload { get; set; }

        public Employee(int employeeId, string name, double salary)
        {
            this.EmployeeId = employeeId;
            this.Name = name;
            this.Salary = salary;
        }
    }
}
