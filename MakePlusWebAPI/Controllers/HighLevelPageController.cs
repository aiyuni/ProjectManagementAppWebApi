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

        /// <summary>
        /// Gets a list of Projects. 
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///
        ///     GET /HighLevelPage/projects
        ///     [
        ///       {
        ///          "projectID": 0,
        ///          "projectName": "ISSP",
        ///          "leadName": "Peter Ahn",
        ///          "startDate": "2019-11-06T07:26:29.638Z",
        ///          "endDate": "2019-11-26T07:26:29.638Z",
        ///          "completion": 80,
        ///          "salaryBudget": 10000,
        ///          "salaryInvoiced": 8000,
        ///          "recoredStoredCompleted": 75,
        ///          "underISO13485": true,
        ///          "businessCode": "K73.1/8731",
        ///          "progressSurveySent": true,
        ///          "progressSurveyResult": false,
        ///          "followupSurveySent": false,
        ///          "followupSurveyResult": false
        ///       },
        ///       {
        ///          "projectID": 1,
        ///          "projectName": "ISSP",
        ///          "leadName": "Perry Li",
        ///          "startDate": "2019-11-08T07:26:29.638Z",
        ///          "endDate": "2019-11-08T07:26:29.638Z",
        ///          "completion": 0,
        ///          "salaryBudget": 1000,
        ///          "salaryInvoiced": 800,
        ///          "recoredStoredCompleted": 10,
        ///          "underISO13485": false,
        ///          "businessCode": "K73.1/8731",
        ///          "progressSurveySent": false,
        ///          "progressSurveyResult": true,
        ///          "followupSurveySent": false,
        ///          "followupSurveyResult": true
        ///       }
        ///     ]
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
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


        /// <summary>
        /// Gets a list of Proposals. 
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///
        ///     GET /HighLevelPage/proposals
        ///     [
        ///       {
        ///          "projectID": 0,
        ///          "projectName": "ISSP Proposal",
        ///          "leadName": "Peter Ahn",
        ///          "salaryBudget: 9999
        ///       },
        ///       {
        ///          "projectID": 0,
        ///          "projectName": "Another Proposal",
        ///          "leadName": "Perry Li",
        ///          "salaryBudget: 11111
        ///       },
        ///     ]
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
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


        /// <summary>
        /// Returns the next Project Id in JSON format. 
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///
        ///         GET /nextProjectId
        ///         {
        ///             "ID": 3
        ///         }
        ///         
        /// </remarks>
        /// <returns>
        /// A JSON Object representing the next Project Id in the database.
        /// </returns>
        [HttpGet]
        [Route("nextProjectId")]  //api/HighLevelPage/totalProjects
        public IActionResult GetNumberOfProjects()
        {
            IdJson newIdJson = new IdJson(_projectRepository.GetMaxId()+1);
            return new OkObjectResult(newIdJson);
        }

        /// <summary>
        /// Returns the next Phase Id in JSON format. 
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///
        ///         GET /nextPhaseId
        ///         {
        ///             "ID": 3
        ///         }
        ///         
        /// </remarks>
        /// <returns>
        /// A JSON Object representing the next Phase Id in the database.
        /// </returns>
        [HttpGet]
        [Route("nextPhaseId")]  //api/HighLevelPage/totalPhases
        public IActionResult GetNextPhaseId()
        {
            IdJson newIdJson = new IdJson(_phaseRepository.GetMaxId() + 1);
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
