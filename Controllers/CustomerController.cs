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
            using (OnlineGameRentalStoreEntities db = new OnlineGameRentalStoreEntities())
            {
                var list = (from game_name in db.Games select game_name).ToList();
                ViewBag.message = list;
                return View();
            }
                
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

        public ActionResult TopGames()
        {
            using (OnlineGameRentalStoreEntities db = new OnlineGameRentalStoreEntities())
            {
                var list = (from game_name in db.Rentals select game_name).ToList();
                ViewBag.message = list;
                return View("TopGames");
            }
            
        }

        public ActionResult AboutUs()
        {
            return View("AboutUs");
        }

    }
}