using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApplication1
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Customer

            config.Routes.MapHttpRoute(
                name: "FirstName",
                routeTemplate: "api/{controller}/firstName/{fname}"
            );

            config.Routes.MapHttpRoute(
                name: "LastName",
                routeTemplate: "api/{controller}/lastName/{lname}"
            );

            config.Routes.MapHttpRoute(
                name: "PhoneNumber",
                routeTemplate: "api/{controller}/phoneNumber/{phone}"
            );

            //Cart

            config.Routes.MapHttpRoute(
                name: "OrderID",
                routeTemplate: "api/{controller}/orderID/{orderID}"
            );

            config.Routes.MapHttpRoute(
                name: "ProdID",
                routeTemplate: "api/{controller}/prodID/{prodID}"
            );

            config.Routes.MapHttpRoute(
                name: "Quantity",
                routeTemplate: "api/{controller}/quantity/{quantity}"
            );

            //Order

            config.Routes.MapHttpRoute(
                name: "CustomerID",
                routeTemplate: "api/{controller}/customerID/{custID}"
            );

            config.Routes.MapHttpRoute(
                name: "poNumber",
                routeTemplate: "api/{controller}/poNumber/{poNumber}"
            );

            config.Routes.MapHttpRoute(
                name: "OrderDate",
                routeTemplate: "api/{controller}/orderDate/{orderDate}"
            );

            //Product

            config.Routes.MapHttpRoute(
                name: "ProductName",
                routeTemplate: "api/{controller}/productName/{prodName}"
            );

            config.Routes.MapHttpRoute(
                name: "Price",
                routeTemplate: "api/{controller}/price/{price}"
            );

            config.Routes.MapHttpRoute(
                name: "ProductWeight",
                routeTemplate: "api/{controller}/productWeight/{prodWeight}"
            );

            config.Routes.MapHttpRoute(
                name: "InStock",
                routeTemplate: "api/{controller}/inStock/{inStock}"
            );
        }
    }
}
