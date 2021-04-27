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
        public ActionResult Index(string submit)
        {
            OnlineGameRentalStoreEntities db = new OnlineGameRentalStoreEntities();
            int newsubmit = int.Parse(submit);
            int game_id = newsubmit;
            var gamelist = (from glist in db.Games where glist.game_id == game_id select glist).ToList();
            ViewBag.message = gamelist;
            return View();
        }

        [HttpPost]

        public ActionResult Authorize(string email, string password, string submit)
        {
            ViewBag.message = submit;
            using (OnlineGameRentalStoreEntities db = new OnlineGameRentalStoreEntities())
            {    
                String pass = encryptpass(password);
                bool isvalid = db.Customers.Any(x => x.email == email && x.password == pass);
                if (isvalid)
                {
                    FormsAuthentication.SetAuthCookie(email, false);
                    if (Request.Form["ReturnUrl"] == "")
                    {
                        
                        return RedirectToAction("Index", "Customer");
                    }
                    else
                    {
                        return Redirect(Request.Form["ReturnUrl"]);
                    }
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