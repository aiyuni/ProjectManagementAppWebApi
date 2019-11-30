using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Helpers
{
    /**
     *This class was made with the intention of app scaling in mind.
     *This class is not used in the current iteration of the app. 
     */ 
    public static class ControllerHelper
    {
        public static int CalculateCurrentMonth(int currentMonth, int monthsToAdjust)
        {
            int month = currentMonth + monthsToAdjust;
            if (month > 12)
            {
                return month - 12;
            }

            return month;
        }
    }
}
