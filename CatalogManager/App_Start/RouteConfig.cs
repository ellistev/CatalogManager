using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CatalogManager
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Category",
                url: "Category/{action}/{id}",
                defaults: new { controller = "Category", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product",
                url: "Product/{action}/{id}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Catalog", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
