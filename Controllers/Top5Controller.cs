using LoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoginMVC.Controllers
{
    public class Top5Controller : ApiController
    {
        private OnlineGameRentalStoreEntities db = new OnlineGameRentalStoreEntities();
        public IEnumerable<object> GetTop5()
        {

            //  var result = from c in db.Customers
            //             join r in db.Rentals
            //           on c.customer_id equals r.customer_id
            //         select c.customer_name;


            //var result =(from r in db.Rentals                        
            //         group r by r.game_id into gamegroup
            //       orderby gamegroup.Count() descending
            //     select gamegroup.Count()).Take(2);

            var result = (from r in db.Rentals
                          group r by r.game_id into gamegroup                         
                          join g in db.Games on gamegroup.Key equals g.game_id
                          select new
                          {
                              Id = gamegroup.Key,
                              Count = gamegroup.Count(),
                              name=g.game_name
                          }).OrderByDescending(c=>c.Count).Take(5);
            //var result = db.Rentals.GroupBy(r => r.game_id).OrderBy(r => r.Key).SelectMany(g => g.OrderByDescending(x => x.game_id)).Take(1);
            //List<Customer_Detail> customer = new List<Customer_Detail>();
            //foreach (var val in result)
            //{ listStudents.GroupBy(g => g.Name).OrderBy(g => g.Key).SelectMany(g => g.OrderByDescending(x => x.Grade)).ToList().ForEach(x => Console.WriteLine(x.ToString()));

            // customer.Add(val);
            //}
            return result;
        }
    }
}