using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginMVC.Models;
using System.Web.Security;
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

        public ActionResult Authorize(string email, string password)
        {
            using (Game_RentalEntities3 db = new Game_RentalEntities3())
            {
                String pass = encryptpass(password);
                bool isvalid = db.Customers.Any(x => x.email == email && x.password == pass);
                if (isvalid)
                {
                    FormsAuthentication.SetAuthCookie(email, false);
                    return RedirectToAction("Index", "Customer"); 
                }

                else
                {
                    ModelState.AddModelError(" ", "Invalid email or Password");
                    return View("Index");
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

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index");
        }
    }

}