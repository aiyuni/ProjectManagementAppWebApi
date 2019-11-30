using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.EmployeePage
{
    /// <summary>
    /// Class that represents an Employee JSON used in the frontend
    /// </summary>
    public class EmployeePage
    {
        public int empID { get; set; }
        public string name { get; set; }
        public double wage { get; set; }
    }
}
