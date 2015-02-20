// <copyright file="Global.asax.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.WebServer
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using GameOfLife.WebServer.Dependencies;

    /// <summary>
    /// The main API application for Game Of Life.
    /// </summary>
    public class GameOfLifeApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Handles all wire-up on application star by registering areas, filters and routes.
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

// eof