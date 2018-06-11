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


            //Rewrite URL đặt bàn có chọn menu
            routes.MapRoute(
                name: "Order menu food",
                url: "dat-ban-menu",
                defaults: new { controller = "Order", action = "BookMenu", id = UrlParameter.Optional },
                namespaces: new string[] { "WebOrderTbRestaurant.Controllers" }
            );


            //Rewrite URL thêm món ăn vào menu
            routes.MapRoute(
                name: "Add menu food",
                url: "my-menu",
                defaults: new { controller = "Order", action = "AddMenu", id = UrlParameter.Optional },
                namespaces: new string[] { "WebOrderTbRestaurant.Controllers" }
            );


            //Rewrite URL chi tiết món ăn
            routes.MapRoute(
                name: "Order table",
                url: "dat-ban",
                defaults: new { controller = "Order", action = "PageOrder", id = UrlParameter.Optional },
                namespaces: new string[] { "WebOrderTbRestaurent.Controllers" }
            );

            //Rewrite URL chi tiết món ăn
            routes.MapRoute(
                name: "Food detail",
                url: "thuc-don/{metatitle}-{id}",
                defaults: new { controller = "Food", action = "Detail", id = UrlParameter.Optional },
                namespaces: new string[] { "WebOrderTbRestaurent.Controllers" }
            );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "WebOrderTbRestaurant.Controllers" }
           );
        }
    }
}
