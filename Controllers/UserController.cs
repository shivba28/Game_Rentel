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
        private Game_RentalEntities1 db = new Game_RentalEntities1();
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

        public void Put(int id, [FromBody] Customer cust)
        {
            var data = db.Customers.Find(id);
            if (data != null)
            {
                data.customer_name = cust.customer_name;
                data.dob = cust.dob;
                data.contact = cust.contact;
                data.email = cust.email;
                db.SaveChanges();
            }

        }
    }
}

