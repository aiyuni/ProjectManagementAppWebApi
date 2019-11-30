using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using MakePlusWebAPI.Models;
using MakePlusWebAPI.Models.Pages.MiddleLevelPage;
using MakePlusWebAPI.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MakePlusWebAPI.Controllers
{
    /// <summary>
    /// Controller class for the Middle Level Page.  
    /// The page is read only, so there is only GET.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MiddleLevelPageController : ControllerBase
    {

        private readonly ProjectedWorkloadRepository _workloadRepository;
        private readonly IDataRepository<Project> _projectRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly IDataRepository<Phase> _phaseRepository;
        private readonly EmployeeAssignmentRepository _employeeAssignmentRepository;

        /// <summary>
        /// Constructor taking in the data manager aka repository objects.
        /// </summary>
        /// <param name="workloadRepository"></param>
        /// <param name="projectRepository"></param>
        /// <param name="employeeRepository"></param>
        /// <param name="phaseRepository"></param>
        /// <param name="employeeAssignmentRepo"></param>
        public MiddleLevelPageController(IDataRepository<ProjectedWorkload> workloadRepository, IDataRepository<Project> projectRepository, 
            IDataRepository<Employee> employeeRepository, IDataRepository<Phase> phaseRepository, IDataRepository<EmployeeAssignment> employeeAssignmentRepo)
        {
            this._workloadRepository = (ProjectedWorkloadRepository)workloadRepository;
            this._projectRepository = projectRepository;
            this._employeeRepository = (EmployeeRepository)employeeRepository;
            this._phaseRepository = phaseRepository;
            this._employeeAssignmentRepository = (EmployeeAssignmentRepository)employeeAssignmentRepo;
        }

        // GET: api/MiddleLevelPage
        [HttpGet]
        public IActionResult Get()
        {
            HashSet<MiddleLevelPage> middleLevelPageSet = new HashSet<MiddleLevelPage>();
            List<MiddleLevelPage> middleLevelPageList = new List<MiddleLevelPage>();

            DateTime currentDate = DateTime.Now;
            int startMonth = currentDate.Month;
            int startYear = currentDate.Year;

            foreach (Project project in _projectRepository.GetAll())
            {
                System.Diagnostics.Debug.Write("PHASE REPO SIZE: " + _phaseRepository.GetAll().Where(p => p.ProjectId == project.ProjectId).ToList().Count);
                foreach (Phase phase in _phaseRepository.GetAll().Where(p => p.ProjectId == project.ProjectId))
                {
                    foreach(Employee emp in _employeeRepository.GetAll())
                    {
                        MiddleLevelPage middleLevelPage = new MiddleLevelPage();  //this actually represents one json object in the middlelevelpage json array, and not the entire page

                        middleLevelPage.empID = emp.EmployeeId;
                        middleLevelPage.projectID = project.ProjectId;
                        middleLevelPage.empName = emp.Name;
                        middleLevelPage.projectCompletion = project.Percentagomplete;
                        middleLevelPage.projectEndDate = project.ProjectEndDate;
                        middleLevelPage.projectName = project.ProjectName;

                        EmployeeAssignment ea = _employeeAssignmentRepository.Get(phase.PhaseId, emp.EmployeeId);
                        if (ea == null)
                        {
                            continue;
                        }
                        for (int k = 0; k < 6; k++)
                        {
                            int currentMonth = DateTime.Now.AddMonths(k).Month;
                            int currentYear = DateTime.Now.AddMonths(k).Year;

                            ProjectedWorkload currentProjectedWorkload = _workloadRepository.Get(project.ProjectId,
                                emp.EmployeeId, currentMonth, currentYear);

                            middleLevelPage.SetMonthlyHoursWorked(k + 1, currentProjectedWorkload.Hours);
                        }
                        middleLevelPageSet.Add(middleLevelPage);
                    }
                }
            }

            return Ok(middleLevelPageSet.ToList());
        }
     
        /**
         * No Post in Middle Level Page. This is an App feature.
         * */
        /*
        // POST: api/MiddleLevelPage
        [HttpPost]
        public IActionResult Post(ProjectedWorkload page)
        {
            ProjectedWorkload projectedWorkload = new ProjectedWorkload();
        }
        */
       

        /**
         * No PUT in Middle Level Page. This is an App feature.
         * /
        // PUT: api/MiddleLevelPage/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }   
    }
}
