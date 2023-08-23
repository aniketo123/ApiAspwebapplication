using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebAPIsProjec
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Value", action = "Index", id = UrlParameter.Optional }
            );

           // routes.JsonFormatter.SupportedMediaTypes.Add(newMediaTypeHeaderValue("text/html"));

        }
    }
}
