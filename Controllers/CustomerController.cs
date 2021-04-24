using LoginMVC.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class CustomerController : Controller
    {

        // GET: Customer
        public ActionResult Index(LoginMVC.Models.Game userModel)
        {
                return View();
        }

        public ActionResult CustomerLogin()
        {
            return RedirectToAction("Index", "Login");
        }

        [Authorize]
        public ActionResult Rent()
        {
            return View("Rent");
        }

        [Authorize]
        public ActionResult TopGames()
        {
            return View("TopGames");
        }

    }
}