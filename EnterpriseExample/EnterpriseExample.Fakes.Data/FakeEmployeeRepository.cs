using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseExample.Interfaces;
using EnterpriseExample.HR.Domain.Classes;
using EnterpriseExample.HR.Domain.Interfaces;

namespace EnterpriseExample.HR.Fakes.Data
{
    public class FakeEmployeeRepository : IEmployeeRepository
    {
        readonly List<Employee> _items;

        public FakeEmployeeRepository()
        {
            _items = new List<Employee>();
        }

        public Employee GetSingle(int EmployeeId)
        {
            return _items.Find(e => e.EmployeeId == EmployeeId);
        }

        public void InsertOrUpdate(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> GetAll()
        {
            return _items.AsQueryable();
        }

        public IQueryable<Employee> GetAllIncluding(
            params System.Linq.Expressions.Expression<Func<Employee, object>>[] includeProperties)
        {
            return GetAll();
        }

        public IQueryable<Employee> FindBy(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate)
        {
            return _items.AsQueryable().Where(predicate);
        }

        public void Add(Employee entity)
        {
            _items.Add(entity);
        }

        public void Delete(Employee entity)
        {
            _items.Remove(entity);
        }

        public void Edit(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
        }
    }
}
