using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.IndividualProjectPage
{
    public class InvoiceArr
    {
        public double amount { get; set; }
        public DateTime date { get; set; }

        public InvoiceArr(double amount, DateTime date)
        {
            this.amount = amount;
            this.date = date;
        }
    }
}
