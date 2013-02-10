using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseExample.Interfaces;
using EnterpriseExample.Payroll.Domain.Classes;

namespace EnterpriseExample.Payroll.Domain.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Department GetSingle(int departmentId);

        void InsertOrUpdate(Department department);
    }
}
