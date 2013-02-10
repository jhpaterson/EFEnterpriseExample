using System;

namespace EnterpriseExample.HR.Domain.Classes
{
    public class PostCode
    {
        public string Area { get; set; }
        public string Property { get; set; }

        public string FullCode
        {
            get { return String.Format("{0} {1}", Area, Property); }
        }
    }
}
