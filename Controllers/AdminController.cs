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
        public ActionResult AdminLogin(string email, string password)
        {
            if(email=="Admin@gmail.com" && password=="Admin")
            {
                return View("AdminHome");
            }
            ViewBag.errormsg = "wrong email or password";
            return RedirectToAction("Index");
        }
        public ActionResult AdminHome()
        {
            return View("AdminHome");
        }

        public ActionResult AddGame()
        {
            return View("AddGame");
        }


        public ActionResult UpdateGame()
        {
            return View("UpdateGame");
        }


        public ActionResult DeleteGame()
        {
            return View("DeleteGame");
        }


        public ActionResult ActiveList()
        {
            return View("ActiveList");
        }
    }

}