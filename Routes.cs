using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Mvc.Routes;
using System.Web.Routing;
using System.Web.Mvc;

namespace HYT.NewsDemo
{
    public class Routes : IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[]
            {

                new RouteDescriptor
                {
                    Route = new Route
                    (
                        "testdemo/news",
                        new RouteValueDictionary
                        {
                            {"area", "HYT.NewsDemo"},
                            {"controller", "News"},
                            {"action", "Index"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary{
                            {"area","HYT.NewsDemo"}
                        },
                        new MvcRouteHandler()
                    )
                },
                new RouteDescriptor
                {
                    Route = new Route
                    (
                        "testdemo/news/create",
                        new RouteValueDictionary
                        {
                            {"area", "HYT.NewsDemo"},
                            {"controller", "News"},
                            {"action", "Create"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary{
                            {"area","HYT.NewsDemo"}
                        },
                        new MvcRouteHandler()
                    )
                },
                new RouteDescriptor
                {
                    Route = new Route
                    (
                        "testdemo/news/editView/{id}",
                        new RouteValueDictionary
                        {
                            {"area", "HYT.NewsDemo"},
                            {"controller", "News"},
                            {"action", "Editview"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary{
                            {"area","HYT.NewsDemo"}
                        },
                        new MvcRouteHandler()
                    )
                },
                new RouteDescriptor
                {
                    Route = new Route
                    (
                        "testdemo/news/edit",
                        new RouteValueDictionary
                        {
                            {"area", "HYT.NewsDemo"},
                            {"controller", "News"},
                            {"action", "Edit"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary{
                            {"area","HYT.NewsDemo"}
                        },
                        new MvcRouteHandler()
                    )
                },
                new RouteDescriptor
                {
                    Route = new Route
                    (
                        "testdemo/news/delete/{id}",
                        new RouteValueDictionary
                        {
                            {"area", "HYT.NewsDemo"},
                            {"controller", "News"},
                            {"action", "Delete"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary{
                            {"area","HYT.NewsDemo"}
                        },
                        new MvcRouteHandler()
                    )
                }
            };
        }
    }
}