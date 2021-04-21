using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View("AdminLogin");
        }

        [HttpPost]

        public ActionResult AdminHome()
        {
            return View("AdminHome");
        }
    }

}