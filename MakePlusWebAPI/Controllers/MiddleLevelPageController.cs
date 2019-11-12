using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakePlusWebAPI.Models;
using MakePlusWebAPI.Models.Pages.MiddleLevelPage;
using MakePlusWebAPI.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MakePlusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiddleLevelPageController : ControllerBase
    {

        private readonly IDataRepository<ProjectedWorkload> _workloadRepository;

        public MiddleLevelPageController(IDataRepository<ProjectedWorkload> workloadRepository)
        {
            this._workloadRepository = workloadRepository;
        }


        // GET: api/MiddleLevelPage
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_workloadRepository.GetAll());
        }


        /*
        // GET: api/MiddleLevelPage/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        */

        /*
        // POST: api/MiddleLevelPage
        [HttpPost]
        public IActionResult Post(ProjectedWorkload page)
        {
            ProjectedWorkload projectedWorkload = new ProjectedWorkload();
        }
        */

        // PUT: api/MiddleLevelPage/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
    }
}
