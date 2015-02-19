// <copyright file="WebApiConfig.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.WebServer
{
    using System.Web.Http;
    using Microsoft.Owin.Security.OAuth;

    /// <summary>
    /// Sets up the Web API for the GameOfLife backend.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register API Routes and other configuration with the global application.
        /// </summary>
        /// <param name="config">The current configuration to add to.</param>
        public static void Register(HttpConfiguration config)
        {
            //// Web API configuration and services
            //// Configure Web API to use only bearer token authentication.
            //// config.SuppressDefaultHostAuthentication();
            //// config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
