using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakePlusWebAPI.Models.Repository;
using Microsoft.EntityFrameworkCore;


//not used anymore
namespace MakePlusWebAPI.Models.DataManager
{
    public class EmployeeManager : IDataRepository<Employee>
    {

        private readonly ApplicationDbContext _employeeContext;

        public EmployeeManager(ApplicationDbContext context)
        {
            this._employeeContext = context;
        }

        public void Add(Employee entity)
        {
            _employeeContext.Employees.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Update(Employee employee, Employee entity)
        {
            employee.Name = entity.Name;
            employee.Salary = entity.Salary;
        }

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.Employees.ToList();
        }

    }
}
