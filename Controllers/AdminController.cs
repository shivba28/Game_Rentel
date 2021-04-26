using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Text;

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
            if (email == "Admin@gmail.com" && password == "Admin")
            {
                FormsAuthentication.SetAuthCookie(email, false);
                if (Request.Form["ReturnUrl"] == "")
                {
                    return RedirectToAction("AdminHome", "Admin");
                }
                else
                {
                    return Redirect(Request.Form["ReturnUrl"]);
                }
            }
            else
            {
                ModelState.AddModelError(" ", "Invalid email or Password");
                return RedirectToAction("Index");
            }


        }

        [Models.AuthorizeUser]
        public ActionResult AdminHome()
        {
            return View("AdminHome");
        }

        [Models.AuthorizeUser]
        public ActionResult AddGame()
        {
            return View("AddGame");
        }

        [Models.AuthorizeUser]
        public ActionResult UpdateGame()
        {
            return View("UpdateGame");
        }

        [Models.AuthorizeUser]
        public ActionResult DeleteGame()
        {
            return View("DeleteGame");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }

}