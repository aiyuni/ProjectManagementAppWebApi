using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.IndividualProjectPage
{
    /// <summary>
    /// Class that repreents the Workload of one Employee. Used for GET/POST in Individual Level Page.
    /// </summary>
    public class WorkloadArr
    {
        public int empID { get; set; }
        public string empName { get; set; }
        public double month1 { get; set; }
        public double month2 { get; set; }
        public double month3 { get; set; } 
        public double month4 { get; set; }
        public double month5 { get; set; }
        public double month6 { get; set; }

        public WorkloadArr()
        {

        }

        public WorkloadArr(int id, string name, double month1, double month2, double month3, double month4, double month5, double month6)
        {
            this.empID = id;
            this.empName = name;
            this.month1 = month1;
            this.month2 = month2;
            this.month3 = month3;
            this.month4 = month4;
            this.month5 = month5;
            this.month6 = month6;
        }

        public void SetSpecificMonth(int index, double value)
        {
            switch (index)
            {
                case 1:
                    month1 = value;
                    break;
                case 2:
                    month2 = value;
                    break;
                case 3:
                    month3 = value;
                    break;
                case 4:
                    month4 = value;
                    break;
                case 5:
                    month5 = value;
                    break;
                case 6:
                    month6 = value;
                    break;
                default:
                    throw new Exception("something went wrong...invalid index...");
            }
        }

        public double getHoursWorked(int monthInt)
        {
            switch (monthInt)
            {
                case 1:
                    return month1;
                case 2:
                    return month2;
                case 3:
                    return month3;
                case 4:
                    return month4;
                case 5:
                    return month5;
                case 6:
                    return month6;
                default:
                    throw new Exception("something went wrong...invalid monthInt");
            }
        }
    }
}
