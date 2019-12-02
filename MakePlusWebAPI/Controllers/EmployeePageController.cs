using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakePlusWebAPI.Models;
using MakePlusWebAPI.Models.Pages.EmployeePage;
using MakePlusWebAPI.Models.Pages.Misc;
using MakePlusWebAPI.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MakePlusWebAPI.Controllers
{
    /**
     * A class that represents the Employee Page in the frontend.
     * Contains methods to grab and manipulate JSON objects used in that page
     */
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


        /// <summary>
        /// Gets a list of EmployeePage objects. 
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///
        ///     GET /EmployeePage
        ///     [
        ///        {
        ///             "empID": 1,
        ///             "name" : "Perry"
        ///         },
        ///          {
        ///             "empID": 2,
        ///             "name" : "Peter"
        ///         }
        ///     ]
        ///         
        /// </remarks>
        /// <returns>
        /// A list of EmployeePage objects.
        /// </returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<EmployeePage> employeePageList = new List<EmployeePage>();
            foreach (Employee e in _employeeRepository.GetAll())
            {
                EmployeePage empPage = new EmployeePage
                {
                    name = e.Name,
                    empID = e.EmployeeId,
                    wage = e.Salary
                };
                employeePageList.Add(empPage);
            }
            return Ok(employeePageList);
        }


        // POST: api/EmployeePage
        /// <summary>
        /// Adds a single Employee to the database.  See sample request for details.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///         POST /EmployeePage
        ///         {
        ///             "empID": 1,
        ///             "name" : "Perry",
        ///             "wage" : 500
        ///         }
        ///         
        /// </remarks>
        /// <param name="page">The Employee JSON</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(EmployeePage page)
        {

            Employee employee = new Employee(page.empID, page.name, page.wage);
            _employeeRepository.Add(employee);

            //Post default 6 month vacation data for the employee with hours set to 0
            //For future iterations, look into optimizing this logic, as the drawback of this logic is evident when the next month arrives.
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

            //return new OkObjectResult(200);
            return new OkObjectResult(_employeeRepository.GetAll());
        }

        /// <summary>
        /// Returns the next Employee Id in JSON format. 
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///
        ///     GET /nextEmployeeId
        ///        {
        ///             "ID": 3
        ///         }
        ///         
        /// </remarks>
        /// <returns>
        /// A JSON Object representing the next Employee Id in the database.
        /// </returns>
        [HttpGet]
        [Route("nextEmployeeId")]  //api/EmployeePage/totalEmployees
        public IActionResult GetNumberOfEmployees()
        {
            IdJson newIdJson = new IdJson(_employeeRepository.GetMaxId() + 1);
            return new OkObjectResult(newIdJson);
        }


        /**
         * Employee Page cannot Put.  
        /*
        // PUT: api/EmployeePage/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /**
        * Employee Page cannot Delete. 
        * 
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */

    }
}
