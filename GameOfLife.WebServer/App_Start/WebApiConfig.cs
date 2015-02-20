// <copyright file="WebApiConfig.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.WebServer
{
    using System.Web.Http;
    using System.Web.Http.Filters;
    using GameOfLife.WebServer.Dependencies;
    using GameOfLife.WebServer.Filters;
    using Microsoft.Owin.Security.OAuth;

    /// <summary>
    /// Sets up the Web API for the GameOfLife backend.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register API routes and other configuration with the global application.
        /// </summary>
        /// <param name="config">The current configuration to add to.</param>
        public static void Register(HttpConfiguration config)
        {
            RegisterDependencyResolver(config);
            RegisterFilters(config.Filters);
            RegisterRoutes(config);
        }

        /// <summary>
        /// Registers dependency resolver for the web application, providing Web API style 
        /// resolution.
        /// </summary>
        /// <param name="config">The current configuration being wired up.</param>
        private static void RegisterDependencyResolver(HttpConfiguration config)
        {
            config.DependencyResolver = new ResolverBootstrapper(new[] 
                { 
                    new IOModule() 
                });
        }

        /// <summary>
        /// Register filters with the web application.
        /// </summary>
        /// <param name="filters">Filter collection to add new mappings to.</param>
        private static void RegisterFilters(HttpFilterCollection filters)
        {
            filters.Add(new ValidateModelAttribute());
        }

        /// <summary>
        /// Registers routes with the web application.
        /// </summary>
        /// <param name="config">Configuration being created.</param>
        private static void RegisterRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}

// eof