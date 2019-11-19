using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MakePlusWebAPI.Helpers;
using MakePlusWebAPI.Models;
using MakePlusWebAPI.Models.Pages.HighLevelPage;
using MakePlusWebAPI.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MakePlusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighLevelPageController : ControllerBase
    {
        private readonly IDataRepository<Project> _projectRepository;

        public HighLevelPageController(IDataRepository<Project> projectRepository)
        {
            this._projectRepository = projectRepository;
        }
        
        [HttpGet]
        [Route("projects")]//GET: api/HighLevelPage/projects
        public IActionResult GetProjects()
        {
            List<ProjectsArr> projects = new List<ProjectsArr>();

            foreach(Project item in _projectRepository.GetAll())
            {
                
                if (!item.IsProposal)
                {
                    projects.Add(new ProjectsArr(item.ProjectId, item.ProjectName,
                        "item.EmployeeName", item.ProjectStartDate, item.ProjectEndDate,
                        item.PercentageComplete, item.SalaryBudget, item.TotalInvoice,
                        item.SpentToDate, item.isUnderISO13485, item.BusinessCode,
                        item.IsInProgressSurveySent, item.IsInProgressSurveyComplete,
                        item.IsFollowUpSurveySent, item.IsFollowUpSurveyComplete));
                }
                
                
            }
            return Ok(projects);
        }

        [HttpGet]
        [Route("proposals")]//GET: api/HighLevelPage/proposals
        public IActionResult GetProposals()
        {
            List<ProposalsArr> proposals = new List<ProposalsArr>();

            foreach (Project item in _projectRepository.GetAll())
            {

                if (item.IsProposal)
                {
                    proposals.Add(new ProposalsArr(item.ProjectId, item.ProjectName, item.EmployeeName, item.SalaryBudget));
                }


            }
            return Ok(proposals);
        }

        // GET: api/HighLevelPage/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        /*
        // POST: api/HighLevelPage
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/HighLevelPage/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
