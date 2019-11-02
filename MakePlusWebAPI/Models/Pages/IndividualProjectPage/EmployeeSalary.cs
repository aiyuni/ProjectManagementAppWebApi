using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MakePlusWebAPI.Models.Pages.IndividualProjectPage
{
    public class EmployeeSalary
    {
        public int empID { get; set; }
        public string empName { get; set; }
        public double wage { get; set; }
        public List<PhaseDetails> phaseDetailsList { get; set; }

        public EmployeeSalary()
        {

        }

        public EmployeeSalary(int id, string name, double wage, List<PhaseDetails> phaseList)
        {
            this.empID = id;
            this.empName = name;
            this.wage = wage;
            this.phaseDetailsList = phaseList;
        }
    }
}
