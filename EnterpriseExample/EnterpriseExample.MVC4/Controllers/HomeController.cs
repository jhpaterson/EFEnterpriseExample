using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EnterpriseExample.Interfaces;
using EnterpriseExample.HR.Domain.Interfaces;
using EnterpriseExample.HR.Domain.Classes;
using EnterpriseExample.HR.Data.Repositories;
using EnterpriseExample.HR.Data.Context;
using EnterpriseExample.BaseDataLayer.Context;

namespace EnterpriseExample.MVC4.Controllers
{
    public class HomeController : Controller
    {
        //private IEmployeeRepository _repository = new EmployeeRepository(new HRContext());
        //private IEmployeeRepository _repository;

        //public HomeController(IHRUnitOfWork uow)
        //{
        //    _repository = new EmployeeRepository(uow);
        //}

        public ActionResult Index()
        {
            //var result = _repository.GetAll().ToList();
            //var result = _repository.FindBy(e => e.Address.PostCode.Area == "G10")
            //    .ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
