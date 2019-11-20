using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MakePlusWebAPI.Models.Repository
{
    public class ProjectedWorkloadRepository : IDataRepository<ProjectedWorkload>
    {
        private readonly ApplicationDbContext _projectedWorkloadDbContext;

        public ProjectedWorkloadRepository(ApplicationDbContext dbContext)
        {
            this._projectedWorkloadDbContext = dbContext;
        }

        public void Add(ProjectedWorkload entity)
        {
            System.Diagnostics.Debug.WriteLine("Inside Add method of EmployeeAssignmentRepository");

            if (_projectedWorkloadDbContext.ProjectedWorkloads.FirstOrDefault() != null)
            {
                System.Diagnostics.Debug.WriteLine("Existing workload table project id: " +
                                                   _projectedWorkloadDbContext.ProjectedWorkloads.FirstOrDefault().ProjectId + ", new project id: " + entity.ProjectId);
            }
            //System.Diagnostics.Debug.WriteLine("Existing project id: " + _ProjectDbContext.Projects.FirstOrDefault().ProjectId + ", new project id: " + entity.ProjectId);
            if (_projectedWorkloadDbContext.ProjectedWorkloads.Any(p => p.ProjectId == entity.ProjectId && p.EmployeeId == entity.EmployeeId && p.Month == entity.Month 
                                                                        && p.Year == entity.Year) == false)
            {
                System.Diagnostics.Debug.WriteLine("record doesnt exist, adding...");
                _projectedWorkloadDbContext.Add(entity); //instance of entity type cannot be tracked because another instance with the same key value (phaseid, employeeid) is already being tracked
            }
            else
            {
                System.Diagnostics.Debug.Write("record already exists, updating...");
                ProjectedWorkload existingEA = _projectedWorkloadDbContext.ProjectedWorkloads.FirstOrDefault(p => p.ProjectId== entity.ProjectId && p.EmployeeId == entity.EmployeeId 
                                                                                                                  && p.Month == entity.Month && p.Year == entity.Year);
                this.Update(existingEA, entity);
                //_ProjectDbContext.Projects.Update();
            }

            _projectedWorkloadDbContext.SaveChanges();
            _projectedWorkloadDbContext.Entry(entity).State = EntityState.Detached;
        }

        public void Delete(ProjectedWorkload entity)
        {
            throw new NotImplementedException();
        }


        public ProjectedWorkload Get(int id)
        {
            throw new NotImplementedException();
        }

        /**
         *Get method. Obtains the Projected Workload based on the given primary keys.
         */
        public ProjectedWorkload Get(int projectId, int employeeId, int month, int year)
        {
            return _projectedWorkloadDbContext.ProjectedWorkloads.Find(projectId, employeeId, month, year);
        }

        /** 
         * Overloaded Get method. Accepts a Project and Employee to get the Projected Workload
         */
        public ProjectedWorkload Get(Project project, Employee emp, int month, int year)
        {
            return _projectedWorkloadDbContext.ProjectedWorkloads.Find(project.ProjectId, emp.EmployeeId, month, year);
        }

        public IEnumerable<ProjectedWorkload> GetAll()
        {
            return _projectedWorkloadDbContext.ProjectedWorkloads.ToList();
        }

        public int GetMaxId()
        {
            throw new NotImplementedException();
        }

        public void Update(ProjectedWorkload dbEntity, ProjectedWorkload entity)
        {
            _projectedWorkloadDbContext.Entry(dbEntity).Property(x => x.EmployeeId).IsModified = false;
            _projectedWorkloadDbContext.Entry(dbEntity).Property(x => x.ProjectId).IsModified = false;
            _projectedWorkloadDbContext.SaveChanges();
            //_projectedWorkloadDbContext.Entry(dbEntity).CurrentValues.SetValues(entity);

            _projectedWorkloadDbContext.Entry(dbEntity).Property(x => x.Hours).CurrentValue = entity.Hours;
           // _projectedWorkloadDbContext.Entry(dbEntity).Property(x => x.Year).CurrentValue = entity.Year;
           // _projectedWorkloadDbContext.Entry(dbEntity).Property(x => x.Month).CurrentValue = entity.Month;
            System.Diagnostics.Debug.Write("Updated ProjectedWorkload table...");
        }
    }
}
