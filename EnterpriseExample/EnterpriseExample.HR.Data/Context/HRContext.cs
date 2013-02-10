using System.Data.Entity;
using EnterpriseExample.BaseDataLayer.Context;
using EnterpriseExample.HR.Domain.Classes;
using EnterpriseExample.HR.Domain.Interfaces;

namespace EnterpriseExample.HR.Data.Context
{
    public class HRContext : BaseContext<HRContext>, IHRUnitOfWork
    {
        public HRContext()
            : base()
        {
            Database.SetInitializer<HRContext>(new HRContextInitializer());
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public int Save()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Ignore(e => e.Email);
        }

    }
}

