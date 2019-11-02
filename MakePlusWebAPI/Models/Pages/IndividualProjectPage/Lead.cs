using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.IndividualProjectPage
{
    public class Lead
    {
        public int empID { get; set; }
        public string name { get; set; }
        public double wage { get; set; }

        public Lead(int id, string name, double wage)
        {
            empID = id;
            this.name = name;
            this.wage = wage;
        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Lead l = (Lead) obj;
            if (l.empID == this.empID)
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
