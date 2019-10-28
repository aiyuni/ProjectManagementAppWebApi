using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models
{
    //for now add a submit button to each table to submit the entire table.  Any insertion/deletion(?) will actually be an upsert to the entire table, i.e bulkcopy
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public double PercentageComplete { get; set; }
        public bool IsInProgressSurveySent { get; set; }
        public bool IsInProgressSurveyComplete { get; set; }
        public bool IsFollowUpSurveySent { get; set; }
        public bool IsFollowUpSurveyComplete { get; set; }
        public bool IsProposal { get; set; }
        public double CostMultiplier { get; set; }

        public ICollection<Phase> Phase { get; set; }
        public ICollection<Invoice> Invoice { get; set; }

        public Project(int projectId, string projectName, string projectDescription, DateTime projectStartDate, DateTime projectEndDate, double percentageComplete,
            bool isInProgressSurveySent, bool isInProgressSurveyComplete,
            bool isFollowUpSurveySent, bool isFollowUpSurveyComplete, bool isProposal, double costMultiplier)
        {
            this.ProjectId = projectId;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.ProjectStartDate = projectStartDate;
            this.ProjectEndDate = projectEndDate;
            this.PercentageComplete = percentageComplete;
            this.IsFollowUpSurveySent = isFollowUpSurveySent;
            this.IsFollowUpSurveyComplete = isFollowUpSurveyComplete;
            this.IsInProgressSurveySent = isInProgressSurveySent;
            this.IsInProgressSurveyComplete = isInProgressSurveyComplete;
            this.IsProposal = isProposal;
            this.CostMultiplier = costMultiplier;
        }
    }
}
