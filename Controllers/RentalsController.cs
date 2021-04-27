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
        private OnlineGameRentalStoreEntities1 db = new OnlineGameRentalStoreEntities1();
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
        public int Get(int id)
        {
            int res = (from r in db.Rentals where r.game_id == id select r.game_id).FirstOrDefault();
            //  var user = db.Rentals.Find(id);
            if (res != 0) { return 1; }
            else
            {
                return 0;
            }
        }
        public HttpResponseMessage Post([FromBody] Rental rent)
        {
            try
            {

                int availability = (from g in db.Games
                                    join r in db.Rentals
                                    on g.game_id equals r.game_id
                                    where g.game_id == rent.game_id
                                    select g.availability).FirstOrDefault();



                if (availability != 0)
                {
                    var entity = db.Games.Find(rent.game_id);



                    entity.availability = availability - 1;



                    db.Rentals.Add(rent);
                    db.SaveChanges();
                    //return "Data added to database";
                    var msg = Request.CreateResponse(HttpStatusCode.Created, rent);



                    return msg;
                }
                else
                {
                    var msg = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Game availability is not there");
                    return msg;
                }



            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

    }
}