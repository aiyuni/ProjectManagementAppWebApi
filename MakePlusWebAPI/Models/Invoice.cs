using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MakePlusWebAPI.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; } //FK

        public string InvoiceName { get; set; }
        public DateTime InvoiceTime { get; set; }
        public double InvoiceAmount { get; set; }

        public string Row_lst_upd_ts { get; set; }
        public string Row_lst_upd_user { get; set; }

        public Project Project { get; set; }

        public Invoice()
        {

        }

        public Invoice(int projectId, string name, DateTime time, double amount)
        {
            this.ProjectId = projectId;
            this.InvoiceName = name;
            this.InvoiceTime = time;
            this.InvoiceAmount = amount;
            this.Row_lst_upd_ts = DateTime.Now.ToString();
            this.Row_lst_upd_user = System.Environment.UserName;
        }
    }
}
