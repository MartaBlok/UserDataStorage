using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonInformation.Web.Models;

namespace PersonInformation.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var personData = new PersonData { Name = "Name test", Surname = "Surname test", Address = "Address test" };
            return View(personData);
        }

        public ViewResult About()
        {
            throw new NotImplementedException();
        }

        public ViewResult Contact()
        {
            throw new NotImplementedException();
        }
    }
}