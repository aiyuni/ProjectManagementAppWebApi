using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MakePlusWebAPI.Models.Repository
{
    public class EmployeeAssignmentRepository : IDataRepository<EmployeeAssignment>
    {

        private readonly ApplicationDbContext _EmployeeAssignmentDbContext;

        public EmployeeAssignmentRepository(ApplicationDbContext context)
        {
            this._EmployeeAssignmentDbContext = context;
        }

        public void Add(EmployeeAssignment entity)
        {
            System.Diagnostics.Debug.WriteLine("Inside Add method of EmployeeAssignmentRepository");
            EmployeeAssignment existingEA;
            //System.Diagnostics.Debug.WriteLine("Existing project id: " + _ProjectDbContext.Projects.FirstOrDefault().ProjectId + ", new project id: " + entity.ProjectId);
            if (_EmployeeAssignmentDbContext.EmployeeAssignments.Any(p => p.PhaseId == entity.PhaseId && p.EmployeeId == entity.EmployeeId) == false)
            {
                System.Diagnostics.Debug.WriteLine("record doesnt exist, adding...");
                _EmployeeAssignmentDbContext.Add(entity); //instance of entity type cannot be tracked because another instance with the same key value (phaseid, employeeid) is already being tracked
            }

            else
            {
                System.Diagnostics.Debug.Write("record already exists, updating...");
                existingEA = _EmployeeAssignmentDbContext.EmployeeAssignments.FirstOrDefault(p => p.PhaseId == entity.PhaseId && p.EmployeeId == entity.EmployeeId);
                this.Update(existingEA, entity);
                //_ProjectDbContext.Projects.Update();
            }

            try
            {
                _EmployeeAssignmentDbContext.SaveChanges();
                _EmployeeAssignmentDbContext.Entry(entity).State = EntityState.Detached;
            } catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("caught weird exception: " + e.ToString());
                //_EmployeeAssignmentDbContext.Entry(existingEA).Reload();
                //this.Update(existingEA, entity);
            }
        }

        public void Delete(EmployeeAssignment entity)
        {
            throw new NotImplementedException();
        }

        public EmployeeAssignment Get(int id)
        {
            throw new NotImplementedException();
        }

        public EmployeeAssignment Get(int phaseId, int employeeId)
        {
            return _EmployeeAssignmentDbContext.EmployeeAssignments.Find(phaseId, employeeId);
            //throw new NotImplementedException();
        }


        public IEnumerable<EmployeeAssignment> GetAll()
        {
            return _EmployeeAssignmentDbContext.EmployeeAssignments.ToList();
        }

        public void Update(EmployeeAssignment dbEntity, EmployeeAssignment entity)
        {
            _EmployeeAssignmentDbContext.Entry(dbEntity).Property(x => x.EmployeeId).IsModified = false;
            _EmployeeAssignmentDbContext.Entry(dbEntity).Property(x => x.PhaseId).IsModified = false;
            _EmployeeAssignmentDbContext.SaveChanges();
            //_EmployeeAssignmentDbContext.Entry(dbEntity).CurrentValues.SetValues(entity);

            _EmployeeAssignmentDbContext.Entry(dbEntity).Property(x => x.Position).CurrentValue = entity.Position;
            _EmployeeAssignmentDbContext.Entry(dbEntity).Property(x => x.SalaryMultiplier).CurrentValue = entity.SalaryMultiplier;
            _EmployeeAssignmentDbContext.Entry(dbEntity).Property(x => x.ProjectedHours).CurrentValue = entity.ProjectedHours;
            _EmployeeAssignmentDbContext.Entry(dbEntity).Property(x => x.ActualHours).CurrentValue = entity.ActualHours;
            _EmployeeAssignmentDbContext.Entry(dbEntity).Property(x => x.Impact).CurrentValue = entity.Impact;    
            _EmployeeAssignmentDbContext.Entry(dbEntity).Property(x => x.IsProjectManager).CurrentValue = entity.IsProjectManager;
            System.Diagnostics.Debug.Write("Updated EmployeeAssignment...");
        }

        public int GetMaxId()
        {
            throw new NotImplementedException();
        }

      
    }
}
