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
