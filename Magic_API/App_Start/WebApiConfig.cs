using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Magic_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{DistrictId}",
                defaults: new { DistrictId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
            "DefaultApiEmrollment",
            "api/{controller}/{SchoolYearID}/{StudentID}",
            new { controller = "Enrollment", SchoolYearID = "", StudentID = "" }
        );
        }
    }
}
