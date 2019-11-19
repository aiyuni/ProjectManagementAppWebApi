using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.HighLevelPage
{
    public class ProposalsArr
    {

        public int projectID { get; set; }
        public string projectName { get; set; }
        public string leadName { get; set; }
        public double salaryBudget { get; set; }

        public ProposalsArr()
        {

        }
        public ProposalsArr(int projId, string projName, string leadN, double salaryB)
        {
            this.projectID = projId;
            this.projectName = projName;
            this.leadName = leadN;
            this.salaryBudget = salaryB;

        }
    }
}
