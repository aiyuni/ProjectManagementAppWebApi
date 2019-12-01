using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MakePlusWebAPI.Models.Pages.IndividualProjectPage
{
    /// <summary>
    /// Class that represents an EmployeeSalary JSON object in the Individual Project Page.  Contains an Employee's data such as wage and Phases worked in.
    /// </summary>
    public class EmployeeSalary
    {
        public int empID { get; set; }
        public string empName { get; set; }
        public double wage { get; set; }
        public List<PhaseDetails> phaseDetailsList { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeSalary()
        {

        }

        /// <summary>
        /// Overloaded constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="wage"></param>
        /// <param name="phaseList"></param>
        public EmployeeSalary(int id, string name, double wage, List<PhaseDetails> phaseList)
        {
            this.empID = id;
            this.empName = name;
            this.wage = wage;
            this.phaseDetailsList = phaseList;
        }
    }
}
