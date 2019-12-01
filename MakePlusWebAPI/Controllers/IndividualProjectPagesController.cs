using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MakePlusWebAPI.Helpers;
using MakePlusWebAPI.Models;
using MakePlusWebAPI.Models.Pages.IndividualProjectPage;
using MakePlusWebAPI.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MakePlusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualProjectPagesController : ControllerBase
    {

        private readonly IDataRepository<Employee> _employeeRepository;
        private readonly IDataRepository<Project> _projectRepository;
        private readonly IDataRepository<Phase> _phaseRepository;
        private readonly EmployeeAssignmentRepository _employeeAssignmentRepository;
        private readonly ProjectedWorkloadRepository _projectedWorkloadRepository;
        private readonly IDataRepository<Invoice> _invoiceRepository;

        public IndividualProjectPagesController(IDataRepository<Employee> employeeRepository, IDataRepository<Project> projectRepository, IDataRepository<Phase> phaseRepository,
            IDataRepository<EmployeeAssignment> employeeAssignmentRepository, IDataRepository<ProjectedWorkload> projectedWorkloadRepository, IDataRepository<Invoice> invoiceRepository)
        {
            this._employeeRepository = employeeRepository;
            this._projectRepository = projectRepository;
            this._phaseRepository = phaseRepository;
            this._employeeAssignmentRepository = (EmployeeAssignmentRepository)employeeAssignmentRepository;
            this._projectedWorkloadRepository = (ProjectedWorkloadRepository)projectedWorkloadRepository;
            this._invoiceRepository = invoiceRepository;
        }


        //GET: api/individualprojectpages/id
        /// <summary>
        /// Gets a single Project.
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///
        ///     GET /individualprojectpage/{id}
        ///     { 
        ///           "employeeSalaryList":[ 
        ///              { 
        ///                 "phaseDetailsList":[ 
        ///                    { 
        ///                       "phaseID":20,
        ///                       "phaseName":"consulting",
        ///                       "budgetHr":5,
        ///                       "actualHr":5,
        ///                       "impact":"no impact"
        ///                    },
        ///                    { 
        ///                       "phaseID":21,
        ///                       "phaseName":"Requirements",
        ///                       "budgetHr":10,
        ///                       "actualHr":12,
        ///                       "impact":"high impact"
        ///                    },
        ///                    { 
        ///                       "phaseID":22,
        ///                       "phaseName":"Concept",
        ///                       "budgetHr":15,
        ///                       "actualHr":15,
        ///                       "impact":"11impact"
        ///                    }
        ///                 ],
        ///                 "empID":1,
        ///                 "empName":"Peter Ahn",
        ///                 "wage":100
        ///              },
        ///              { 
        ///                 "phaseDetailsList":[ 
        ///                    { 
        ///                       "phaseID":20,
        ///                       "phaseName":"consulting",
        ///                       "budgetHr":7,
        ///                       "actualHr":7,
        ///                       "impact":"med impact"
        ///                    },
        ///                    { 
        ///                       "phaseID":21,
        ///                       "phaseName":"Requirements",
        ///                       "budgetHr":0,
        ///                       "actualHr":0,
        ///                       "impact":""
        ///                    },
        ///                    { 
        ///                       "phaseID":22,
        ///                       "phaseName":"Concept",
        ///                       "budgetHr":90,
        ///                       "actualHr":80,
        ///                       "impact":"severe impact"
        ///                    }
        ///                 ],
        ///                 "empID":2,
        ///                 "empName":"Reneil Pascua",
        ///                 "wage":100
        ///              },
        ///              { 
        ///                 "phaseDetailsList":[ 
        ///                    { 
        ///                       "phaseID":20,
        ///                       "phaseName":"consulting",
        ///                       "budgetHr":0,
        ///                       "actualHr":0,
        ///                       "impact":""
        ///                    },
        ///                    { 
        ///                       "phaseID":21,
        ///                       "phaseName":"Requirements",
        ///                       "budgetHr":0,
        ///                       "actualHr":0,
        ///                       "impact":""
        ///                    },
        ///                    { 
        ///                       "phaseID":22,
        ///                       "phaseName":"Jeff",
        ///                       "budgetHr":0,
        ///                       "actualHr":0,
        ///                       "impact":""
        ///                    }
        ///                 ],
        ///                 "empID":3,
        ///                 "empName":"Perry",
        ///                 "wage":200
        ///              }
        ///           ],
        ///           "ID":5,
        ///           "Name":"ISSP Project101",
        ///           "desc":"Web Application for project management. The clients will be able to view/edit ongoing and past projects in both high level and low level details such as but not limited to final budget of the project, completion timeline, and individual project members’ invested hours respectively.",
        ///           "salaryBudget":7551,
        ///           "totalInvoice":4183,
        ///           "materialBudget":1018,
        ///           "spendToDate":6412,
        ///           "startDate":"2019-12-26T08:00:00.000Z",
        ///           "endDate":"2019-12-31T08:00:00.000Z",
        ///           "completion":43,
        ///           "businessCode":"NA",
        ///           "costMultiplier":1.75,
        ///           "isProposal":false,
        ///           "isUnderISO13485":false,
        ///           "recoredStoredCompleted":99,
        ///           "progressSurveyRsult":true,
        ///           "progressSurveySent":true,
        ///           "followupSurveySent":true,
        ///           "followupSurveyResult":false,
        ///           "lead":[ 
        ///              { 
        ///                 "empID":1,
        ///                 "name":"Peter Ahn",
        ///                 "wage":100
        ///              }
        ///           ],
        ///           "member":[ 
        ///              { 
        ///                 "empID":2,
        ///                 "name":"Reneil Pascua",
        ///                 "wage":100
        ///              },
        ///              { 
        ///                 "empID":3,
        ///                 "name":"Perry Li",
        ///                 "wage":200
        ///              }
        ///           ],
        ///           "phaseArr":[ 
        ///              { 
        ///                 "phaseID":20,
        ///                 "name":"consulting",
        ///                 "startDate":"2019-11-16T08:00:00.000Z",
        ///                 "endDate":"2019-11-30T08:00:00.000Z",
        ///                 "isRecordDone":true,
        ///                 "predictedDurationInWeeks":20,
        ///                 "actualDurationInWeeks":25,
        ///                 "impact":"high impact"
        ///              },
        ///              { 
        ///                 "phaseID":21,
        ///                 "name":"Requirements",
        ///                 "startDate":"2019-12-01T08:00:00.000Z",
        ///                 "endDate":"2019-12-05T08:00:00.000Z",
        ///                 "isRecordDone":true,
        ///                 "predictedDurationInWeeks":"21",
        ///                 "actualDurationInWeeks":25,
        ///                 "impact":"high impact"
        ///              },
        ///              { 
        ///                 "phaseID":22,
        ///                 "name":"Concept",
        ///                 "startDate":"2019-12-06T08:00:00.000Z",
        ///                 "endDate":"2019-12-21T08:00:00.000Z",
        ///                 "isRecordDone":true,
        ///                 "predictedDurationInWeeks":20,
        ///                 "actualDurationInWeeks":25,
        ///                 "impact":"high impact"
        ///              }
        ///           ],
        ///           "workloadArr":[ 
        ///              { 
        ///                 "empID":1,
        ///                 "empName":"Peter",
        ///                 "month1":0,
        ///                 "month2":0,
        ///                 "month3":29,
        ///                 "month4":31,
        ///                 "month5":5,
        ///                 "month6":6
        ///              },
        ///              { 
        ///                 "empID":2,
        ///                 "empName":"Reneil",
        ///                 "month1":12,
        ///                 "month2":3,
        ///                 "month3":0,
        ///                 "month4":0,
        ///                 "month5":0,
        ///                 "month6":0
        ///              },
        ///              { 
        ///                 "empID":3,
        ///                 "empName":"Perry",
        ///                 "month1":10,
        ///                 "month2":9,
        ///                 "month3":8,
        ///                 "month4":7,
        ///                 "month5":6,
        ///                 "month6":99
        ///              }
        ///           ],
        ///           "invoiceArr":[ 
        ///              { 
        ///                 "amount":997,
        ///                 "date":"2019-12-02T08:00:00.000Z"
        ///              },
        ///              { 
        ///                 "amount":471,
        ///                 "date":"2019-12-12T08:00:00.000Z"
        ///              },
        ///              { 
        ///                 "amount":642,
        ///                 "date":"2019-12-22T08:00:00.000Z"
        ///              }
        ///           ],
        ///           "material":[ 
        ///              { 
        ///                 "phaseID":20,
        ///                 "phaseName":"consulting",
        ///                 "actualBudget":200,
        ///                 "projectedBudget":100,
        ///                 "impact":"over $100"
        ///              },
        ///              { 
        ///                 "phaseID":21,
        ///                 "phaseName":"Requirements",
        ///                 "actualBudget":200,
        ///                 "projectedBudget":100,
        ///                 "impact":"over $100"
        ///              },
        ///              { 
        ///                 "phaseID":22,
        ///                 "phaseName":"Concept",
        ///                 "actualBudget":200,
        ///                 "projectedBudget":100,
        ///                 "impact":"over $100"
        ///              }
        ///           ]
        ///        }
        ///
        /// 
        /// </remarks>
        /// <param name="id">
        /// The project ID as stored in the database.
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            IndividualProjectPage individualProjectPage = new IndividualProjectPage
            {
                ID = _projectRepository.Get(id).ProjectId,
                Name = _projectRepository.Get(id).ProjectName,
                desc = _projectRepository.Get(id).ProjectDescription,
                salaryBudget = _projectRepository.Get(id).SalaryBudget, 
                totalInvoice = _projectRepository.Get(id).TotalInvoice,
                materialBudget = _projectRepository.Get(id).MaterialBudget,
                spendToDate = _projectRepository.Get(id).SpentToDate,
                startDate = _projectRepository.Get(id).ProjectStartDate,
                endDate = _projectRepository.Get(id).ProjectEndDate,
                completion = _projectRepository.Get(id).PercentageComplete,
                recoredStoredCompleted = _projectRepository.Get(id).recordStoredCompleted,
                progressSurveyResult = _projectRepository.Get(id).IsInProgressSurveyComplete,
                progressSurveySent = _projectRepository.Get(id).IsInProgressSurveySent,
                followupSurveyResult = _projectRepository.Get(id).IsFollowUpSurveyComplete,
                followupSurveySent = _projectRepository.Get(id).IsFollowUpSurveySent,
                isProposal = _projectRepository.Get(id).IsProposal,
                isUnderISO13485 = _projectRepository.Get(id).isUnderISO13485,
                businessCode = _projectRepository.Get(id).BusinessCode,
                costMultiplier =  _projectRepository.Get(id).CostMultiplier
            };

            HashSet<Lead> leadList = new HashSet<Lead>();
            HashSet<Member> memberList = new HashSet<Member>();
            foreach (EmployeeAssignment item in _employeeAssignmentRepository.GetAll())
            {
                if (item.IsProjectManager)
                {
                    foreach (Employee employee in _employeeRepository.GetAll())
                    {
                        if (employee.EmployeeId == item.EmployeeId)
                        {
                            leadList.Add(new Lead(item.EmployeeId, employee.Name, employee.Salary));
                        }
                    }
                    
                }
                else
                {
                    foreach (Employee employee in _employeeRepository.GetAll())
                    {
                        if (employee.EmployeeId == item.EmployeeId)
                        {
                            memberList.Add(new Member(item.EmployeeId, employee.Name, employee.Salary));
                        }
                    }
                }
            }
            individualProjectPage.lead = leadList.ToList();
            individualProjectPage.member = memberList.ToList();

            individualProjectPage.phaseArr = new List<PhaseArr>();

            foreach(Phase phase in _phaseRepository.GetAll())
            {
                if(phase.ProjectId == id)
                {
                    individualProjectPage.phaseArr.Add(new PhaseArr(phase.PhaseId, phase.Name, phase.StartDate,
                        phase.EndDate, phase.IsRecordDone, phase.PredictedDurationInWeeks, phase.ActualDurationInWeeks,
                        phase.Impact));
                }
            }

            individualProjectPage.workloadArr = new List<WorkloadArr>();
            WorkloadArr currentWorkloadArr = new WorkloadArr();

            foreach(Project proj in _projectRepository.GetAll())
            {
                if(proj.ProjectId == id)
                {
                    foreach(Employee emp in _employeeRepository.GetAll())
                    {
                        ProjectedWorkload currentProjectedWorkload = _projectedWorkloadRepository.Get(proj, emp, DateTime.Now.Month,
                            DateTime.Now.Year);
                        if(currentProjectedWorkload != null)
                        {
                            for (int k = 0; k < 6; k++)
                            {
                                int currentMonth = DateTime.Now.AddMonths(k).Month;
                                int currentYear = DateTime.Now.AddMonths(k).Year;

                                if (emp.EmployeeId == _projectedWorkloadRepository
                                        .Get(proj, emp, currentMonth, currentYear).EmployeeId
                                    && proj.ProjectId == _projectedWorkloadRepository
                                        .Get(proj, emp, currentMonth, currentYear).ProjectId)
                                {
                                    currentWorkloadArr.empID = emp.EmployeeId;
                                    currentWorkloadArr.empName = emp.Name;
                                    currentWorkloadArr.SetSpecificMonth(k + 1, _projectedWorkloadRepository
                                        .Get(proj, emp, currentMonth, currentYear).Hours);
                                }
                            }
                            individualProjectPage.workloadArr.Add(new WorkloadArr(currentWorkloadArr.empID, currentWorkloadArr.empName, currentWorkloadArr.month1, currentWorkloadArr.month2,
                               currentWorkloadArr.month3, currentWorkloadArr.month4, currentWorkloadArr.month5, currentWorkloadArr.month6));
                        }
                    }
                }
            }

            individualProjectPage.invoiceArr = new List<InvoiceArr>();
            foreach (Invoice i in _invoiceRepository.GetAll())
            {
                if (i.ProjectId == id)
                {
                    individualProjectPage.invoiceArr.Add(new InvoiceArr(i.InvoiceAmount, i.InvoiceTime));
                }
            }

            individualProjectPage.material = new List<Material>();

            foreach (Phase phase in _phaseRepository.GetAll())
            {
                if (phase.ProjectId == id)
                {
                    individualProjectPage.material.Add(new Material(phase.PhaseId, phase.Name, phase.MaterialActualBudget,
                        phase.MaterialProjectedBudget, phase.MaterialImpact));
                }
            }

            individualProjectPage.employeeSalaryList = new List<EmployeeSalary>();

            foreach(Employee emp in _employeeRepository.GetAll())
            {
                List<PhaseDetails> phaseDetailsList = new List<PhaseDetails>();
                foreach(Phase phase in _phaseRepository.GetAll())
                {
                    if(phase.ProjectId == id && _employeeAssignmentRepository.Get(phase.PhaseId, emp.EmployeeId) != null)
                    {
                        EmployeeAssignment currentEmployeeAssignment = _employeeAssignmentRepository.Get(phase.PhaseId, emp.EmployeeId);
                        phaseDetailsList.Add(new PhaseDetails(phase.PhaseId, phase.Name, currentEmployeeAssignment.ProjectedHours, 
                            currentEmployeeAssignment.ActualHours, currentEmployeeAssignment.Impact));
                    }
                }
                if (phaseDetailsList.Count != 0)  //to prevent all the employees from being added to the employeeSalaryList.  Only employees that are working on the project will be added. 
                {
                    individualProjectPage.employeeSalaryList.Add(new EmployeeSalary(emp.EmployeeId, emp.Name, emp.Salary, phaseDetailsList));
                }
            }
            
            return Ok(individualProjectPage);
        }

        //POST: api/individualprojectpages
        /// <summary>
        /// Adds or updates a project. Performs an implementation of Upsert in the database. JSON format is the same as what GET returns.  See sample request for details.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /individualprojectpage/{id}
        ///     { 
        ///           "employeeSalaryList":[ 
        ///              { 
        ///                 "phaseDetailsList":[ 
        ///                    { 
        ///                       "phaseID":20,
        ///                       "phaseName":"consulting",
        ///                       "budgetHr":5,
        ///                       "actualHr":5,
        ///                       "impact":"no impact"
        ///                    },
        ///                    { 
        ///                       "phaseID":21,
        ///                       "phaseName":"Requirements",
        ///                       "budgetHr":10,
        ///                       "actualHr":12,
        ///                       "impact":"high impact"
        ///                    },
        ///                    { 
        ///                       "phaseID":22,
        ///                       "phaseName":"Concept",
        ///                       "budgetHr":15,
        ///                       "actualHr":15,
        ///                       "impact":"11impact"
        ///                    }
        ///                 ],
        ///                 "empID":1,
        ///                 "empName":"Peter Ahn",
        ///                 "wage":100
        ///              },
        ///              { 
        ///                 "phaseDetailsList":[ 
        ///                    { 
        ///                       "phaseID":20,
        ///                       "phaseName":"consulting",
        ///                       "budgetHr":7,
        ///                       "actualHr":7,
        ///                       "impact":"med impact"
        ///                    },
        ///                    { 
        ///                       "phaseID":21,
        ///                       "phaseName":"Requirements",
        ///                       "budgetHr":0,
        ///                       "actualHr":0,
        ///                       "impact":""
        ///                    },
        ///                    { 
        ///                       "phaseID":22,
        ///                       "phaseName":"Concept",
        ///                       "budgetHr":90,
        ///                       "actualHr":80,
        ///                       "impact":"severe impact"
        ///                    }
        ///                 ],
        ///                 "empID":2,
        ///                 "empName":"Reneil Pascua",
        ///                 "wage":100
        ///              },
        ///              { 
        ///                 "phaseDetailsList":[ 
        ///                    { 
        ///                       "phaseID":20,
        ///                       "phaseName":"consulting",
        ///                       "budgetHr":0,
        ///                       "actualHr":0,
        ///                       "impact":""
        ///                    },
        ///                    { 
        ///                       "phaseID":21,
        ///                       "phaseName":"Requirements",
        ///                       "budgetHr":0,
        ///                       "actualHr":0,
        ///                       "impact":""
        ///                    },
        ///                    { 
        ///                       "phaseID":22,
        ///                       "phaseName":"Jeff",
        ///                       "budgetHr":0,
        ///                       "actualHr":0,
        ///                       "impact":""
        ///                    }
        ///                 ],
        ///                 "empID":3,
        ///                 "empName":"Perry",
        ///                 "wage":200
        ///              }
        ///           ],
        ///           "ID":5,
        ///           "Name":"ISSP Project101",
        ///           "desc":"Web Application for project management. The clients will be able to view/edit ongoing and past projects in both high level and low level details such as but not limited to final budget of the project, completion timeline, and individual project members’ invested hours respectively.",
        ///           "salaryBudget":7551,
        ///           "totalInvoice":4183,
        ///           "materialBudget":1018,
        ///           "spendToDate":6412,
        ///           "startDate":"2019-12-26T08:00:00.000Z",
        ///           "endDate":"2019-12-31T08:00:00.000Z",
        ///           "completion":43,
        ///           "businessCode":"NA",
        ///           "costMultiplier":1.75,
        ///           "isProposal":false,
        ///           "isUnderISO13485":false,
        ///           "recoredStoredCompleted":99,
        ///           "progressSurveyRsult":true,
        ///           "progressSurveySent":true,
        ///           "followupSurveySent":true,
        ///           "followupSurveyResult":false,
        ///           "lead":[ 
        ///              { 
        ///                 "empID":1,
        ///                 "name":"Peter Ahn",
        ///                 "wage":100
        ///              }
        ///           ],
        ///           "member":[ 
        ///              { 
        ///                 "empID":2,
        ///                 "name":"Reneil Pascua",
        ///                 "wage":100
        ///              },
        ///              { 
        ///                 "empID":3,
        ///                 "name":"Perry Li",
        ///                 "wage":200
        ///              }
        ///           ],
        ///           "phaseArr":[ 
        ///              { 
        ///                 "phaseID":20,
        ///                 "name":"consulting",
        ///                 "startDate":"2019-11-16T08:00:00.000Z",
        ///                 "endDate":"2019-11-30T08:00:00.000Z",
        ///                 "isRecordDone":true,
        ///                 "predictedDurationInWeeks":20,
        ///                 "actualDurationInWeeks":25,
        ///                 "impact":"high impact"
        ///              },
        ///              { 
        ///                 "phaseID":21,
        ///                 "name":"Requirements",
        ///                 "startDate":"2019-12-01T08:00:00.000Z",
        ///                 "endDate":"2019-12-05T08:00:00.000Z",
        ///                 "isRecordDone":true,
        ///                 "predictedDurationInWeeks":"21",
        ///                 "actualDurationInWeeks":25,
        ///                 "impact":"high impact"
        ///              },
        ///              { 
        ///                 "phaseID":22,
        ///                 "name":"Concept",
        ///                 "startDate":"2019-12-06T08:00:00.000Z",
        ///                 "endDate":"2019-12-21T08:00:00.000Z",
        ///                 "isRecordDone":true,
        ///                 "predictedDurationInWeeks":20,
        ///                 "actualDurationInWeeks":25,
        ///                 "impact":"high impact"
        ///              }
        ///           ],
        ///           "workloadArr":[ 
        ///              { 
        ///                 "empID":1,
        ///                 "empName":"Peter",
        ///                 "month1":0,
        ///                 "month2":0,
        ///                 "month3":29,
        ///                 "month4":31,
        ///                 "month5":5,
        ///                 "month6":6
        ///              },
        ///              { 
        ///                 "empID":2,
        ///                 "empName":"Reneil",
        ///                 "month1":12,
        ///                 "month2":3,
        ///                 "month3":0,
        ///                 "month4":0,
        ///                 "month5":0,
        ///                 "month6":0
        ///              },
        ///              { 
        ///                 "empID":3,
        ///                 "empName":"Perry",
        ///                 "month1":10,
        ///                 "month2":9,
        ///                 "month3":8,
        ///                 "month4":7,
        ///                 "month5":6,
        ///                 "month6":99
        ///              }
        ///           ],
        ///           "invoiceArr":[ 
        ///              { 
        ///                 "amount":997,
        ///                 "date":"2019-12-02T08:00:00.000Z"
        ///              },
        ///              { 
        ///                 "amount":471,
        ///                 "date":"2019-12-12T08:00:00.000Z"
        ///              },
        ///              { 
        ///                 "amount":642,
        ///                 "date":"2019-12-22T08:00:00.000Z"
        ///              }
        ///           ],
        ///           "material":[ 
        ///              { 
        ///                 "phaseID":20,
        ///                 "phaseName":"consulting",
        ///                 "actualBudget":200,
        ///                 "projectedBudget":100,
        ///                 "impact":"over $100"
        ///              },
        ///              { 
        ///                 "phaseID":21,
        ///                 "phaseName":"Requirements",
        ///                 "actualBudget":200,
        ///                 "projectedBudget":100,
        ///                 "impact":"over $100"
        ///              },
        ///              { 
        ///                 "phaseID":22,
        ///                 "phaseName":"Concept",
        ///                 "actualBudget":200,
        ///                 "projectedBudget":100,
        ///                 "impact":"over $100"
        ///              }
        ///           ]
        ///        }
        ///
        /// 
        /// </remarks>
        /// <param name="page">
        /// The IndividualProjectPage JSON object 
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(IndividualProjectPage page)
        {
            
            Project project = new Project(page.ID, page.Name,page.desc, page.startDate, page.endDate, page.completion, page.salaryBudget, page.totalInvoice, page.materialBudget, page.spendToDate, 
                page.progressSurveySent, page.progressSurveyResult,
                page.followupSurveySent, page.followupSurveyResult, page.isProposal, page.costMultiplier, page.isUnderISO13485, page.businessCode, page.lead[0].name);
            // <-- in the param
            _projectRepository.Add(project);

            for (int i = 0; i < page.phaseArr.Count; i++)
            {
                PhaseArr currentPhaseArr = page.phaseArr[i];
                Phase phase = new Phase(currentPhaseArr.phaseID, page.ID, currentPhaseArr.name, currentPhaseArr.startDate, currentPhaseArr.endDate, currentPhaseArr.isRecordDone, currentPhaseArr.predictedDurationInWeeks,
                    currentPhaseArr.actualDurationInWeeks, currentPhaseArr.impact, 0, 0, null);
                phase.MaterialProjectedBudget = page.material[i].projectedBudget;
                phase.MaterialActualBudget = page.material[i].actualBudget;
                phase.MaterialImpact = page.material[i].impact;
                _phaseRepository.Add(phase);
            }

            EmployeeAssignment ea = new EmployeeAssignment();
            for (int i = 0; i < page.employeeSalaryList.Count; i++)
            {
                ea.EmployeeId = page.employeeSalaryList[i].empID;

                ea.Position = "somePosition"; //hardcoded for now? 
                ea.SalaryMultiplier = page.costMultiplier;

                for (int j = 0; j < page.employeeSalaryList[i].phaseDetailsList.Count; j++)
                {
                    PhaseDetails currentPhaseDetails = page.employeeSalaryList[i].phaseDetailsList[j];
                    ea.PhaseId = currentPhaseDetails.phaseID;
                    ea.ActualHours = currentPhaseDetails.actualHr;
                    ea.ProjectedHours = currentPhaseDetails.budgetHr;
                    ea.Impact = currentPhaseDetails.impact;
                    for (int z = 0; z < page.lead.Count; z++)
                    {
                        if (ea.EmployeeId == page.lead[z].empID)
                        {
                            ea.IsProjectManager = true;
                        } 
                        else
                        {
                            ea.IsProjectManager = false;
                        }
                    }
                    _employeeAssignmentRepository.Add(ea);
                }

            }

            ProjectedWorkload pw = new ProjectedWorkload();
            for (int i = 0; i < page.workloadArr.Count; i++)
            {
                WorkloadArr currentWorkloadArr = page.workloadArr[i];
                foreach (Employee e in _employeeRepository.GetAll())
                {
                    if (e.EmployeeId == currentWorkloadArr.empID)
                    {
                        pw.ProjectId = page.ID;
                        pw.EmployeeId = e.EmployeeId;
                        for (int k = 0; k < 6; k++)
                        {                    
                            pw.Month = DateTime.Now.AddMonths(k).Month;
                            pw.Year = DateTime.Now.AddMonths(k).Year;
                            //pw.Month = ControllerHelper.CalculateCurrentMonth(currentMonth, k-1);
                            pw.Hours = currentWorkloadArr.getHoursWorked(k+1);
                            _projectedWorkloadRepository.Add(pw);
                        }
                    }
                }
            }

            foreach (InvoiceArr i in page.invoiceArr)
            {
                Invoice invoice = new Invoice(page.ID, "placeholdername", i.date, i.amount);
                _invoiceRepository.Add(invoice);
            }


            return new OkObjectResult(201);
        }

        /*
        //GET: api/individualprojectpages  NOT USED
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_projectRepository.GetAll());
            //System.Diagnostics.Debug.WriteLine("Inside get method of individualProjectPages controller... which does nothing");
            //return new OkObjectResult(400);
        }
        */
    }
}