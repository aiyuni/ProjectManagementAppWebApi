﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MakePlusWebAPI.Models.Repository
{
    public class VacationRepository : IDataRepository<Vacation>
    {
        private readonly ApplicationDbContext _vacationContext;

        public VacationRepository(ApplicationDbContext context)
        {
            this._vacationContext = context;
        }

        public void Add(Vacation vacay)
        {
            if(_vacationContext.Vacations.Any(p => p.EmployeeId == vacay.EmployeeId && p.Month == vacay.Month 
                                                && p.Year == vacay.Year) == false)
            {
                System.Diagnostics.Debug.WriteLine("record doesnt exist, adding...");
                _vacationContext.Add(vacay);
            }
            else
            {
                System.Diagnostics.Debug.Write("record already exists, updating...");
                Vacation vacayExist = _vacationContext.Vacations.FirstOrDefault(p => p.EmployeeId == vacay.EmployeeId && p.Month == vacay.Month && p.Year == vacay.Year);

                this.Update(vacayExist, vacay);
            }
            _vacationContext.SaveChanges();
            _vacationContext.Entry(vacay).State = EntityState.Detached;
        }

        public void Delete(Vacation entity)
        {
            throw new NotImplementedException();
        }

        public Vacation Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vacation> GetAll()
        {
            return _vacationContext.Vacations.ToList();
        }

        public int GetMaxId()
        {
            throw new NotImplementedException();
        }

        public void Update(Vacation dbEntity, Vacation entity)
        {
            _vacationContext.Entry(dbEntity).Property(x => x.Hours).CurrentValue = entity.Hours;
            // _projectedWorkloadDbContext.Entry(dbEntity).Property(x => x.Year).CurrentValue = entity.Year;
            // _projectedWorkloadDbContext.Entry(dbEntity).Property(x => x.Month).CurrentValue = entity.Month;
            System.Diagnostics.Debug.Write("Updated Vacation table...");
        }

    }
}
