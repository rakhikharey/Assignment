using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace retail_Shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.png");
            routes.IgnoreRoute("*.js|css|swf|jpg|png|gif|woff|eot|ttf|svg");
            routes.RouteExistingFiles = true;
            routes.LowercaseUrls = true;

            routes.MapRoute(
         name: "RetailCustomerLogin",
         url: "retail",
         defaults: new { controller = "Retail", action = "customerlogin", category = UrlParameter.Optional }
         );
            routes.MapRoute(
         name: "RetailCustomerDetail",
         url: "retail/{user}",
         defaults: new { controller = "Retail", action = "customerdetail", category = UrlParameter.Optional }
         );
            routes.MapRoute(
         name: "RetailReceiptDetail",
         url: "retail/receipt/{user}",
         defaults: new { controller = "Retail", action = "receiptdetail", category = UrlParameter.Optional }
         );


        }
    }
}
