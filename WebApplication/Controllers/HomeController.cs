using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnitOfWorkLayer.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  HTTP GET Method
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllPersons()
        {
            var persons = new List<Person>
            {
                new Person {id = 1, name = "erich", address = "somewehere" },
                new Person {id = 2, name= "elli", address = "by my side" }
            };

            //TODO : Invoke RESTful WCF
            //string baseUrl = Request.UrlReferrer.AbsoluteUri;
            string baseUrl = "http://localhost:60550/";
            string wcfEndpoint = "PersonService.svc/json/";
            string restMethod = "Persons/";

            string restApi = baseUrl + wcfEndpoint + restMethod;

            var request = (HttpWebRequest)WebRequest.Create(restApi);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string jsonResult = reader.ReadToEnd();

            return Json(persons, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// HTTP POST Method
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddPerson(Person person)
        {
            //TODO: Invoke RESTful WCF

            return Json(new { success = true, message = "message" });
        }

    }
}