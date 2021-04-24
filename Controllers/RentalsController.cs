using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoginMVC.Models;

namespace LoginMVC.Controllers
{
    public class RentalsController : ApiController
    {
        // GET api/<controller>
        private Game_RentalEntities4 db = new Game_RentalEntities4();
        // GET api/games

        //GET api/games
        public IEnumerable<Object> GetActiveList()
        {

          //  var result = from c in db.Customers
            //             join r in db.Rentals
              //           on c.customer_id equals r.customer_id
                //         select c.customer_name;


            var result = from c in db.Customers
                         join r in db.Rentals
                         on c.customer_id equals r.customer_id
                         join g in db.Games on r.game_id equals g.game_id
                         select new 
                         {
                            
                             customer_name = c.customer_name,
                             game_name=g.game_name,
                             email= c.email,

                         };
            //List<Customer_Detail> customer = new List<Customer_Detail>();
            //foreach (var val in result)
            //{
            // customer.Add(val);
            //}
            return result;
        }
    }
}