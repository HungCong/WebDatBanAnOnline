using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebOrderTbRestaurant
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //Rewrite URL chi tiết món ăn
            routes.MapRoute(
                name: "Order table",
                url: "dat-ban",
                defaults: new { controller = "Order", action = "PageOrder", id = UrlParameter.Optional },
                namespaces: new[] { "WebOrderTbRestaurent.Controllers" }
            );

            //Rewrite URL chi tiết món ăn
            routes.MapRoute(
                name: "Food detail",
                url: "thuc-don/{metatitle}-{id}",
                defaults: new { controller = "Food", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "WebOrderTbRestaurent.Controllers" }
            );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "WebOrderTbRestaurent.Controllers" }
           );
        }
    }
}
