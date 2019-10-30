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


        public EmployeePageController(IDataRepository<Employee> employeeRepository){
            this._employeeRepository = employeeRepository;
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
