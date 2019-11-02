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

        public string Row_lst_upd_ts { get; set; }
        public string Row_lst_upd_user { get; set; }

        public IList<EmployeeAssignment> EmployeeAssignments { get; set; }
        public IList<ProjectedWorkload> ProjectedWorkloads { get; set; }

        public Employee(int employeeId, string name, double salary)
        {
            this.EmployeeId = employeeId;
            this.Name = name;
            this.Salary = salary;

            this.Row_lst_upd_ts = DateTime.Now.ToString();
            this.Row_lst_upd_user = System.Environment.UserName.ToString();
        }
    }
}
