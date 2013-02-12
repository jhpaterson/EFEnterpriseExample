using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnterpriseExample.HR.Domain.Classes;
using EnterpriseExample.HR.Fakes.Data;
using EnterpriseExample.MVC4.Controllers;

namespace EnterpriseExample.Tests.UnitTests.MVC4.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void ByDepartmentReturnsModelWithCorrectNumberOfEmployees()
        {
            // Arrange
            var repo = new FakeEmployeeRepository();                                // Fake not Mock as we want to test that controller applies correct filter, so repo method used in controller needs to return a queryable
            repo.Add(new Employee { EmployeeId = 1, DepartmentId = 1 });
            repo.Add(new Employee { EmployeeId = 2, DepartmentId = 1 });
            repo.Add(new Employee { EmployeeId = 3, DepartmentId = 2 });
            repo.Add(new Employee { EmployeeId = 4, DepartmentId = 2 });
            EmployeeController controllerToTest = new EmployeeController(repo);

            // Act
            var result = (ViewResult) controllerToTest.ByDepartment(1);
            var model = result.ViewData.Model as IEnumerable<Employee>;

            // Assert
            Assert.AreEqual(model.Count(), 2, "Incorrect number of results");
        }
    }
}
