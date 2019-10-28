﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.IndividualProjectPage
{
    public class IndividualProjectPage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string desc { get; set; }
        public double salaryBudget { get; set; }
        public double totalInvoice { get; set; }
        public double materialBudget { get; set; }
        public double spendToDate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public double completion { get; set; }
        public double recoredStoredCompleted { get; set; }  //whats this?
        public bool progressSurveyResult { get; set; }
        public bool progressSurveySent { get; set; }
        public bool followupSurveySent { get; set; }
        public bool followupSurveyResult { get; set; }
        public List<Lead> lead { get; set; }
        public List<Member> member { get; set; }
        public List<PhaseArr> phaseArr { get; set; }
        public List<WorkloadArr> workloadArr { get; set; }
        public List<SalaryArr> salaryArr { get; set; }
        public List<InvoiceArr> invoiceArr { get; set; }
        public List<Material> material { get; set; }
    }
}