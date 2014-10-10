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

            //routes.MapRoute(
            //    name: "TaskDefault",
            //    url: "Task/{action}/{id}",
            //    defaults: new { Controller = "Customer", action = "GetCustomers", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "CarDefault",
            //    url: "Car/{action}/{id}",
            //    defaults: new { Controller = "Customer", action = "GetCustomers", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "CustomerDefault",
                url: "Customer/{action}/{id}",
                defaults: new { controller = "Customer", action = "GetCustomers", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Customer", action = "GetCustomers", id = UrlParameter.Optional }
            );
        }
    }
}
