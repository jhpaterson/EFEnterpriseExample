using System.Data.Entity;
using EnterpriseExample.Interfaces;

namespace EnterpriseExample.BaseDataLayer.Context
{
    public class BaseContext<TContext>
    : DbContext where TContext : DbContext
    {
        public BaseContext()
            : base("name=CompanyContext")
        {
            Database.SetInitializer<TContext>(null);
        }

        // should make this protected and change TContext to T, remove initialiser 
        // line unless really needed - based on Lerman's Enterprise course code
    }
}
