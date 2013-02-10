using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseExample.HR.Domain.Classes;
using EnterpriseExample.HR.Domain.Queries;
using EnterpriseExample.Interfaces;
using EnterpriseExample.HR.Domain.Interfaces;


namespace EnterpriseExample.MVC4.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Employee/

        public ActionResult Index()
        {
            return View(_repository.GetAll().ToList());
        }

        //
        // GET: /Employee/ByDepartment/5

        public ActionResult ByDepartment(int id = 0)
        {
            var employees = _repository
                .GetAllIncluding(e => e.Address, e => e.Department)
                .FilterByDepartmentId(id)
                .ToList();
            return View("Index", employees);
            // note: attaching new employee to department not implemented yet
        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id = 0)
        {
            Employee employee = _repository.GetSingle(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // GET: /Employee/Create

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.DepartmentId = 1;
                _repository.InsertOrUpdate(employee);
                _repository.Save();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        //
        // GET: /Employee/Edit/5

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Employee employee = _repository.GetSingle(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repository.InsertOrUpdate(employee);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //
        // GET: /Employee/EditAddress/5

        [HttpGet]
        public ActionResult EditAddress(int id = 0)
        {
            Employee employee = _repository.GetSingle(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewData["EmployeedId"] = id;
            return View(employee.Address);
        }

        //
        // POST: /Employee/EditAddress/5

        [HttpPost]
        public ActionResult EditAddress(int id, Address address)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _repository.GetSingle(id);
                employee.Address = address;
                _repository.InsertOrUpdate(employee);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(address);
        }

        //
        // GET: /Employee/Delete/5

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            Employee employee = _repository.GetSingle(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = _repository.GetSingle(id);
            _repository.Delete(employee);
            _repository.Save();
            return RedirectToAction("Index");
        }

    }
}