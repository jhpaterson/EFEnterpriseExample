using System.Linq;
using System.Data;
using System.Data.Entity;
using EnterpriseExample.HR.Domain.Classes;
using EnterpriseExample.HR.Domain.Interfaces;
using EnterpriseExample.BaseDataLayer.Repositories;

namespace EnterpriseExample.HR.Data.Repositories
{
    public class EmployeeRepository :
        GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IHRUnitOfWork uow)
        {
            _context = uow as DbContext;
        }

        public Employee GetSingle(int employeeId)
        {
            var query = GetAll()
                .Include(e => e.Address)
                .FirstOrDefault(e => e.EmployeeId == employeeId);
            return query;
        }

        public virtual void InsertOrUpdate(Employee employee)
        {
            if (employee.EmployeeId == default(int)) 
            {
                _context.Entry(employee).State = EntityState.Added;
            }
            else      
            {
                _context.Entry(employee).State = EntityState.Modified;
            }
        }
    }
}
