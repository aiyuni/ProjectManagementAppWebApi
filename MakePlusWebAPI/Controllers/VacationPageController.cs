using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakePlusWebAPI.Models;
using MakePlusWebAPI.Models.Pages.VacationPage;
using MakePlusWebAPI.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MakePlusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationPageController : ControllerBase
    {
        private readonly IDataRepository<Vacation> _vacationRepository;

        public VacationPageController(IDataRepository<Vacation> vacationRepository)
        {
            this._vacationRepository = vacationRepository;
        }
        // GET: api/VacationPage
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_vacationRepository.GetAll());
        }

        /*
        // GET: api/VacationPage/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        */



        // POST: api/VacationPage
        [HttpPost]
        public IActionResult Post(Vacation vacay)
        {

            Vacation vacation = new Vacation();
            vacation.EmployeeId = vacay.EmployeeId;
            vacation.EmployeeName = vacay.EmployeeName;
            vacation.Year = vacay.Year;
            vacation.Month = vacay.Month;
            vacation.Hours = vacay.Hours;

            _vacationRepository.Add(vacation);


            if (vacay == null)
            {
                return new OkObjectResult(200);
            }
            else
            {
                return new OkObjectResult(400);
            }
        }


        /*
        // PUT: api/VacationPage/5
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
