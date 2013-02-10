using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
