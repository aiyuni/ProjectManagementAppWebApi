using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
