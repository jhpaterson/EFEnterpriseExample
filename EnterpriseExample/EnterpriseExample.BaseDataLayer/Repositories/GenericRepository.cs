
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EnterpriseExample.Interfaces;

namespace EnterpriseExample.BaseDataLayer.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected DbContext _context;

        public DbContext Context
        {

            get { return _context; }
            set { _context = value; }
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public virtual IQueryable<T> GetAllIncluding(
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }

}
