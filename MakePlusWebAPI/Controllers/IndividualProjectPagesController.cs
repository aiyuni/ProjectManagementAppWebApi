using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakePlusWebAPI.Models;
using MakePlusWebAPI.Models.Pages.IndividualProjectPage;
using MakePlusWebAPI.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MakePlusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualProjectPagesController : ControllerBase
    {

        private readonly IDataRepository<Employee> _employeeRepository;
        private readonly IDataRepository<Project> _projectRepository;

        public IndividualProjectPagesController(IDataRepository<Employee> employeeRepository, IDataRepository<Project> projectRepository)
        {
            this._employeeRepository = employeeRepository;
            this._projectRepository = projectRepository;
        }

        //GET: api/individualprojectpages
        [HttpGet]
        public IActionResult Get()
        {
            System.Diagnostics.Debug.WriteLine("Inside get method of individualProjectPages controller... which does nothing");
            return new OkObjectResult(400);
        }

        //POST: api/individualprojectpages
        [HttpPost]
        public IActionResult Post(IndividualProjectPage page)
        {
            System.Diagnostics.Debug.WriteLine("text is: " + page.ToString());
            string json = JsonConvert.SerializeObject(page);
            System.Diagnostics.Debug.WriteLine("text json is: " + json);

            Project project = new Project(page.desc, page.startDate, page.endDate, page.completion, page.progressSurveySent, page.progressSurveyResult,
                page.followupSurveySent, page.followupSurveyResult, true, 69.9);
            _projectRepository.Add(project);



            if (page == null)
            {
                return new OkObjectResult(200);
            }
            else
            {
                return new OkObjectResult(400);
            }
        }

    }
}