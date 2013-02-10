using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseExample.HR.Domain.Classes;

namespace EnterpriseExample.HR.Domain.Queries
{
    public static class EmployeeQueries
    {
        public static IQueryable<Employee>
        FilterByDepartmentId(this IQueryable<Employee> items, int departmentId)
        {
            return items.Where(e => e.DepartmentId == departmentId);
        }

        public static IQueryable<Employee>
        FilterByDepartmentName(this IQueryable<Employee> items, string name)
        {
            return items.Where(e => e.Department.Name == name);
        }

        public static IQueryable<Employee>
        FilterByGrade(this IQueryable<Employee> items, int low, int high)
        {
            return items.Where(e => e.Grade >= low && e.Grade <= high);
        }
    }
}
