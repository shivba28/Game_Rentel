
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LoginMVC.Models;

namespace LoginMVC.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View("RegistrationView");
        }

        [HttpPost]
        public ActionResult AuthorizeReg(LoginMVC.Models.Customer userModel)
        {
            using (Game_RentalEntities2 db = new Game_RentalEntities2())
            {
                Customer cust = new Customer();
                var eid = db.Customers.Any(x => x.email == userModel.email);
                if (eid)
                {
                    //  userModel.LoginErrorMessage = "email already exist";
                    return View("RegistrationView", userModel);
                }


                else
                {
                    cust.customer_name = userModel.customer_name;
                    cust.dob = userModel.dob;
                    cust.gender = userModel.gender;
                    cust.contact = userModel.contact;
                    cust.email = userModel.email;
                    cust.password = encryptpass(userModel.password);

                    db.Customers.Add(cust);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
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