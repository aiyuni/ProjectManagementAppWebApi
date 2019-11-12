using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.VacationPage
{
    [JsonObject]
    public class VacationArr
    {
        public int empID { get; set; }
        public string empName { get; set; }
        public int month1 { get; set; }
        public int month2 { get; set; }
        public int month3 { get; set; }
        public int month4 { get; set; }
        public int month5 { get; set; }
        public int month6 { get; set; }

        public int getVacationHours(int monthInt)
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
        public override string ToString()
        {
            string value = "vacationArr empID: " + empID + ", empName: " + empName + ", month1: " + month1
                + ", month 2: " + month2;
            return value;
        }
    }
}
