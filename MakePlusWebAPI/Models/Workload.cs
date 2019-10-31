using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MakePlusWebAPI.Models
{
    public class Workload
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int WorkloadID { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        
        /*
        [ForeignKey("EmployeeId")]
        public int EmployeeID { get; set; }
        
        public string Name { get; set; }
        */

        public int month1 { get; set; }
        public int month2 { get; set; }
        public int month3 { get; set; }
        public int month4 { get; set; }
        public int month5 { get; set; }
        public int month6 { get; set; }
        public int projectCompletion { get; set; }
        public DateTime projectEndDate { get; set; }
        public bool isNoneProjectTime { get; set; }


        //int projectId, string projectName, int employeeId, string name, 
        public Workload(int workloadId, int projectId, string projectName, 
            int month1, int month2, int month3, int month4, int month5, int month6, int projectCompletion,
            DateTime projectEndDate, bool isNoneProjectTime)
        {

            this.WorkloadID = workloadId;
            this.ProjectID = projectId;
            this.ProjectName = projectName;

            /*
            this.EmployeeID = employeeId;
            this.Name = name;
            */

            this.month1 = month1;
            this.month2 = month2;
            this.month3 = month3;
            this.month4 = month4;
            this.month5 = month5;
            this.month6 = month6;
            this.projectCompletion = projectCompletion;
            this.projectEndDate = projectEndDate;
            this.isNoneProjectTime = isNoneProjectTime;

        }
    }



}
