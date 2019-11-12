using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakePlusWebAPI.Models;
using MakePlusWebAPI.Models.Pages.EmployeePage;
using MakePlusWebAPI.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MakePlusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePageController : ControllerBase
    {

        private readonly IDataRepository<Employee> _employeeRepository;
        private readonly IDataRepository<Vacation> _vacationRepository;


        public EmployeePageController(IDataRepository<Employee> employeeRepository, IDataRepository<Vacation> vacationRepository){
            this._employeeRepository = employeeRepository;
            this._vacationRepository = vacationRepository;
        }


        // GET: api/EmployeePage
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_employeeRepository.GetAll());
            //System.Diagnostics.Debug.WriteLine("Not implemented GET method yet");

            //return new OkObjectResult(400);
        }



        // POST: api/EmployeePage
        [HttpPost]
        public IActionResult Post(EmployeePage page)
        {

            Employee employee = new Employee(page.empID, page.name, page.wage);
            _employeeRepository.Add(employee);


            
            for(int i = 0; i < 6; i++)
            {
                Vacation vacay = new Vacation();

                vacay.EmployeeId = page.empID;
                vacay.EmployeeName = page.name;
                vacay.Month = DateTime.Now.AddMonths(i).Month;
                vacay.Year = DateTime.Now.AddMonths(i).Year;
                vacay.Hours = 0;
                _vacationRepository.Add(vacay);
            }
            



            
            //Vacation vacation = new Vacation(page.empID, page.name, 0, 0, 0, 0, 0, 0);
            

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
        // PUT: api/EmployeePage/5
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
