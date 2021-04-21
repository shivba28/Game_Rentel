using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginMVC.Models;

namespace LoginMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(LoginMVC.Models.Customer userModel)
        {
            using (GameRentalEntities db = new GameRentalEntities())
            {
                var UserDetails = db.Customers.Where(x => x.email == userModel.email && x.password == userModel.password).FirstOrDefault();
                if(UserDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong email or password";
                    return View("Index", userModel);
                }

                else
                {
                    Session["CustomerID"] = UserDetails.customer_id;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}