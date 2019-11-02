using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.IndividualProjectPage
{
    public class PhaseDetails
    {
        public int phaseID { get; set; }
        public string phaseName { get; set; }
        public double budgetHr { get; set; }
        public double actualHr { get; set; }
        public string impact { get; set; }

        public PhaseDetails()
        {

        }

        public PhaseDetails(int id, string name, double budgetHr, double actualHr, string impact)
        {
            this.phaseID = id;
            this.phaseName = name;
            this.budgetHr = budgetHr;
            this.actualHr = actualHr;
            this.impact = impact;
        }
    }
}
