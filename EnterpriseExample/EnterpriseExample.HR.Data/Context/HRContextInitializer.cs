using System.Data.Entity;
using EnterpriseExample.BaseDataLayer.Context;
using EnterpriseExample.HR.Domain.Classes;
using System.Collections.Generic;

namespace EnterpriseExample.HR.Data.Context
{
    public class HRContextInitializer  : CreateDatabaseIfNotExists<HRContext>
    {
        protected override void Seed(HRContext context)
        {
            base.Seed(context);

            Address ad1 = new Address
            {
                PropertyNumber = 10,
                PostCode = new PostCode
                {
                    Area = "G10",
                    Property = "1XX"
                }
            };

            Address ad2 = new Address
            {
                PropertyNumber = 20,
                PostCode = new PostCode
                {
                    Area = "G20",
                    Property = "1YY"
                }
            };

            Address ad3 = new Address
            {
                PropertyNumber = 30,
                PostCode = new PostCode
                {
                    Area = "G30",
                    Property = "1ZZ"
                }
            };

            Employee emp1 = new Employee
            {
                Name = "Jenson",
                Username = "jenson",
                Grade = 8,
                PhoneNumber = "9876",
                Biography = "Jenson is a good bloke who has done a lot of stuff",
                Photo = new byte[100],
                Address = ad1
            };

            Employee emp2 = new Employee
            {
                Name = "Checo",
                Username = "checo",
                Grade = 2,
                PhoneNumber = "5432",
                Biography = "Checo is a new guy who has very good qualifications",
                Photo = new byte[100],
                Address = ad1
            };

            Employee emp3 = new Employee
            {
                Name = "Fernando",
                Username = "fernando",
                Grade = 9,
                PhoneNumber = "1234",
                Biography = "Fernando is very highly regarded in the industry",
                Photo = new byte[100],
                Address = ad2
            };

            Employee emp4 = new Employee
            {
                Name = "Felipe",
                Username = "felipe",
                Grade = 4,
                PhoneNumber = "5678",
                Biography = "Felipe has been with the compnay for a very long time",
                Photo = new byte[100],
                Address = ad2
            };

            Employee emp5 = new Employee
            {
                Name = "Seb",
                Username = "seb",
                Grade = 6,
                PhoneNumber = "1468",
                Biography = "Seb is a jolly nice chap",
                Photo = new byte[100],
                Address = ad3
            };

            Department dep1 = new Department
            {
                Name = "Marketing",
                Employees = new List<Employee>{
                    emp1,
                    emp3
                }
            };

            Department dep2 = new Department
            {
                Name = "Sales",
                Employees = new List<Employee>{
                    emp2,
                    emp4,
                    emp5
                }
            };

            context.Departments.Add(dep1);
            context.Departments.Add(dep2);

            context.SaveChanges();

        }
    }
}
