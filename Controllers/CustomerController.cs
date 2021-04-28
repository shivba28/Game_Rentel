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
            using (OnlineGameRentalStoreEntities1 db = new OnlineGameRentalStoreEntities1())
            {
                var list = (from game in db.Games select game).ToList();
                ViewBag.message = list;
                return View();
            }
                
        }

        public ActionResult CustomerLogin()
        {

            return RedirectToAction("Index", "Login");
        }


        [Authorize]
        public ActionResult Rent(string submit)
        {

            OnlineGameRentalStoreEntities db = new OnlineGameRentalStoreEntities();
            int newsubmit = int.Parse(submit);
            int game_id = newsubmit;
                var gamelist = (from glist in db.Games where glist.game_id == game_id select glist).ToList();
                ViewBag.message = gamelist;
                return View("Rent");
        }

        public ActionResult TopGames()
        {
         

            OnlineGameRentalStoreEntities db = new OnlineGameRentalStoreEntities();
            var result = (from r in db.Rentals
                          group r by r.game_id into gamegroup
                          join g in db.Games on gamegroup.Key equals g.game_id
                          select new TopViewModel
                          {
                              Id = gamegroup.Key,
                              Count = gamegroup.Count(),
                              name = g.game_name
                          }).OrderByDescending(c => c.Count).Take(5);
            
            int count = result.Count();
            ViewBag.message1 = count;
            ViewBag.message2 = result.ToList();
            return View("TopGames");
            
        }

        public ActionResult AboutUs()
        {
            return View("AboutUs");
        }

        public class TopViewModel
        {
            public int Id { get; set; }
            public string name { get; set; }
            public int Count { get; set; }
        }

    }


}