using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace MakePlusWebAPI.Models
{
    public class EmployeeAssignment
    {
        public int PhaseId { get; set; }
        public int EmployeeId { get; set; }

        public string Position { get; set; }
        public double SalaryMultiplier { get; set; }
        public double ProjectedHours { get; set; }
        public double ActualHours { get; set; }
        public string Impact { get; set; }
        public bool IsProjectManager { get; set; }

        public string Row_lst_upd_ts { get; set; }
        public string Row_lst_upd_user { get; set; }

        public Phase Phase { get; set; }
        public Employee Employee { get; set; }

        public EmployeeAssignment()
        {
            this.Row_lst_upd_ts = DateTime.Now.ToString();
            this.Row_lst_upd_user = System.Environment.UserName.ToString();
        }

        public EmployeeAssignment(int phaseId, int employeeId, string position, double salaryMultiplier,
            double projectedHours, double actualHours, string impact, bool isProjectManager)
        {
            this.PhaseId = phaseId;
            this.EmployeeId = employeeId;
            this.Position = position;
            this.SalaryMultiplier = salaryMultiplier;
            this.ProjectedHours = projectedHours;
            this.ActualHours = actualHours;
            this.Impact = impact;
            this.IsProjectManager = isProjectManager;

            this.Row_lst_upd_ts = DateTime.Now.ToString();
            this.Row_lst_upd_user = System.Environment.UserName.ToString();
        }
    }
}
