﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ERPWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ProductsController",
                routeTemplate: "api/Products"
                //defaults: new { controller = "Customer" }
            );

            config.Routes.MapHttpRoute(
                name: "CustomerController",
                routeTemplate: "api/{controller}",
                defaults: new { controller="Customer" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
