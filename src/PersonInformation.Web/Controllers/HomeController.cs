using System;
using System.Web.Mvc;
using System.Xml;
using PersonInformation.Web.Models;
using PersonInformation.DataLogger.Interfaces;
using PersonInformation.DataLogger.Implementations;
using PersonInformation.DataLogger.Models;
using EnsureThat;

namespace PersonInformation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserDataLogger _userLogger;

        public HomeController(IUserDataLogger userLogger)
        {
            Ensure.That(() => userLogger).IsNotNull();
            _userLogger = userLogger;
        }

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            var personData = new PersonData { Name = "Name test", Surname = "Surname test", Address = "Address test" };
            return View(personData);
        }

        [HttpPost]
        public ActionResult Index(PersonData personData)
        {
            _userLogger.Log(new UserData { Name = personData.Name, Surname = personData.Surname });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public void LogData(PersonData personData)
        {
            
        }
    }
}