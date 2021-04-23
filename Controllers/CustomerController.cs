using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerLogin()
        {
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Rent()
        {
            return View("Rent");
        }

        public ActionResult TopGames()
        {
            return View("TopGames");
        }

    }
}