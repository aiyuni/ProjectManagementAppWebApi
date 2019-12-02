using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakePlusWebAPI.Models;
using MakePlusWebAPI.Models.Pages.VacationPage;
using MakePlusWebAPI.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


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
        /// <summary>
        /// Gets a list of Vacations for each Employee. 
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// 
        ///     GET /VacationPage
        ///     [
        ///        { 
        ///            "empID":1,
        ///            "empName":"Reneil Pascua",
        ///            "month1":0,
        ///            "month2":0,
        ///            "month3":6,
        ///            "month4":32,
        ///            "month5":23,
        ///            "month6":50
        ///        },
        ///        { 
        ///            "empID":2,
        ///            "empName":"Perry Li",
        ///            "month1":0,
        ///            "month2":0,
        ///            "month3":3,
        ///            "month4":63,
        ///            "month5":23,
        ///            "month6":23
        ///        }
        ///     ]
        ///   
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<VacationArr> vacayArr = new List<VacationArr>();

            foreach (Vacation item in _vacationRepository.GetAll())
            {
                VacationArr vacay = new VacationArr();
                vacay.empID = item.EmployeeId;
                vacay.empName = item.EmployeeName;
                foreach(Vacation item2 in _vacationRepository.GetAll())
                {
                    if(item2.EmployeeId == vacay.empID)
                    {
                        vacay.SetVacationHours(item2.Year, item2.Month, item2.Hours);
                    }
                }
                vacayArr.Add(vacay);
            }

            HashSet<VacationArr> vacaySet = new HashSet<VacationArr>();
            for(int i = 0; i < vacayArr.Count; i++)
            {
                vacaySet.Add(vacayArr.ElementAt(i));
            }

            List<VacationArr> returnVacay = new List<VacationArr>();
            for(int i = 0; i < vacaySet.Count; i++)
            {
                returnVacay.Add(vacaySet.ElementAt(i));
            }
            return Ok(returnVacay);
        }

        // POST: api/VacationPage
        /// <summary>
        /// Adds or updates Vacations for each Employee. Performs an implementation of upsert to the database.
        /// JSON format is the same as what GET returns.  See sample request for details.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /VacationPage
        ///     [
        ///        { 
        ///            "empID":1,
        ///            "empName":"Reneil Pascua",
        ///            "month1":5,
        ///            "month2":6,
        ///            "month3":7,
        ///            "month4":8,
        ///            "month5":9,
        ///            "month6":10
        ///        },
        ///        { 
        ///            "empID":2,
        ///            "empName":"Perry Li",
        ///            "month1":3,
        ///            "month2":4,
        ///            "month3":35,
        ///            "month4":23,
        ///            "month5":22,
        ///            "month6":21
        ///        }
        ///     ]
        /// </remarks>
        /// <param name="jsonArray"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(JArray jsonArray)
        {

            System.Diagnostics.Debug.WriteLine("json array to string is: " + jsonArray.ToString());
            var obj = JsonConvert.DeserializeObject<List<VacationArr>>(jsonArray.ToString());

            foreach(var item in obj)
            {
                System.Diagnostics.Debug.WriteLine("vacationArr is: " + item.ToString());
                for (int i = 0; i < 6; i++)
                {
                    Vacation vacation = new Vacation();
                    vacation.EmployeeId = item.empID;
                    vacation.EmployeeName = item.empName;
                    vacation.Month = DateTime.Now.AddMonths(i).Month;
                    vacation.Year = DateTime.Now.AddMonths(i).Year;
                    vacation.Hours = item.GetVacationHours(i + 1);
                    _vacationRepository.Add(vacation);
                }
            }
            
            return new OkObjectResult(402);
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
