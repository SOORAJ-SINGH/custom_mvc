using CustomizationMvc.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomizationMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Custom()
        {


            return View();
        }

        public ActionResult CustomXML()
        {

            var employee = new Employee() { EmployeeId=1,EmployeeName="Rahul",Salary=23000 };
            //return new CustomXMLResult(new { name = "Pankaj", age = "23" });
            return new CustomXMLResult(employee);

        }
        public ActionResult GetEmployee(Employee emp)
        {
            return View();
        }
    }
}