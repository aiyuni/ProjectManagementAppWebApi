using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MakePlusWebAPI.Models.Repository
{
    public class ProjectRepository : IDataRepository<Project>
    {
        private readonly ApplicationDbContext _ProjectDbContext;

        public ProjectRepository(ApplicationDbContext context)
        {
            this._ProjectDbContext = context;
        }

        public void Add(Project entity)
        {
            System.Diagnostics.Debug.WriteLine("Inside Add method of ProjectRepository");
            System.Diagnostics.Debug.WriteLine("Project being added is: " + entity.ToString());

            //System.Diagnostics.Debug.WriteLine("Existing project id: " + _ProjectDbContext.Projects.FirstOrDefault().ProjectId + ", new project id: " + entity.ProjectId);
            if (_ProjectDbContext.Projects.Any(p => p.ProjectId == entity.ProjectId) == false)
            {
                System.Diagnostics.Debug.WriteLine("record doesnt exist, adding...");
                _ProjectDbContext.Projects.Add(entity);
            }
            else
            {
                System.Diagnostics.Debug.Write("record already exists, updating...");
                Project existingProject = _ProjectDbContext.Projects.FirstOrDefault(p => p.ProjectId == entity.ProjectId);
                this.Update(existingProject, entity);
                //_ProjectDbContext.Projects.Update();
            }

            _ProjectDbContext.SaveChanges();
            _ProjectDbContext.Entry(entity).State = EntityState.Detached;
        }

        public void Delete(Project entity)
        {
            throw new NotImplementedException();
        }

        public Project Get(int id)
        {
            return _ProjectDbContext.Projects.Find(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return _ProjectDbContext.Projects.ToList();
        }

        public void Update(Project dbEntity, Project entity)
        {
            _ProjectDbContext.Entry(dbEntity).CurrentValues.SetValues(entity);
            System.Diagnostics.Debug.Write("Updated...");
        }

        public int GetMaxId()
        {
            int maxId = 0;
            foreach (Project item in GetAll())
            {
                if (item.ProjectId > maxId)
                {
                    maxId = item.ProjectId;
                }
            }

            return maxId;
        }
    }
}
