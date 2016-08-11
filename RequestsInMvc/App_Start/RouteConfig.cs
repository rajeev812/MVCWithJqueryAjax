using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RequestsInMvc
{
    public class RouteConfig
    {
        private const string Default = "Default";
        private const string ControllerActionAndId = "ControllerActionAndId";
        private const string GridData = "GridData";

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                Default,
                "",
                new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: GridData,
                url: "{controller}/{action}/{pageNo}/{pageSize}",
                defaults: new { controller = "User", action = "Find" }
            );

            routes.MapRoute(
                name: ControllerActionAndId,
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}