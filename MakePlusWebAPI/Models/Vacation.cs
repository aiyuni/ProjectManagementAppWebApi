using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models
{
    public class Vacation
    {

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public int Month { get; set; }  //not primary keys
        public int Year { get; set; }
        public double Hours { get; set; }

        public string Row_lst_upd_ts { get; set; }
        public string Row_lst_upd_user { get; set; }

        public Employee Employee { get; set; }

        public Vacation()
        {
            this.Row_lst_upd_ts = DateTime.Now.ToString();
            this.Row_lst_upd_user = System.Environment.UserName;
        }

    }
}
