using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MakePlusWebAPI.Models.Repository
{
    public class PhaseRepository : IDataRepository<Phase>
    {
        private readonly ApplicationDbContext _PhaseDbContext;

        public PhaseRepository(ApplicationDbContext context)
        {
            this._PhaseDbContext = context;
        }

        public void Add(Phase entity)
        {

            System.Diagnostics.Debug.WriteLine("Inside Add method of PhaseRepository");

            if (_PhaseDbContext.Phases.FirstOrDefault() != null)
            {
                System.Diagnostics.Debug.WriteLine("Existing phaseid: " +
                                                   _PhaseDbContext.Phases.FirstOrDefault().PhaseId + ", new project id: " + entity.PhaseId);
            }
            //System.Diagnostics.Debug.WriteLine("Existing project id: " + _ProjectDbContext.Projects.FirstOrDefault().ProjectId + ", new project id: " + entity.ProjectId);
            if (_PhaseDbContext.Phases.Any(p => p.PhaseId == entity.PhaseId) == false)
            {
                System.Diagnostics.Debug.WriteLine("record doesnt exist, adding...");
                _PhaseDbContext.Phases.Add(entity);
            }
            else
            {
                System.Diagnostics.Debug.Write("record already exists, updating...");
                Phase existingPhase = _PhaseDbContext.Phases.FirstOrDefault(p => p.PhaseId == entity.PhaseId);
                this.Update(existingPhase, entity);
                //_ProjectDbContext.Projects.Update();
            }

            _PhaseDbContext.SaveChanges();
            _PhaseDbContext.Entry(entity).State = EntityState.Detached;
            //throw new NotImplementedException();
        }


        public void Delete(Phase entity)
        {
            throw new NotImplementedException();
        }

        public Phase Get(int id)
        {
            return _PhaseDbContext.Phases.Find(id);
        }

        public IEnumerable<Phase> GetAll()
        {
            return _PhaseDbContext.Phases.ToList();
        }

        public int GetMaxId()
        {
            int maxId = 0;
            foreach (Phase item in GetAll())
            {
                if (item.PhaseId > maxId)
                {
                    maxId = item.PhaseId;
                }
            }

            return maxId;
        }

        public void Update(Phase dbEntity, Phase entity)
        {
            _PhaseDbContext.Entry(dbEntity).CurrentValues.SetValues(entity);
            System.Diagnostics.Debug.Write("Updated...");
        }
    }
}
