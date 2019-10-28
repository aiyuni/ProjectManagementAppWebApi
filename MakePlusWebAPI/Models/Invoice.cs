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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceId { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; } //FK

        public string InvoiceName { get; set; }
        public DateTime InvoiceTime { get; set; }
        public double InvoiceAmount { get; set; }

        public Project Project { get; set; }
    }
}
