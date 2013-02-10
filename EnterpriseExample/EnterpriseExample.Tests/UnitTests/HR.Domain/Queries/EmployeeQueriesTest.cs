using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnterpriseExample.HR.Domain.Classes;
using EnterpriseExample.HR.Domain.Queries;

namespace EnterpriseExample.Tests.UnitTests.HR.Domain.Queries
{
    [TestClass]
    public class EmployeeQueriesTest
    {
        [TestMethod]
        public void FilterByDepartmentIdReturnsCorrentNumberOfEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    Name = "Jenson",
                    DepartmentId = 1,
                    Department = new Department
                    {
                        Name = "Marketing"
                    }
                },
                 new Employee
                {
                    Name = "Checo",
                    DepartmentId = 1,
                    Department = new Department
                    {
                        Name = "Marketing"
                    }
                },
                 new Employee
                {
                    Name = "Fernando",
                    DepartmentId = 2,
                    Department = new Department
                    {
                        Name = "Sales"
                    }
                }
            }
            .AsQueryable<Employee>();

            Assert.AreEqual(2, employees.FilterByDepartmentId(1).Count());
        }

        [TestMethod]
        public void FilterByDepartmentNameReturnsCorrentNumberOfEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    Name = "Jenson",
                    DepartmentId = 1,
                    Department = new Department
                    {
                        Name = "Marketing"
                    }
                },
                 new Employee
                {
                    Name = "Checo",
                    DepartmentId = 1,
                    Department = new Department
                    {
                        Name = "Marketing"
                    }
                },
                 new Employee
                {
                    Name = "Fernando",
                    DepartmentId = 2,
                    Department = new Department
                    {
                        Name = "Sales"
                    }
                }
            }
            .AsQueryable<Employee>();

            Assert.AreEqual(2, employees.FilterByDepartmentName("Marketing").Count());
        }

        [TestMethod]
        public void FilterByGradeReturnsCorrentNumberOfEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    Name = "Jenson",
                    Grade = 5
                },
                 new Employee
                {
                    Name = "Checo",
                    Grade = 3
                },
                 new Employee
                {
                    Name = "Fernando",
                    Grade = 6
                },
                 new Employee
                {
                    Name = "Felipe",
                    Grade = 4
                }
            }
            .AsQueryable<Employee>();

            Assert.AreEqual(0, employees.FilterByGrade(1, 2).Count());
            Assert.AreEqual(1, employees.FilterByGrade(2, 3).Count());
            Assert.AreEqual(2, employees.FilterByGrade(3, 4).Count());
            Assert.AreEqual(3, employees.FilterByGrade(4, 6).Count());
            Assert.AreEqual(2, employees.FilterByGrade(5, 6).Count());
            Assert.AreEqual(1, employees.FilterByGrade(6, 7).Count());
            Assert.AreEqual(0, employees.FilterByGrade(7, 8).Count());
        }
    }
}
