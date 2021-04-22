using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginMVC.Models;

using System.Text;

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
            using (Game_RentalEntities db = new Game_RentalEntities())
            {
                String pass = encryptpass(userModel.password);
                var UserDetails = db.Customers.Where(x => x.email == userModel.email && x.password == pass).FirstOrDefault();
                if (UserDetails == null)
                {
                    //   userModel.LoginErrorMessage = "Wrong email or password";
                    return View("Index", userModel);
                }

                else
                {
                    Session["CustomerID"] = UserDetails.customer_id;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        public string encryptpass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }
    }

}