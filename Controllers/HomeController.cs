using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public String Index(string id)
        {
            return "user logged in";
        }


    }
}