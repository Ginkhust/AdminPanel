using System.Web.Mvc;
using System.Web.Routing;

namespace AdminPanel
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Account",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AccountController", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                 name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "User",
                url:  "{controller}/{action}/{id}",
                defaults: new { controller = "Users", action = "UsersList", id = UrlParameter.Optional }
            );
            

            routes.MapRoute(
                 name: "Product",
                 url:  "{controller}/{action}/{id}",
                 defaults: new { controller = "Products", action = "AddProduct", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "News",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "News", action = "ShowNews", id = UrlParameter.Optional}
                );
         
        }
    }
}
