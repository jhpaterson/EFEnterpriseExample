using System.Linq;
using System.Data;
using System.Data.Entity;
using EnterpriseExample.Payroll.Domain.Classes;
using EnterpriseExample.Payroll.Domain.Interfaces;
using EnterpriseExample.BaseDataLayer.Repositories;

namespace EnterpriseExample.Payroll.Data.Repositories
{
    public class DepartmentRepository :
        GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IPayrollUnitOfWork uow)
        {
            _context = uow as DbContext;
        }

        public Department GetSingle(int departmentId)
        {
            var query = GetAll()
                .Include(d => d.Employees)
                .FirstOrDefault(d => d.DepartmentId == departmentId);
            return query;
        }

        public virtual void InsertOrUpdate(Department department)
        {
            if (department.DepartmentId == default(int)) 
            {
                _context.Entry(department).State = EntityState.Added;
            }
            else      
            {
                _context.Entry(department).State = EntityState.Modified;
            }
        }
    }
}
