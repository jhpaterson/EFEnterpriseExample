using System.Data.Entity;
using EnterpriseExample.BaseDataLayer.Context;
using EnterpriseExample.Payroll.Domain.Classes;
using EnterpriseExample.Payroll.Domain.Interfaces;

namespace EnterpriseExample.Payroll.Data.Context
{
    public class PayrollContext : BaseContext<PayrollContext>, IPayrollUnitOfWork
    {
        public PayrollContext()
            : base()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Department> Departments { get; set; }

        public int Save()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
               .HasMany(d => d.Employees)
               .WithOptional()
               .Map(x =>
               {
                   x.MapKey("DepartmentId");        // this field name is set by FK property in HR domain Employee class
               });
        }

    }
}

