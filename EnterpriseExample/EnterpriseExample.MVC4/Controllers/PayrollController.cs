using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseExample.Payroll.Domain.Classes;
using EnterpriseExample.Interfaces;
using EnterpriseExample.Payroll.Domain.Interfaces;

namespace EnterpriseExample.MVC4.Controllers
{
    public class PayrollController : Controller
    {
        private IDepartmentRepository _repository;

        public PayrollController(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Payroll/

        public ActionResult Index()
        {
            var departments = _repository.GetAll();
            var selectList = new SelectList(departments, "DepartmentId", "Name");
            return View(selectList);
        }
        
        //
        // GET: /Payroll/Process/5

        public ActionResult Process(int id)
        {
            Department department = _repository.GetSingle(id);
            if (department != null)
            {
                var payroll = new PayrollProcessor();
                decimal totalPayrollCost = payroll.Process(department);
                return View(totalPayrollCost);
            }
            else
            {
                return View("Index");
            }
        }

    }
}
