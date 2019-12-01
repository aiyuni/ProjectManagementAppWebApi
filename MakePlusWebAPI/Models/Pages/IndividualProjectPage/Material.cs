using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.IndividualProjectPage
{
    /// <summary>
    /// Class that represents a Material JSON object.  In business logic, projects has material costs. 
    /// </summary>
    public class Material
    {
        public int phaseID { get; set; }
        public string phaseName { get; set; }
        public double actualBudget { get; set; }
        public double projectedBudget { get; set; }
        public string impact { get; set; }

        public Material(int id, string name, double actualBudget, double projectedBudget, string impact)
        {
            this.phaseID = id;
            this.phaseName = name;
            this.actualBudget = actualBudget;
            this.projectedBudget = projectedBudget;
            this.impact = impact;
        }
    }
}
