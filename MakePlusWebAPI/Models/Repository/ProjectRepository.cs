using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            if (_ProjectDbContext.Projects.FirstOrDefault() != null)
            {
                System.Diagnostics.Debug.WriteLine("Existing project id: " + 
                    _ProjectDbContext.Projects.FirstOrDefault().ProjectId + ", new project id: " + entity.ProjectId);
            }
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
        }

        public void Delete(Project entity)
        {
            throw new NotImplementedException();
        }

        public Project Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Project dbEntity, Project entity)
        {
            _ProjectDbContext.Entry(dbEntity).CurrentValues.SetValues(entity);
            System.Diagnostics.Debug.Write("Updated...");
        }
    }
}
