using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.HighLevelPage
{
    /// <summary>
    /// Class that represents a Proposal array JSON object for the High Level Page.
    /// </summary>
    public class ProposalsArr
    {

        public int projectID { get; set; }
        public string projectName { get; set; }
        public string leadName { get; set; }
        public double salaryBudget { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProposalsArr()
        {

        }

        /// <summary>
        /// Overloaded constructor taking in its properties in its param.
        /// </summary>
        /// <param name="projId"></param>
        /// <param name="projName"></param>
        /// <param name="leadN"></param>
        /// <param name="salaryB"></param>
        public ProposalsArr(int projId, string projName, string leadN, double salaryB)
        {
            this.projectID = projId;
            this.projectName = projName;
            this.leadName = leadN;
            this.salaryBudget = salaryB;

        }
    }
}
