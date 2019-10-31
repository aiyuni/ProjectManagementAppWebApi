using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.MiddleLevelPage
{
    public class MiddleLevelPage
    {
        public int workloadID { get; set; }
        public int projectID { get; set; }
        public string projectName { get; set; }

        /*
        public int empID { get; set; }
        public string empName { get; set; }
        */

        public int month1 { get; set; }
        public int month2 { get; set; }
        public int month3 { get; set; }
        public int month4 { get; set; }
        public int month5 { get; set; }
        public int month6 { get; set; }
        public int projectCompletion { get; set; }
        public DateTime projectEndDate { get; set; }
        public bool isNonePorjectTime { get; set; }
    }
}
