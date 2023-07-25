using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiPractica;
using Swashbuckle.Application;

public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        // Web API configuration and services

        // Restul configurării...

        // Activați Swagger și includeți comentariile XML
        config.EnableSwagger(c =>
        {
            c.SingleApiVersion("v1", "WebApiPractica");
            var xmlCommentsPath = System.AppDomain.CurrentDomain.BaseDirectory + @"App_Data\Documentation.xml";
            c.IncludeXmlComments(xmlCommentsPath);
        }).EnableSwaggerUi();

        // Restul configurării...

        // Web API routes
        config.MapHttpAttributeRoutes();

        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
    }
}