using System.Data.Entity;
using EnterpriseExample.Interfaces;

namespace EnterpriseExample.BaseDataLayer.Context
{
    public class BaseContext<T>
    : DbContext where T : DbContext
    {
        public BaseContext()
            : base("name=CompanyContext")
        {
            Database.SetInitializer<T>(null);   // prevents contexts trying to initialise unless explicitly configured to do so
        }

    }
}
