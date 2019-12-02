using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models
{
    public class ProjectedWorkload
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }

        public int Month { get; set; }  //not primary keys
        public int Year { get; set; }
        public double Hours { get; set; }

        public string Row_lst_upd_ts { get; set; }
        public string Row_lst_upd_user { get; set; }

        public Project Project { get; set; }
        public Employee Employee { get; set; }

        public ProjectedWorkload()
        {
            this.Row_lst_upd_ts = DateTime.Now.ToString();
            this.Row_lst_upd_user = System.Environment.UserName;
        }

        public ProjectedWorkload(int projectId, int employeeId, int month, int year, double hours)
        {
            this.ProjectId = projectId;
            this.EmployeeId = employeeId;
            this.Month = month;
            this.Year = year;
            this.Hours = hours;
            this.Row_lst_upd_ts = DateTime.Now.ToString();
            this.Row_lst_upd_user = System.Environment.UserName;
        }
    }
}
