using LoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoginMVC.Controllers
{
    
    public class UserController : ApiController
    {
        private GameRentalEntities2 db = new GameRentalEntities2();
        // GET api/values
        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }


        // GET api/values/5
        public Customer Get(int id)
        {
            var user = db.Customers.Find(id);
            return user;
        }


        public string PostUser([FromBody] Customer cust)
        {
            db.Customers.Add(cust);
            db.SaveChanges();
            return "Data added to database";
        }


        public void Delete(int id)
        {
            var data = db.Customers.Find(id);
            db.Customers.Remove(data);
            db.SaveChanges();
        }
    }
}

