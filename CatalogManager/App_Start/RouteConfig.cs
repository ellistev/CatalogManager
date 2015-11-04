using System.Web.Mvc;
using System.Web.Routing;

namespace CatalogManager
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Category", "Category/{action}/{id}",
                new {controller = "Category", id = UrlParameter.Optional}
                );

            routes.MapRoute("Product", "Product/{action}/{id}",
                new {controller = "Product", action = "Index", id = UrlParameter.Optional}
                );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Catalog", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}