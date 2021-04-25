using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace LoginMVC.Models
{
    public class AuthorizeUserAttribute : System.Web.Mvc.AuthorizeAttribute
    {

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var username = filterContext.HttpContext.User.Identity.Name;
            if (username != "")
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Admin", action = "Index" }));
            }
        }
    }
}