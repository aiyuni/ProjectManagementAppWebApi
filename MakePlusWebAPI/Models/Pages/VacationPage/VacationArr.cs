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
        public double month1 { get; set; }
        public double month2 { get; set; }
        public double month3 { get; set; }
        public double month4 { get; set; }
        public double month5 { get; set; }
        public double month6 { get; set; }

        public void SetVacationHours(int year, int month, double hours)
        {
            int monthIndex = 0;
            DateTime date = DateTime.Today;
            if(year == date.Year)
            {
                if(month >= date.Month)
                {
                    monthIndex = month - date.Month + 1;
                }
            }else if(year > date.Year)
            {
                monthIndex = month + (12 - date.Month);
            }

            switch (monthIndex)
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

                default:
                    throw new Exception("something went wrong...invalid monthInt");

            }
            
        }
        public double GetVacationHours(int monthInt)
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

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            VacationArr m = (VacationArr)obj;
            if (m.empID == this.empID
                && m.empName.Equals(this.empName) 
                && m.month1 == this.month1
                && m.month2 == this.month2
                && m.month3 == this.month3
                && m.month4 == this.month4
                && m.month5 == this.month5
                && m.month6 == this.month6)
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
