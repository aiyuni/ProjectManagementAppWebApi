using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.IndividualProjectPage
{
    /// <summary>
    /// Class that represents the Invoice JSON used in Individual Project Page.
    /// </summary>
    public class InvoiceArr
    {
        public double amount { get; set; }
        public DateTime date { get; set; }

        /// <summary>
        /// Constructor that takes in the amount of the invoice and invoice date.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        public InvoiceArr(double amount, DateTime date)
        {
            this.amount = amount;
            this.date = date;
        }
    }
}
