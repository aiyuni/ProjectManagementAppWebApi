using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MakePlusWebAPI.Helpers;
using MakePlusWebAPI.Models;
using MakePlusWebAPI.Models.Pages.HighLevelPage;
using MakePlusWebAPI.Models.Pages.Misc;
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
        private readonly IDataRepository<Phase> _phaseRepository;

        public HighLevelPageController(IDataRepository<Project> projectRepository, IDataRepository<Phase> phaseRepo)
        {
            this._projectRepository = projectRepository;
            this._phaseRepository = phaseRepo;
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
                        item.EmployeeName, item.ProjectStartDate, item.ProjectEndDate,
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


        /**
        * Returns a single number which is the total number of Projects in the Project table
        */
        [HttpGet]
        [Route("totalProjects")]  //api/HighLevelPage/totalProjects
        public IActionResult GetNumberOfProjects()
        {
            IdJson newIdJson = new IdJson(_projectRepository.GetAll().Count());
            return new OkObjectResult(newIdJson);
        }

        /**
        * Returns a single number which is the total number of Projects in the Project table
        */
        [HttpGet]
        [Route("totalPhases")]  //api/HighLevelPage/totalPhases
        public IActionResult GetNumberOfPhases()
        {
            IdJson newIdJson = new IdJson(_phaseRepository.GetAll().Count());
            return new OkObjectResult(newIdJson);
        }



        /**
         * High Level Page cannot Post.  This is an App feature. 
        // POST: api/HighLevelPage
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /**
         * High Level Page cannot Put. This is an App feature.
        // PUT: api/HighLevelPage/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /**
         * High Level Page cannot Delete. This is an App feature.
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
