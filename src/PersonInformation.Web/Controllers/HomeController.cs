using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonInformation.Web.Models;
using PersonInformation.DataLogger.Interfaces;
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

        public ActionResult Index()
        {
            var personData = new PersonData { Name = "Name test", Surname = "Surname test", Address = "Address test" };
            return View(personData);
        }

        [HttpPost]
        public ActionResult SavePersonDataForm(PersonData personData)
        {
            // automapper map PersonData to UserData
            // call _userLogger.Log(UserData)


            return RedirectToAction("Index");
        }
    }
}