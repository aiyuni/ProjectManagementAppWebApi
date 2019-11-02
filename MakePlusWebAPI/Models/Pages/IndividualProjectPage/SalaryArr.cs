using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.IndividualProjectPage
{
    public class SalaryArr
    {
        public int phaseID { get; set; }
        public int empID { get; set; }
        public string empName { get; set; }
        public double wage { get; set; }
        public double budgetHr { get; set; }
        public double budget { get; set; }

        public SalaryArr()
        {

        }
    }
}
