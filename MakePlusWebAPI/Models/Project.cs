using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;

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
        public double SalaryBudget { get; set; }
        public double TotalInvoice { get; set; }
        public double MaterialBudget { get; set; }
        public double SpentToDate { get; set; }
        public bool IsInProgressSurveySent { get; set; }
        public bool IsInProgressSurveyComplete { get; set; }
        public bool IsFollowUpSurveySent { get; set; }
        public bool IsFollowUpSurveyComplete { get; set; }
        public bool IsProposal { get; set; }
        public bool isUnderISO13485 { get; set; }
        public string BusinessCode { get; set; }
        public double CostMultiplier { get; set; }

        public string EmployeeName { get; set; }
        public string Row_lst_upd_ts { get; set; }
        public string Row_lst_upd_user { get; set; }

        public ICollection<Phase> Phase { get; set; }
        public ICollection<Invoice> Invoice { get; set; }

        public ICollection<ProjectedWorkload> ProjectedWorkloads { get; set; }

        public Project()
        {

        }

        public Project(int projectId, string projectName, string projectDescription, DateTime projectStartDate, DateTime projectEndDate, double percentageComplete,
            double salaryBudget, double totalInvoice, double materialBudget, double spentToDate, bool isInProgressSurveySent, bool isInProgressSurveyComplete,
            bool isFollowUpSurveySent, bool isFollowUpSurveyComplete, bool isProposal, double costMultiplier, bool isUnderIso13485, string businessCode, string empName)
        {
            this.ProjectId = projectId;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.ProjectStartDate = projectStartDate;
            this.ProjectEndDate = projectEndDate;
            this.PercentageComplete = percentageComplete;
            this.SalaryBudget = salaryBudget;
            this.TotalInvoice = totalInvoice;
            this.MaterialBudget = materialBudget;
            this.SpentToDate = spentToDate;
            this.IsFollowUpSurveySent = isFollowUpSurveySent;
            this.IsFollowUpSurveyComplete = isFollowUpSurveyComplete;
            this.IsInProgressSurveySent = isInProgressSurveySent;
            this.IsInProgressSurveyComplete = isInProgressSurveyComplete;
            this.IsProposal = isProposal;
            this.CostMultiplier = costMultiplier;
            this.isUnderISO13485 = isUnderIso13485;
            this.BusinessCode = businessCode;
            this.EmployeeName = empName;
            this.Row_lst_upd_ts = DateTime.Now.ToString();
            this.Row_lst_upd_user = System.Environment.UserName.ToString();
        }
    }
}
