using System;
using System.Collections.Generic;
using System.Linq;
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
            using (GameRentalEntities db = new GameRentalEntities())
            {
                
               /*if ( == userModel.email)
                {
                    userModel.LoginErrorMessage = "email already exist";
                    return View("RegistrationView", userModel);
                }*/
                
                    Customer cust = new Customer();
                    cust.customer_name = userModel.customer_name;
                    cust.dob = userModel.dob;
                cust.gender = userModel.gender;
                cust.contact = userModel.contact;
                cust.email = userModel.email;
                cust.password = userModel.password;

                    db.Customers.Add(cust);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
             
            }
        }
    }
}