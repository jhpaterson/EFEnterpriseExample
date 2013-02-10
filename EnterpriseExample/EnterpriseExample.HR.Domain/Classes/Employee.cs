namespace EnterpriseExample.HR.Domain.Classes
{
    public class Employee 
    {
        protected const string EMAIL_SUFFIX = "@example.com";

        public int EmployeeId{get;set;}
        public string Name{get;set;}
        public string Username{get;set;}
        public int Grade { get; set; }
        public string Biography { get; set; }
        public byte[] Photo { get; set; }
        public string PhoneNumber{get;set;}
        public Address Address { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public string Email
        {
            get
            {
                return Username + EMAIL_SUFFIX;
            }
        }
    }
}
