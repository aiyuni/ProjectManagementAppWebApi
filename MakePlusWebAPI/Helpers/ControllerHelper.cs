using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Helpers
{
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
