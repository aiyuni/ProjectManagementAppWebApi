using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models
{
    public class Phase
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PhaseId { get; set; } //PK

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; } //FK

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRecordDone { get; set; }
        public int PredictedDurationInWeeks { get; set; } //predicted duration of phase in weeks
        public int ActualDurationInWeeks { get; set; }
        public string Impact { get; set; }  //I believe this can be either HIGH, MEDIUM, LOW, NONE
        public double MaterialProjectedBudget { get; set; }
        public double MaterialActualBudget { get; set; }
        public string MaterialImpact { get; set; }

        public IList<EmployeeAssignment> EmployeeAssignments { get; set; }
        public Project Project { get; set; }
        
    }
}
