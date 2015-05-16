// <copyright file="RouteConfig.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Webserver
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Sets up the non-API routes for the GameOfLife backend.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Register MVC Controller routes and other configuration with the global application.
        /// </summary>
        /// <param name="routes">Application route collection to map into.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }
    }
}

// eof
