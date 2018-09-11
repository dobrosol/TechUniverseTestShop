using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

               routes.MapRoute(
                name:null,
                url: "{controller}/{action}",
                namespaces: new string[] { "WebUI.Controllers" }
            );
               routes.MapRoute(
                    name:null,
                    url:"",
                    defaults:new {action="Index", controller="Shop"},
                    namespaces: new string[] { "WebUI.Controllers"}
            );               
        }
    }
}
