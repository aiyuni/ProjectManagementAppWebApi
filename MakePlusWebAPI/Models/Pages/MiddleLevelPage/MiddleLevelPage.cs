using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.MiddleLevelPage
{
    public class MiddleLevelPage
    {
        public int projectID { get; set; }
        public string projectName { get; set; }
        public int empID { get; set; }
        public string empName { get; set; }
        public double month1 { get; set; }
        public double month2 { get; set; }
        public double month3 { get; set; }
        public double month4 { get; set; }
        public double month5 { get; set; }
        public double month6 { get; set; }
        public double projectCompletion { get; set; }
        public DateTime projectEndDate { get; set; }

        public void SetMonthlyHoursWorked(int month, double hours)
        {
            switch (month)
            {
                case 1:
                    month1 = hours;
                    break;
                case 2:
                    month2 = hours;
                    break;
                case 3:
                    month3 = hours;
                    break;
                case 4:
                    month4 = hours;
                    break;
                case 5:
                    month5 = hours;
                    break;
                case 6:
                    month6 = hours;
                    break;
            }
        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            MiddleLevelPage m = (MiddleLevelPage)obj;
            if (m.empID == this.empID && m.projectID == this.projectID)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return empID;
        }
    }

}
