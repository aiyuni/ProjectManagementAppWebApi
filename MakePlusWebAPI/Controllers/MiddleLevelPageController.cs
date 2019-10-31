using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakePlusWebAPI.Models;
using MakePlusWebAPI.Models.Pages.MiddleLevelPage;
using MakePlusWebAPI.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MakePlusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiddleLevelPageController : ControllerBase
    {

        private readonly IDataRepository<Workload> _workloadRepository;

        public MiddleLevelPageController(IDataRepository<Workload> workloadRepository)
        {
            this._workloadRepository = workloadRepository;
        }


        // GET: api/MiddleLevelPage
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_workloadRepository.GetAll());
        }

        // POST: api/MiddleLevelPage
        [HttpPost]
        public IActionResult Post(MiddleLevelPage page)
        {

            Workload workload = new Workload(page.workloadID, page.projectID, page.projectName, page.month1,
                page.month2, page.month3, page.month4, page.month5, page.month6, page.projectCompletion, 
                page.projectEndDate, page.isNonePorjectTime);
            //_workloadRepository.Add(workload);
            if (page == null)
            {
                return new OkObjectResult(200);
            }
            else
            {
                return new OkObjectResult(400);
            }
        }


        /*
        // GET: api/MiddleLevelPage/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

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
        */
    }
}
