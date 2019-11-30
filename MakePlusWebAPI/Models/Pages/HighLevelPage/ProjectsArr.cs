using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.HighLevelPage
{
    /// <summary>
    /// A class that represents a Project JSON in the frontend High Level Page.
    /// </summary>
    public class ProjectsArr
    {
        public int projectID { get; set; }
        public string projectName { get; set; }
        public string leadName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public double completion { get; set; }
        public double salaryBudget { get; set; }
        public double salaryInvoiced { get; set; }
        public double recoredStoredCompleted { get; set; }
        public bool underISO13485 { get; set; }
        public string businessCode { get; set; }
        public bool progressSurveySent { get; set; }
        public bool progressSurveyRsult { get; set; }
        public bool followupSurveySent { get; set; }
        public bool followupSurveyResult { get; set; }


        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectsArr()
        {

        }

        /// <summary>
        /// Overloaded constructor.
        /// </summary>
        /// <param name="id"> the id of the project</param>
        /// <param name="name"></param>
        /// <param name="lname"></param>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        /// <param name="comp"></param>
        /// <param name="salaryB"></param>
        /// <param name="salaryI"></param>
        /// <param name="recored"></param>
        /// <param name="ISO"></param>
        /// <param name="busiCode"></param>
        /// <param name="surveySent"></param>
        /// <param name="surveyResult"></param>
        /// <param name="followUpSurvey"></param>
        /// <param name="followUpSurveyR"></param>
        public ProjectsArr(int id, string name, string lname, DateTime sdate,
            DateTime edate, double comp, double salaryB, double salaryI, double recored, bool ISO,
            string busiCode, bool surveySent, bool surveyResult, bool followUpSurvey,
            bool followUpSurveyR)
        {
            this.projectID = id;
            this.projectName = name;
            this.leadName = lname;
            this.startDate = sdate;
            this.endDate = edate;
            this.completion = comp;
            this.salaryBudget = salaryB;
            this.salaryInvoiced = salaryI;
            this.recoredStoredCompleted = recored;
            this.underISO13485 = ISO;
            this.businessCode = busiCode;
            this.progressSurveySent = surveySent;
            this.progressSurveyRsult = surveyResult;
            this.followupSurveySent = followUpSurvey;
            this.followupSurveyResult = followUpSurveyR;
        }
    }
}
