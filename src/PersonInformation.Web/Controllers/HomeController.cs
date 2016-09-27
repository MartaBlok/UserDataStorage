using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using PersonInformation.Web.Models;
using PersonInformation.DataLogger.Interfaces;
using EnsureThat;
using PersonInformation.DataLogger.Implementations;
using PersonInformation.DataLogger.Models;

namespace PersonInformation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserDataLogger _userLogger;

        //public HomeController(IUserDataLogger userLogger)
        //{
        //    Ensure.That(() => userLogger).IsNotNull();
        //    _userLogger = userLogger;
        //}

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
            // automapper map PersonData to UserData
            // call _userLogger.Log(UserData)
            TextDataLogStorage textLogger = new TextDataLogStorage();
            var userDto = new UserData {Name = personData.Name, Surname = personData.Surname};
            textLogger.Log(userDto);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public void LogData(PersonData personData)
        {
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true
            };

            using (XmlWriter writer = XmlWriter.Create(Console.Out, settings))
            {
                writer.WriteStartElement("User");
                writer.WriteAttributeString("Name", personData.Name);
                writer.WriteElementString("Surname", personData.Surname);
                writer.WriteElementString("Address", personData.Address);
                writer.WriteEndElement();
            }
        }
    }
}