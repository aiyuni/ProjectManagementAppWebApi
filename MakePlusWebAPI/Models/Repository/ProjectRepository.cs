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

            _ProjectDbContext.Projects.Add(entity);
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
            throw new NotImplementedException();
        }
    }
}
