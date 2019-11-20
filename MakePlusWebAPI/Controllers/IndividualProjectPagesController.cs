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

        //GET: api/individualprojectpages
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_projectRepository.GetAll());
            //System.Diagnostics.Debug.WriteLine("Inside get method of individualProjectPages controller... which does nothing");
            //return new OkObjectResult(400);
        }

        //GET: api/individualprojectpages/id
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
                recoredStoredCompleted = 69,
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

            /*for (int i = 0; i <= _phaseRepository.GetMaxId(); i++)  //getMaxId returns the last id of the table, so it must be <=
            {
                if (_phaseRepository.Get(i) != null && _phaseRepository.Get(i).ProjectId == id)
                {
                    Phase currentPhase = _phaseRepository.Get(i);
                    individualProjectPage.phaseArr.Add(new PhaseArr(currentPhase.PhaseId, currentPhase.Name,
                        currentPhase.StartDate, currentPhase.EndDate, currentPhase.IsRecordDone,
                        currentPhase.PredictedDurationInWeeks, currentPhase.ActualDurationInWeeks, currentPhase.Impact));
                }
            } */

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

            /*
            for (int i = 0; i <= _projectRepository.GetMaxId(); i++)
            {
                if (_projectRepository.Get(i) != null && _projectRepository.Get(i).ProjectId == id)
                {
                    for (int j = 0; j <= _employeeRepository.GetMaxId(); j++)
                    {
                        if (_employeeRepository.Get(j) != null)
                        {
                            Employee currentEmployee = _employeeRepository.Get(j);
                            Project currentProject = _projectRepository.Get(i);

                            //Developer Assumption: if ProjectedWorkload exists for Month1, then they will also exist for Month2-6.  
                            ProjectedWorkload currentProjectedWorkload =
                                _projectedWorkloadRepository.Get(i, j, DateTime.Now.Month, DateTime.Now.Year);  
                            if (currentProjectedWorkload == null)
                            {
                                continue;
                            }

                            for (int k = 0; k < 6; k++)
                            {
                                int currentMonth = DateTime.Now.AddMonths(k).Month;
                                int currentYear = DateTime.Now.AddMonths(k).Year;

                                if (_employeeRepository.Get(j).EmployeeId == _projectedWorkloadRepository
                                        .Get(i, j, currentMonth, currentYear).EmployeeId
                                    && _projectRepository.Get(i).ProjectId == _projectedWorkloadRepository
                                        .Get(i, j, currentMonth, currentYear).ProjectId)
                                {
                                    currentWorkloadArr.empID = _employeeRepository.Get(j).EmployeeId;
                                    currentWorkloadArr.empName = _employeeRepository.Get(j).Name;
                                    currentWorkloadArr.SetSpecificMonth(k + 1, _projectedWorkloadRepository
                                        .Get(i, j, currentMonth, currentYear).Hours);
                                }
                            }
                            individualProjectPage.workloadArr.Add(new WorkloadArr(currentWorkloadArr.empID, currentWorkloadArr.empName, currentWorkloadArr.month1, currentWorkloadArr.month2,
                                currentWorkloadArr.month3, currentWorkloadArr.month4, currentWorkloadArr.month5, currentWorkloadArr.month6));
                        }
                    }
                }
            } */

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
            /*for (int i = 0; i <= _phaseRepository.GetMaxId(); i++)
            {
                if (_phaseRepository.Get(i) != null && _phaseRepository.Get(i).ProjectId ==id)
                {
                    Phase currentPhase = _phaseRepository.Get(i);
                    individualProjectPage.material.Add(new Material(currentPhase.PhaseId, currentPhase.Name, currentPhase.MaterialActualBudget,
                        currentPhase.MaterialProjectedBudget, currentPhase.MaterialImpact));
                }
            }*/

            foreach (Phase phase in _phaseRepository.GetAll())
            {
                if (phase.ProjectId == id)
                {
                    individualProjectPage.material.Add(new Material(phase.PhaseId, phase.Name, phase.MaterialActualBudget,
                        phase.MaterialProjectedBudget, phase.MaterialImpact));
                }
            }

            individualProjectPage.employeeSalaryList = new List<EmployeeSalary>();
            /*
            for (int i = 0; i <= _employeeRepository.GetMaxId(); i++)
            {
                if (_employeeRepository.Get(i) != null)
                {
                    Employee currentEmployee = _employeeRepository.Get(i);
                    List<PhaseDetails> phaseDetailsList = new List<PhaseDetails>();
                    for (int j = 0; j <= _phaseRepository.GetMaxId(); j++)
                    {
                        if (_phaseRepository.Get(j) != null && _phaseRepository.Get(j).ProjectId == id)
                        {
                            Phase currentPhase = _phaseRepository.Get(j);
                            if (_employeeAssignmentRepository.Get(currentPhase.PhaseId, currentEmployee.EmployeeId)!= null)
                            {
                                EmployeeAssignment currentEmployeeAssignment = _employeeAssignmentRepository.Get(currentPhase.PhaseId, currentEmployee.EmployeeId);
                            phaseDetailsList.Add(new PhaseDetails(currentPhase.PhaseId, currentPhase.Name, currentEmployeeAssignment.ProjectedHours, currentEmployeeAssignment.ActualHours, 
                                currentEmployeeAssignment.Impact));
                            }
                        }
                    }
                    if (phaseDetailsList.Count != 0)  //to prevent all the employees from being added to the employeeSalaryList.  Only employees that are working on the project will be added. 
                    {
                        individualProjectPage.employeeSalaryList.Add(new EmployeeSalary(currentEmployee.EmployeeId, currentEmployee.Name, currentEmployee.Salary, phaseDetailsList));
                    }

                }
            }
            */

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
        [HttpPost]
        public IActionResult Post(IndividualProjectPage page)
        {
            
            Project project = new Project(page.ID, page.Name,page.desc, page.startDate, page.endDate, page.completion, page.salaryBudget, page.totalInvoice, page.materialBudget, page.spendToDate, 
                page.progressSurveySent, page.progressSurveyResult,
                page.followupSurveySent, page.followupSurveyResult, true, 69.9, page.isUnderISO13485, page.businessCode, page.lead[0].name);
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
                ea.SalaryMultiplier = 69.9;

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

    }
}