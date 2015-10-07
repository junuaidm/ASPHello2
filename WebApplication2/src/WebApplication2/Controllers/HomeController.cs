using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApplication2.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }                                                    

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Message"] = "Here is a person";
            var person = new Person() {
                FirstName = "Junaid",
                LastName="Muringattu",
                Birthdate = new DateTime (1988,01,03)

            };
            return View(person);
        }
        [HttpPost]
        public IActionResult Index(Person person)
        {

            return View(person);
        }
    }
}
