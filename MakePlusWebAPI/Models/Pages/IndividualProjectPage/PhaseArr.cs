using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.IndividualProjectPage
{
    public class PhaseArr
    {
        public int phaseID { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool isRecordDone { get; set; }
        public int predictedDurationInWeeks { get; set; }
        public int actualDurationInWeeks { get; set; }
        public string impact { get; set; }

        public PhaseArr()
        {

        }

        public PhaseArr(int id, string name, DateTime startDate, DateTime endDate, bool isRecordDone,
            int predictedDurationInWeeks, int actualDurationInWeeks, string impact)
        {
            this.phaseID = id;
            this.name = name;
            this.startDate = startDate;
            this.endDate = endDate;
            this.isRecordDone = isRecordDone;
            this.predictedDurationInWeeks = predictedDurationInWeeks;
            this.actualDurationInWeeks = actualDurationInWeeks;
            this.impact = impact;
        }
    }
}
