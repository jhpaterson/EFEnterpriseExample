using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseExample.Payroll.Domain.Classes
{
    public class PayrollProcessor
    {
        public decimal Process(Department department)
        {
            // do some processing, create money transfers, lots of usefull stuff
            PayScale payScale = new PayScale();
            decimal total = 0.0m;
            foreach (var emp in department.Employees)
            {
                total += payScale.Data[emp.Grade];
            }
            return total;
        }
    }


    class PayScale
    {
        private IDictionary<int, decimal> data;

        public IDictionary<int, decimal> Data
        {
            get
            {
                return data;
            }
        }

        public PayScale()
        {
            data = new Dictionary<int, decimal>();
            data.Add(1,2500m);
            data.Add(2,2600m);
            data.Add(3,2700m);
            data.Add(4,2800m);
            data.Add(5,2900m);
            data.Add(6,3000m);
            data.Add(7,3100m);
            data.Add(8,3200m);
            data.Add(9,3300m);
        }
    }

}
