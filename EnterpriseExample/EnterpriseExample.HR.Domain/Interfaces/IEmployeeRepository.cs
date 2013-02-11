using EnterpriseExample.Interfaces;
using EnterpriseExample.HR.Domain.Classes;

namespace EnterpriseExample.HR.Domain.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Employee GetSingle(int EmployeeId);

        void InsertOrUpdate(Employee employee);
    }
}
